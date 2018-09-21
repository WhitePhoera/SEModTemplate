#line 2

using System;
using Phoera.Framework.Interfaces;

namespace Phoera.Framework.Wrappers
{
    public class TemporalAction:ITemporal
    {
        Action action;

        public ulong LifeTime { get; }

        public TemporalAction(ulong _life, Action _action)
        {
            LifeTime = _life;
            action = _action;
        }

        public void Expired()
        {
            action();
        }
    }
}
