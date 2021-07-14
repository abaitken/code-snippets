using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CodeSnippets
{
    /// <summary>
    /// Base View Model class
    /// </summary>
    public abstract class NotifyPropertyChangedViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notifies subscribers that a property value has changed
        /// </summary>
        /// <param name="propertyName">Property name</param>
        protected void PropertyHasChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null && propertyName != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
