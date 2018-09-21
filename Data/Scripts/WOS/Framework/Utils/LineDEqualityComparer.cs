#line 2
using System.Collections.Generic;
using VRageMath;

namespace Phoera.Framework.Utils
{
    class LineDEqualityComparer : IEqualityComparer<LineD>
    {
        public bool Equals(LineD x, LineD y)
        {
            return x.From == y.From && x.To == y.To;
        }

        public int GetHashCode(LineD obj)
        {
            return obj.GetHashCode();
        }
        private LineDEqualityComparer()
        {

        }
        static LineDEqualityComparer instance = new LineDEqualityComparer();
        public static LineDEqualityComparer Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
