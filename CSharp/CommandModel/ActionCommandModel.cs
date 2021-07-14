using System;

namespace CodeSnippets
{
    /// <summary>
    /// Parameterless command
    /// </summary>
    public class ActionCommandModel : CommandModel
    {
        private readonly Func<bool> _canExecute;
        private readonly Action _execute;

        /// <summary>
        /// Constructs this object
        /// </summary>
        /// <param name="canExecute">CanExecute action</param>
        /// <param name="execute">Execute action</param>
        public ActionCommandModel(Func<bool> canExecute, Action execute)
        {
            _canExecute = canExecute;
            _execute = execute;
        }

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state
        /// </summary>
        /// <returns>true if this command can be executed; otherwise, false.</returns>
        protected override bool CanExecute()
        {
            return _canExecute();
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        protected override void Execute()
        {
            _execute();
        }
    }

    /// <summary>
    /// Parameterised action command
    /// </summary>
    /// <typeparam name="T">Parameter type</typeparam>
    public class ActionCommandModel<T> : CommandModel<T>
    {
        private readonly Func<T, bool> _canExecute;
        private readonly Action<T> _execute;

        /// <summary>
        /// Constructs this object
        /// </summary>
        /// <param name="canExecute">CanExecute action</param>
        /// <param name="execute">Execute action</param>
        public ActionCommandModel(Func<T, bool> canExecute, Action<T> execute)
        {
            _canExecute = canExecute;
            _execute = execute;
        }

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state
        /// </summary>
        /// <param name="parameter">Data used by the command. If the command does not require data to be passed, this object can be set to null.</param>
        /// <returns>true if this command can be executed; otherwise, false.</returns>
        protected override bool CanExecute(T parameter)
        {
            return _canExecute(parameter);
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command. If the command does not require data to be passed, this object can be set to null.</param>
        protected override void Execute(T parameter)
        {
            _execute(parameter);
        }
    }
}
