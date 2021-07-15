# File Dialog Filter Builder

Makes the creation of the file dialog filters easy.

# Example

```CSharp
var filters = new FileDialogFilterBuilder();
filters.Add("XML Files", "*.xml");
filters.Add("Media files", "*.mp4", "*.mp3", "*.wav");
filters.AddAllFiles();

var dialog = new OpenFileDialog();
dialog.Filters = filters.ToString();

// dialog.ShowDialog() ... etc.
```