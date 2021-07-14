using System.ComponentModel;
using System.Windows.Input;

namespace CodeSnippets
{
    /// <summary>
    /// Command model
    /// </summary>
    public interface ICommandModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Gets the command for this model
        /// </summary>
        ICommand Command { get; }

        /// <summary>
        /// Causes the command and model to update thier state
        /// </summary>
        void Update();
    }
}
