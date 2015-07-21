//namespace ChatterBox
//{
//    using System.Collections;
//    using System.Collections.Generic;

//    public class StringStream : IEnumerator<char>
//    {
//        private string _innerString;
//        private int _stringLength;
//        private int _index;

//        public StringStream(string s)
//        {
//            _innerString = s;
//            _stringLength = s.Length;
//            _index = -1;
//        }

//        public char Current => _innerString[_index];

//        object IEnumerator.Current => Current;

//        public void Dispose() { }

//        public bool MoveNext()
//        {
//            _index++;
//            return (_index < _stringLength);
//        }

//        public void Reset()
//        {
//            _index = 0;
//        }
//    }
//}
