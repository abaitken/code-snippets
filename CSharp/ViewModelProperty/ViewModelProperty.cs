using System;

namespace CodeSnippets
{
    /// <summary>
    /// View model property
    /// </summary>
    /// <typeparam name="T">Data type</typeparam>
    public class ViewModelProperty<T> : NotifyPropertyChangedViewModel
    {
        private readonly ViewModelPropertyDataSource<T> _dataSource;
        private readonly ViewModelPropertyCallbacks.Changed3<T> _changedCallback;

        private static void NoOp()
        {
            /* Do nothing */
        }

        /// <summary>
        /// Constructs this object
        /// </summary>
        public ViewModelProperty()
            : this(ViewModelPropertyDataSource<T>.Default(), NoOp)
        {
        }

        /// <summary>
        /// Constructs this object
        /// </summary>
        /// <param name="dataSource">Backing data source</param>
        public ViewModelProperty(ViewModelPropertyDataSource<T> dataSource)
            : this(dataSource, NoOp)
        {
        }

        /// <summary>
        /// Constructs this object
        /// </summary>
        /// <param name="changedCallback">Callback invoked after the value has changed</param>
        public ViewModelProperty(ViewModelPropertyCallbacks.Changed1 changedCallback)
            : this(ViewModelPropertyDataSource<T>.Default(), (prop, old, @new) => changedCallback())
        {
        }

        /// <summary>
        /// Constructs this object
        /// </summary>
        /// <param name="changedCallback">Callback invoked after the value has changed</param>
        public ViewModelProperty(ViewModelPropertyCallbacks.Changed2<T> changedCallback)
            : this(ViewModelPropertyDataSource<T>.Default(), (prop, old, @new) => changedCallback(prop))
        {
        }

        /// <summary>
        /// Constructs this object
        /// </summary>
        /// <param name="changedCallback">Callback invoked after the value has changed</param>
        public ViewModelProperty(ViewModelPropertyCallbacks.Changed3<T> changedCallback)
            : this(ViewModelPropertyDataSource<T>.Default(), (prop, old, @new) => changedCallback(prop, old, @new))
        {
        }

        /// <summary>
        /// Constructs this object
        /// </summary>
        /// <param name="changedCallback">Callback invoked after the value has changed</param>
        public ViewModelProperty(ViewModelPropertyCallbacks.Changed4<T> changedCallback)
            : this(ViewModelPropertyDataSource<T>.Default(), (prop, old, @new) => changedCallback(old, @new))
        {
        }

        /// <summary>
        /// Constructs this object
        /// </summary>
        /// <param name="dataSource">Backing data source</param>
        /// <param name="changedCallback">Callback invoked after the value has changed</param>
        public ViewModelProperty(ViewModelPropertyDataSource<T> dataSource, ViewModelPropertyCallbacks.Changed1 changedCallback)
            : this(dataSource, (prop, old, @new) => changedCallback())
        {
        }

        /// <summary>
        /// Constructs this object
        /// </summary>
        /// <param name="dataSource">Backing data source</param>
        /// <param name="changedCallback">Callback invoked after the value has changed</param>
        public ViewModelProperty(ViewModelPropertyDataSource<T> dataSource, ViewModelPropertyCallbacks.Changed2<T> changedCallback)
            : this(dataSource, (prop, old, @new) => changedCallback(prop))
        {
        }

        /// <summary>
        /// Constructs this object
        /// </summary>
        /// <param name="dataSource">Backing data source</param>
        /// <param name="changedCallback">Callback invoked after the value has changed</param>
        public ViewModelProperty(ViewModelPropertyDataSource<T> dataSource, ViewModelPropertyCallbacks.Changed3<T> changedCallback)
        {
            _dataSource = dataSource;
            _changedCallback = changedCallback;
        }

        /// <summary>
        /// Constructs this object
        /// </summary>
        /// <param name="dataSource">Backing data source</param>
        /// <param name="changedCallback">Callback invoked after the value has changed</param>
        public ViewModelProperty(ViewModelPropertyDataSource<T> dataSource, ViewModelPropertyCallbacks.Changed4<T> changedCallback)
            : this(dataSource, (prop, old, @new) => changedCallback(old, @new))
        {
        }

        /// <summary>
        /// Gets or sets the value
        /// </summary>
        public T Value
        {
            get => _dataSource.Value;
            set
            {
                if (_dataSource.Value == null && value == null)
                    return;
                if (_dataSource.Value != null && (object.ReferenceEquals(_dataSource.Value, value) || _dataSource.Value.Equals(value)))
                    return;
                var oldValue = _dataSource.Value;
                _dataSource.Value = value;
                PropertyHasChanged();
                _changedCallback?.Invoke(this, oldValue, _dataSource.Value);
            }
        }

        /// <summary>
        /// Implicitly casts the property to the value type
        /// </summary>
        /// <param name="source">View model property to cast</param>
        public static implicit operator T(ViewModelProperty<T> source)
        {
            return source.Value;
        }
    }
}
