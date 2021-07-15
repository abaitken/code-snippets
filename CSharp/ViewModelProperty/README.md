# View Model Property

A class which implements the INotifyPropertyChanged interface and handles all of the value storage and events.

I have found it creates much shorter view model code and most of the logic is kept in lambdas.

# Simple Example

```CSharp
class MainWindowViewModel
{
    public MainWindowViewModel()
    {
        CopyToClipboard = new ActionCommandModel(
            () => Text != null && !string.IsNullOrEmpty(Text.Value) /* Command is only valid when Text has a value */, 
            () => Clipboard.SetText(Text.Value) /* Copy text to clipboard */);
        Text = new ViewModelProperty<string>(CopyToClipboard.Update /* When the property is changed, update the command */)
    }

    public ViewModelProperty<string> Text { get; }
    public ICommandModel CopyToClipboard { get; }
}
```

```XAML
<TextBox Text="{Binding Text.Value}" />
<Button Content="Copy to clipboard" Command="{Binding CopyToClipboard.Command}" />
```

# Complex Example

Quite often a property value is assigning the value of another object, using ``ViewModelPropertyDataSource<T>.Create(...)`` the ViewModelProperty object can provide a simple wrapper, replacing the typcial property code and state with a single line of code.

Assume some object with state:

```CSharp
public class SomeOtherObjectWithState
{
    public string Text { get; set; }
}
```

This is the short version:

```CSharp
class MainWindowViewModel
{
    private SomeOtherObjectWithState _state;
    
    public MainWindowViewModel()
    {
        // Assume _state is assigned somehow
        Text = new ViewModelProperty<string>(ViewModelPropertyDataSource<string>.Create(_state, o => o.Text))
    }

    public ViewModelProperty<string> Text { get; }
}
```

Which avoids this code:


```CSharp
class MainWindowViewModel : NotifyPropertyChangedViewModel
{
    private SomeOtherObjectWithState _state;
    
    public MainWindowViewModel()
    {
        // Assume _state is assigned somehow
    }

    public string Text
    {
        get => _state.Text;
        set
        {
            if(_state.Text == value)
                return;
            
            _state.Text = value;
            PropertyHasChanged();
        }
    }
}
```
