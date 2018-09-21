#line 2



using System;
using System.Collections.Generic;

namespace Phoera.Framework.Interfaces
{
    public interface IBoundComponent<T>
    {
        T Entity { get; set; }
        void Init();
        void Close();
    }
}
