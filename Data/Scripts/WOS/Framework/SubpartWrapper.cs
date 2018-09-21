#line 2
using System.Collections.Generic;
using VRage.Game.ModAPI;
using VRage.ModAPI;
using VRageMath;

namespace Phoera.Framework
{
    public class SubpartWrapper
    {
        public IMyEntity Parent { get; set; }
        public IMyEntity Subpart { get; set; }
        public string SearchExpression { get; set; }
        public string Name { get; set; }
        public Matrix Origin { get; set; }

        Dictionary<string, DummyWrapper> dummies;
        public Dictionary<string, DummyWrapper> Dummies
        {
            get
            {
                if (dummies == null)
                {
                    dummies = new Dictionary<string, DummyWrapper>();
                    var dict = new Dictionary<string, IMyModelDummy>();
                    Subpart.Model.GetDummies(dict);
                    foreach (var dum in dict)
                    {
                        dummies.Add(dum.Key, new DummyWrapper() { Dummy = dum.Value, Parent = this });
                    }
                }
                return dummies;
            }
        }
    }
}

