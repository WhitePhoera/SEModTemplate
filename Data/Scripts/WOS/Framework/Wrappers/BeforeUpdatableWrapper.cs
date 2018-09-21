#line 2


using System;
using Phoera.Framework.Interfaces;

namespace Phoera.Framework.Wrappers
{
    public class BeforeUpdatableWrapper: IBeforeUpdatable
    {
        Action action;
        public BeforeUpdatableWrapper(Action _action)
        {
            action = _action;
        }

        public void UpdateBefore()
        {
            action();
        }
    }
}
