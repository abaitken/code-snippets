# Command Model

Simplfies the implementation of commands, based on an idea from somewhere else I cannot remember.

A pair of interfaces and abstract classes are provided which offers typed parameter and parameterless options. As well as a delegate based implementation for quick usage when application level commands are not neccessary.

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