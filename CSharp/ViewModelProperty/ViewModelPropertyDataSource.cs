using System;
using System.Linq.Expressions;
using System.Reflection;

namespace CodeSnippets
{
    /// <summary>
    /// View model property data source
    /// </summary>
    /// <typeparam name="T">Data type</typeparam>
    public abstract class ViewModelPropertyDataSource<T>
    {
        /// <summary>
        /// Gets or sets the data value
        /// </summary>
        public abstract T Value { get; set; }

        /// <summary>
        /// Creates the default data source
        /// </summary>
        /// <returns>View model property data source</returns>
        public static ViewModelPropertyDataSource<T> Default()
        {
            return new DataBacking();
        }

        /// <summary>
        /// Creates data source based on a property or field from another object
        /// </summary>
        /// <typeparam name="TObject">Other object type</typeparam>
        /// <param name="o">Other object</param>
        /// <param name="expression">Accessor expression</param>
        /// <returns>View model property data source</returns>
        public static ViewModelPropertyDataSource<T> Create<TObject>(TObject o, Expression<Func<TObject, T>> expression)
        {
            var member = expression.Body as MemberExpression;
            if (member == null)
                throw new ArgumentException("Expected a MemberExpression", nameof(expression));

            var property = member.Member as PropertyInfo;
            if (property != null)
                return new PropertyBacking<TObject>(o, property);

            var field = member.Member as FieldInfo;
            if (field != null)
                return new FieldBacking<TObject>(o, field);

            throw new InvalidOperationException("Unexpected expression");
        }


        private class DataBacking : ViewModelPropertyDataSource<T>
        {
            private T _value;

            public DataBacking()
            {
                _value = default(T);
            }

            public override T Value { get => _value; set => _value = value; }
        }

        private class PropertyBacking<TParent> : ViewModelPropertyDataSource<T>
        {
            private readonly TParent _parent;
            private readonly PropertyInfo _property;

            public override T Value { get => GetValue(); set => SetValue(value); }

            public PropertyBacking(TParent parent, PropertyInfo property)
            {
                _parent = parent;
                _property = property;
            }

            private void SetValue(T value)
            {
                _property.SetValue(_parent, value);
            }

            private T GetValue()
            {
                return (T)_property.GetValue(_parent);
            }
        }

        private class FieldBacking<TParent> : ViewModelPropertyDataSource<T>
        {
            private readonly TParent _parent;
            private readonly FieldInfo _field;

            public override T Value { get => GetValue(); set => SetValue(value); }

            public FieldBacking(TParent parent, FieldInfo field)
            {
                _parent = parent;
                _field = field;
            }

            private void SetValue(T value)
            {
                _field.SetValue(_parent, value);
            }

            private T GetValue()
            {
                return (T)_field.GetValue(_parent);
            }
        }
    }
}
