#line 2



using System;
using System.Collections.Generic;

namespace Phoera.Framework.Interfaces
{
    public interface IComponentCollection
    {
        IEnumerable<IComponent> Components { get; }
    }
}
