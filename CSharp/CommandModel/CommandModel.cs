using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CodeSnippets
{
    /// <summary>
    /// Command model object
    /// </summary>
    public abstract class CommandModel : NotifyPropertyChangedViewModel, ICommandModel, ICommand
    {
        /// <summary>
        /// Gets the command for this entity
        /// </summary>
        public ICommand Command => this;

        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state
        /// </summary>
        /// <param name="parameter">Data used by the command. If the command does not require data to be passed, this object can be set to null.</param>
        /// <returns>true if this command can be executed; otherwise, false.</returns>
        public bool CanExecute(object parameter)
        {
            return CanExecute();
        }

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state
        /// </summary>
        /// <returns>true if this command can be executed; otherwise, false.</returns>
        protected abstract bool CanExecute();


        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command. If the command does not require data to be passed, this object can be set to null.</param>
        public void Execute(object parameter)
        {
            Execute();
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        protected abstract void Execute();

        /// <summary>
        /// Causes the command and model to update thier state
        /// </summary>
        public void Update()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }

    /// <summary>
    /// Parameterised command model
    /// </summary>
    /// <typeparam name="T">Parameter type</typeparam>
    public abstract class CommandModel<T> : NotifyPropertyChangedViewModel, ICommandModel, ICommand
    {
        /// <summary>
        /// Gets the command for this entity
        /// </summary>
        public ICommand Command => this;

        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state
        /// </summary>
        /// <param name="parameter">Data used by the command. If the command does not require data to be passed, this object can be set to null.</param>
        /// <returns>true if this command can be executed; otherwise, false.</returns>
        public bool CanExecute(object parameter)
        {
            return CanExecute((T)parameter);
        }

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state
        /// </summary>
        /// <param name="parameter">Data used by the command. If the command does not require data to be passed, this object can be set to null.</param>
        /// <returns>true if this command can be executed; otherwise, false.</returns>
        protected abstract bool CanExecute(T parameter);

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command. If the command does not require data to be passed, this object can be set to null.</param>
        public void Execute(object parameter)
        {
            Execute((T)parameter);
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command. If the command does not require data to be passed, this object can be set to null.</param>
        protected abstract void Execute(T parameter);

        /// <summary>
        /// Causes the command and model to update thier state
        /// </summary>
        public void Update()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
