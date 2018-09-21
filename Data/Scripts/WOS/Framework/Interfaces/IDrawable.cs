#line 2



using System;
using System.Collections.Generic;
using Phoera.Framework.Utils;

namespace Phoera.Framework.Interfaces
{
    public interface IDrawable
    {
        void Draw();
        bool NeedDraw { get; }
        bool NeedSphere { get; }
        ValueChanger<bool> InSphere { get; }
        void Init(AABBTree<IDrawable> tree);
    }
}
