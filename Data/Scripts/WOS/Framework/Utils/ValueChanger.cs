#line 2
using System;
using System.Collections.Generic;

namespace Phoera.Framework.Utils
{
    public class ValueChanger<T>
    {
        T _value;
        public T Value
        {
            get
            { return _value; }
            set
            {
                if (comparer.Equals(_value, value))
                    return;
                _value = value;
                Changed?.Invoke(_value);
            }
        }

        readonly IEqualityComparer<T> comparer;

        public ValueChanger(T value = default(T), IEqualityComparer<T> comparer = null)
        {
            this.comparer = comparer ?? EqualityComparer<T>.Default;
            _value = value;
        }

        public event Action<T> Changed;

        public static implicit operator T(ValueChanger<T> t)
        {
            return t._value;
        }
    }
}
