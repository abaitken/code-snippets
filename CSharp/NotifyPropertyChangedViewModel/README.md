# Notify Property Changed View Model

Base view model with method to raise the PropertyChangedEventHandler.

Generally I use this less and prefer to use ViewModelProperty<T> properties instead.

# Example

```CSharp
class MainWindowViewModel : NotifyPropertyChangedViewModel
{
    private string _text;
    
    public string Text
    {
        get => _text;
        set
        {
            if(_text == value)
                return;
            
            _text = value;
            PropertyHasChanged(); // No need to pass in property names
        }
    }
}
```