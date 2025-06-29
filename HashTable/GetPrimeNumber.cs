using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    internal class GetPrimeNumber
    {
        private int _current;
        readonly int[] _primesnumbers = { 61, 127, 257, 523, 1087,
            2213, 4519, 9619, 19717, 40009, 62851, 75431, 90523,
            108631, 130363, 156437,  187751, 225307, 270371, 324449,
            389357, 467237, 560689, 672827, 807403, 968897,
            1162687, 1395263, 1674319, 2009191, 2411033, 2893249, 3471899, 4166287,
            4999559, 5999471, 7199369};

        //public int Next (int twoocapacity)
        //{
        //    while (_primesnumbers[_current] < twoocapacity)
        //    {
        //        _current++;
        //    }
        //    var value = _primesnumbers[_current];
        //    return value;
        //}
        public int Next()
        {
            if (_current < _primesnumbers.Length)
            {
                _current++;
               
                return _primesnumbers[_current]; 
            }
            _current++;
            return (_current - _primesnumbers.Length) * _primesnumbers[_primesnumbers.Length - 1];
        }
        public int GetMin()
        {
            _current = 0;
            return _primesnumbers[_current];
        }
    }
}
