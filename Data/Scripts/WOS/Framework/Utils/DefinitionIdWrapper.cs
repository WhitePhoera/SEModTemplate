#line 2
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRage.Game;
using VRage.ObjectBuilders;
using VRage.Utils;

namespace Phoera.Framework.Utils
{
    [ProtoContract]
    public struct DefinitionIdWrapper : IEquatable<DefinitionIdWrapper>
    {
        public static implicit operator MyDefinitionId(DefinitionIdWrapper definition)
        {
            return definition.AsId;
        }
        public static implicit operator DefinitionIdWrapper(MyDefinitionId definition)
        {
            return new DefinitionIdWrapper
            {
                Type = definition.TypeId.IsNull ? null : definition.TypeId.ToString(),
                Subtype = definition.SubtypeName
            };
        }
        public static implicit operator SerializableDefinitionId(DefinitionIdWrapper definition)
        {
            return definition.AsSId;
        }
        public static implicit operator DefinitionIdWrapper(SerializableDefinitionId definition)
        {
            return new DefinitionIdWrapper
            {
                Type = definition.TypeId.IsNull ? null : definition.TypeId.ToString(),
                Subtype = definition.SubtypeName
            };
        }

        public static bool operator ==(DefinitionIdWrapper wrapper1, DefinitionIdWrapper wrapper2)
        {
            return wrapper1.Equals(wrapper2);
        }

        public static bool operator !=(DefinitionIdWrapper wrapper1, DefinitionIdWrapper wrapper2)
        {
            return !(wrapper1 == wrapper2);
        }

        [ProtoMember(1)]
        public string Type
        {
            get
            {
                return _type;
            }
            set
            {
                $"Type set: {value}".Log();
                if (value == null)
                {
                    _type = null;
                    _typeHash = 0;
                    return;
                }
                ulong newHash = CoreBase.Instance.StringHasher.GetOrCompute(value);
                if (newHash == _typeHash && _type == value)
                {
                    return;
                }
                _type = value;
                _typeHash = newHash;
            }
        }
        string _type;
        ulong _typeHash;
        [ProtoMember(2)]
        public string Subtype
        {
            get
            {
                return _subtype;
            }
            set
            {
                $"Subtype set: {value}".Log();
                if (value == null)
                {
                    _subtype = null;
                    _subtypeHash = 0;
                    return;
                }
                ulong newHash = CoreBase.Instance.StringHasher.GetOrCompute(value);
                if (newHash == _subtypeHash && _subtype == value)
                {
                    return;
                }
                _subtype = value;
                _subtypeHash = newHash;
            }
        }
        string _subtype;
        ulong _subtypeHash;

        public override string ToString()
        {
            return $"{_type}/{_subtype}";
        }

        public bool IsEmpty
        {
            get
            {
                return _type == null || _subtype == null;
            }
        }

        public readonly static DefinitionIdWrapper Empty = new DefinitionIdWrapper();

        MyDefinitionId AsId
        {
            get
            {
                if (_type == null)
                {
                    return new MyDefinitionId(MyObjectBuilderType.Invalid);
                }
                if (_subtype == null)
                {
                    return new MyDefinitionId(MyObjectBuilderType.Parse(_type));
                }
                return new MyDefinitionId(MyObjectBuilderType.Parse(_type), _subtype);
            }
        }
        SerializableDefinitionId AsSId
        {
            get
            {
                if (_type == null)
                {
                    return new SerializableDefinitionId(MyObjectBuilderType.Invalid, null);
                }
                if (_subtype == null)
                {
                    return new SerializableDefinitionId(MyObjectBuilderType.Parse(_type), null);
                }
                return new SerializableDefinitionId(MyObjectBuilderType.Parse(_type), _subtype);
            }
        }
        public bool Equals(DefinitionIdWrapper other)
        {
            return _typeHash == other._typeHash && _subtypeHash == other._subtypeHash && _type == other._type && _subtype == other._subtype;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
                return true;
            if (!(obj is DefinitionIdWrapper))
            {
                return false;
            }
            var wrapper = (DefinitionIdWrapper)obj;
            return Equals(wrapper);
        }

        public override int GetHashCode()
        {
            var hashCode = -55257672;
            hashCode = hashCode * -1521134295 + _subtypeHash.GetHashCode();
            hashCode = hashCode * -1521134295 + _typeHash.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_type);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_subtype);
            return hashCode;
        }
    }
}
