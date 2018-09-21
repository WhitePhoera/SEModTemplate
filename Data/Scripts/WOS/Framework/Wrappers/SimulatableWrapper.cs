#line 2


using System;
using Phoera.Framework.Interfaces;

namespace Phoera.Framework.Wrappers
{
    public class SimulatableWrapper : ISimulatable
    {
        Action action;
        public SimulatableWrapper(Action _action)
        {
            action = _action;
        }

        public void Simulate()
        {
            action();
        }
    }
}
