using System;
using System.Collections;
using System.Collections.Generic;

namespace ChatterBox
{
    public class Symbolizer : ISymbolizer
    {
        List<string> _stringList;
        int _index;


        public Symbolizer(string input)
        {
            string[] s = input.Split(' ');
            _stringList = new List<string>(s);
            _index = -1;
        }

        public string Current() => _stringList[_index];
        object IEnumerator.Current => Current();

        string IEnumerator<string>.Current => Current();

        public string LookAhead()
        {
            if (_index + 1 < _stringList.Count)
            {
                return _stringList[_index + 1];
            }
            return "";

        }

        public void Dispose() { }

        public bool MoveNext()
        {
            return ++_index < _stringList.Count;
        }

        public void Reset()
        {
            _index = -1;
        }
    }
}
