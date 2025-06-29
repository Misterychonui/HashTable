using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    internal interface IHashTable<in TKey, in TValue>
    {
        void Add(TKey x, TValue y);
        bool Remove(TKey x);
        bool ContainsKey(TKey x);
    }

    public interface IHash<in TKey>
    {
        int GetHash(TKey key, int i = 0);
    }
}
