#line 2
using System;
using VRage;

namespace Phoera.Framework.Utils
{
    public class Lazy<T> : IDisposable
    {
        volatile bool _initialized = false;
        T _value;
        System.Func<T> _factory;
        FastResourceLock _locker = new FastResourceLock();

        public Lazy(System.Func<T> factory)
        {
            _factory = factory;
        }
        public T Value
        {
            get
            {
                if (!_initialized)
                {
                    using(_locker.AcquireExclusiveUsing())
                    {
                        if (!_initialized)
                        {
                            _value = _factory();
                            _initialized = true;
                            CoreBase.Register(this);
                        }
                    }
                }
                return _value;
            }
        }

        public void Dispose()
        {
            _locker.Dispose();
        }
    }
}
