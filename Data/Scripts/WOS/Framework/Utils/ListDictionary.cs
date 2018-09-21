#line 2
using System;
using System.Collections.Generic;
using System.Text;

namespace Phoera.Framework.Utils
{
    public class ListDictionary<TKey, TValue> : Dictionary<TKey, List<TValue>>
    {
        public ListDictionary()
        {

        }
        public ListDictionary(IEqualityComparer<TKey> comparer) : base(comparer)
        {

        }
        public void AddValue(TKey key, TValue value)
        {
            List<TValue> lst;
            if (!TryGetValue(key, out lst))
                this[key] = lst = new List<TValue>();
            lst.Add(value);
        }
        public void AddValueRange(TKey key, IEnumerable<TValue> values)
        {
            List<TValue> lst;
            if (!TryGetValue(key, out lst))
                this[key] = lst = new List<TValue>();
            lst.AddRange(values);
        }
        public bool RemoveByIndex(TKey key, int index)
        {
            List<TValue> lst;
            if (TryGetValue(key,out lst))
            {
                lst.RemoveAt(index);
                return true;
            }
            return false;
        }
        public bool RemoveByItem(TKey key, TValue item)
        {
            List<TValue> lst;
            if (TryGetValue(key, out lst))
            {
                return lst.Remove(item);
            }
            return false;
        }
    }
}
