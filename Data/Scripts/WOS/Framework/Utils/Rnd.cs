#line 2
using ProtoBuf;
using System.Collections.Generic;
using VRage.Library.Utils;

/// <summary>
/// This file is free to learn, but you still cannot copy it or use it parts without my permission.
/// Copyright - Phoera - 2016
/// </summary>
namespace Phoera.Framework.Utils
{
    [ProtoContract]
    public class Rnd
    {
        static Rnd rnd = new Rnd((ulong)MyRandom.Instance.NextLong(),(ulong)MyRandom.Instance.NextLong());

        ulong _x;
        ulong _y;
        const ulong MAX = ulong.MaxValue;

        [ProtoMember(0)]
        public ulong X
        {
            get
            {
                return _x;
            }

            set
            {
                _x = value;
            }
        }
        [ProtoMember(1)]
        public ulong Y
        {
            get
            {
                return _y;
            }

            set
            {
                _y = value;
            }
        }

        public Rnd()
        {
            lock (rnd)
            {
                _x = rnd.Next();
                _y = rnd.Next();
            }
        }

        public Rnd(ulong x, ulong y)
        {
            _y = y;
            _x = x;
        }

        ulong Sample()
        {
            ulong x = _x;
            ulong y = _y;
            _x = y;
            x ^= x << 23;
            _y = x ^ y ^ (x >> 17) ^ (y >> 26);
            return _y + y;
        }

        public double NextDouble()
        {
            return Sample() * (1.0 / MAX);
        }

        public ulong Next()
        {
            return Sample();
        }
        public int Next(int minValue, int maxValue)
        {
            long range = (long)maxValue - minValue;
            return ((int)(NextDouble() * range) + minValue);
        }

        public int Next(int maxValue)
        {
            if (maxValue < 0)
                return maxValue;
            return (int)(NextDouble() * maxValue);
        }
        public T Get<T>(T[] array)
        {
            return array[Next(array.Length)];
        }
        public T Get<T>(IList<T> collection)
        {
            return collection[Next(collection.Count)];
        }
    }
}
