#line 2


using System;
using Phoera.Framework.Interfaces;

namespace Phoera.Framework.Wrappers
{
    public class AfterUpdatableWrapper : IAfterUpdatable
    {
        Action action;
        public AfterUpdatableWrapper(Action _action)
        {
            action = _action;
        }

        public void UpdateAfter()
        {
            action();
        }
    }
}
