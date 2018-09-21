#line 2
using System.Linq;
using VRage.Game.ModAPI;
using VRageMath;

namespace Phoera.Framework
{
    public class DummyWrapper
    {
        public SubpartWrapper Parent { get; set; }
        public IMyModelDummy Dummy { get; set; }
        string numberlessName;
        int number;
        public string Name
        {
            get
            {
                return Dummy.Name;
            }
        }
        public string NumberlessName
        {
            get
            {
                if (numberlessName == null)
                {
                    numberlessName = string.Join("", Dummy.Name.Where(c => !char.IsDigit(c)));
                    var numberName = string.Join("", Dummy.Name.Where(char.IsDigit));
                    int.TryParse(numberName, out number);
                }
                return numberlessName;
            }
        }
        public int Number
        {
            get
            {
                if (numberlessName == null)
                {
                    numberlessName = string.Join("", Dummy.Name.Where(c => !char.IsDigit(c)));
                    var numberName = string.Join("", Dummy.Name.Where(char.IsDigit));
                    int.TryParse(numberName, out number);
                }
                return number;
            }
        }
        public MatrixD Matrix
        {
            get
            {
                return Dummy.Matrix * Parent.Subpart.WorldMatrix;
            }
        }
    }
}

