using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HashTable
{
    public class OpenAddressHashTable<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>, IHashTable<TKey, TValue> where TKey : IEquatable<TKey>
    {
        Pair<TKey, TValue>[] _table;
        private int _capacity;
        HashMaker<TKey> _hashMaker1, _hashMaker2;
        public int Count { get; private set; }
        private const double FillFactor = 0.65;
        private readonly GetPrimeNumber _primeNumber = new GetPrimeNumber();
        

        public OpenAddressHashTable()
        {
            _capacity = _primeNumber.GetMin();
            _table = new Pair<TKey, TValue>[_capacity];
            _hashMaker1 = new HashMaker<TKey>(_capacity);
            _hashMaker2 = new HashMaker<TKey>(_capacity - 1);
            Count = 0;
        }
        public OpenAddressHashTable(int m)
        {
            _table = new Pair<TKey, TValue>[m];
            _capacity = m;
            _hashMaker1 = new HashMaker<TKey>(_capacity);
            _hashMaker2 = new HashMaker<TKey>(_capacity - 1);
            Count = 0;
        }
        public void Add(TKey key, TValue value)
        {
            var hash = _hashMaker1.ReturnHash(key);

            if (!TryToPut(hash, key, value)) // ячейка занята
            {
                int iterationNumber = 1;
                int hash2 = _hashMaker2.ReturnHash(key);
                while (true)
                {
                    var place = (hash + iterationNumber * (1 + hash2)) % _capacity;
                    if (TryToPut(place, key, value))
                        break;
                    iterationNumber++;
                    if (iterationNumber >= _capacity)
                        throw new ApplicationException("HashTable full!!!");
                }
            }
            if ((double)Count / _capacity >= FillFactor)
            {
                IncreaseTable();
            }
        }

        private bool TryToPut(int place, TKey key, TValue value)
        {
            if (_table[place] == null || _table[place].IsDeleted())
            {
                _table[place] = new Pair<TKey, TValue>(key, value);
                Count++;
                return true;
            }
            if (_table[place].Key.Equals(key))
            {
                throw new ArgumentException();
            }
            return false;
        }

        private Pair<TKey, TValue> Find(TKey x)
        {
            var hash = _hashMaker1.ReturnHash(x);
            if (_table[hash] == null)
                return null;
            if (!_table[hash].IsDeleted() && _table[hash].Key.Equals(x))
            { 
                return _table[hash];

            }
            int iterationNumber = 1;
            while (true)
            {
                var place = (hash + iterationNumber * (1 + _hashMaker2.ReturnHash(x))) % _capacity;
                if (_table[place] == null)
                    return null;
                if (!_table[place].IsDeleted() && _table[place].Key.Equals(x))
                { 
                    return _table[place];
                }
                iterationNumber++;
                if (iterationNumber >= _capacity)
                    return null;
            }
        }
        public TValue this[TKey key]
        {
            get
            {
                var pair = Find(key);
                if (pair == null)
                    throw new KeyNotFoundException();
                return pair.Value;
            }

            set
            {
                var pair = Find(key);
                if (pair == null)
                    throw new KeyNotFoundException();
                pair.Value = value;
            }
        }

       

       

        public bool ContainsKey(TKey key)
        {
            return Find(key) != null;
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return (from pair in _table where pair != null && !pair.IsDeleted() select new KeyValuePair<TKey, TValue>(pair.Key, pair.Value)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool Remove(TKey x)
        {
            var find = Find(x);
            if (find != null)
            {
               
                find.DeletePair();
                Count--;
                return true;
            }
            return false;

            //    var item = Find(x);
            //    if (item != null)
            //    {
            //        Count--;
            //        return true;
            //    }
            //    else
            //    {
            //        //исключение что нет такого элемента
            //        return false;
            //    }       
            //}
        }
        private void IncreaseTable()
        {
            _capacity = _primeNumber.Next();


            _hashMaker1.SimpleNumber = _capacity;
            _hashMaker2.SimpleNumber = _capacity - 1;
            var newTable = _table;
            _table = new Pair<TKey, TValue>[_capacity];
            Count = 0;
            foreach (var pair in newTable)
            {
                if (pair != null && !pair.IsDeleted())
                    Add(pair.Key, pair.Value);
            }
        }

        //     _capacity = _primeNumber.Next();
        //    var _Newtable = new Pair<TKey, TValue>[_capacity];
        //    var _NewhashMaker1 = new HashMaker<TKey>(_capacity);
        //    var _NewhashMaker2 = new HashMaker<TKey>(_capacity - 1);
        //    _hashMaker1=_NewhashMaker1;
        //    _hashMaker2 = _NewhashMaker2;
        //    CopyOldTableInNew(_Newtable);
        //}
        //private void CopyOldTableInNew(Pair<TKey, TValue>[] _newtable)
        //{
        //    foreach(var item in _table)
        //    {
        //        if (item == null)
        //        {
        //            continue;
        //        }
        //        if (item.IsDeleted())
        //        {
        //            continue;
        //        }
        //        else
        //        {
        //            var hash = _hashMaker1.ReturnHash(item.Key);
        //            int iterationNumber = 1;
        //            while (_newtable[hash] != null)
        //            {
        //                hash = (hash + iterationNumber * (1 + _hashMaker2.ReturnHash(item.Key))) % _capacity;
        //            }
        //            _newtable[hash] = item;
        //        }
        //    }
        //    _table = _newtable;
        //}



    }
}
