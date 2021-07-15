# View Model Property

A class which implements the INotifyPropertyChanged interface and handles all of the value storage and events.

I have found it creates much shorter view model code and most of the logic is kept in lambdas.

# Example

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