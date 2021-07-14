namespace CodeSnippets
{
    /// <summary>
    /// View Model Property Callback delegates
    /// </summary>
    public static class ViewModelPropertyCallbacks
    {
        /// <summary>
        /// Property changed callback
        /// </summary>
        public delegate void Changed1();

        /// <summary>
        /// Property changed callback
        /// </summary>
        /// <param name="property">Property which invoked the callback</param>
        public delegate void Changed2<T>(ViewModelProperty<T> property);

        /// <summary>
        /// Proeprty changed callback
        /// </summary>
        /// <param name="property">Property which invoked the callback</param>
        /// <param name="oldValue">Old value</param>
        /// <param name="newValue">New value</param>
        public delegate void Changed3<T>(ViewModelProperty<T> property, T oldValue, T newValue);

        /// <summary>
        /// Proeprty changed callback
        /// </summary>
        /// <param name="oldValue">Old value</param>
        /// <param name="newValue">New value</param>
        public delegate void Changed4<T>(T oldValue, T newValue);
    }
}
