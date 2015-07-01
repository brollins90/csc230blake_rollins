namespace ChatterBox
{
    using System.Collections;
    using System.Collections.Generic;

    public class ChatterBox : IChatterBox
    {
        public string Input(string s)
        {
            var stream = new StringStream(s);

            char currentState = 'A';

            while (stream.MoveNext())
            {
                char currentChar = stream.Current;
                switch (currentState)
                {
                    case 'A':
                        switch (currentChar)
                        {
                            case 'E':
                                currentState = 'W';
                                break;
                            case 'H':
                                currentState = 'B';
                                break;
                            default:
                                currentState = 'A';
                                break;
                        }
                        break;
                    case 'B':
                        switch (currentChar)
                        {
                            case 'i':
                                currentState = 'C';
                                break;
                            case 'o':
                                currentState = 'D';
                                break;
                            case 'E':
                                currentState = 'W';
                                break;
                            case 'H':
                                currentState = 'B';
                                break;
                            default:
                                currentState = 'A';
                                break;
                        }
                        break;
                    case 'C':
                        switch (currentChar)
                        {
                            case 'E':
                                currentState = 'W';
                                break;
                            case 'H':
                                currentState = 'B';
                                break;
                            default:
                                currentState = 'A';
                                break;
                        }
                        break;
                    case 'D':
                        switch (currentChar)
                        {
                            case 'w':
                                currentState = 'E';
                                break;
                            case ' ':
                                currentState = 'Q';
                                break;
                            case 'E':
                                currentState = 'W';
                                break;
                            case 'H':
                                currentState = 'B';
                                break;
                            default:
                                currentState = 'A';
                                break;
                        }
                        break;
                    case 'E':
                        switch (currentChar)
                        {
                            case 'd':
                                currentState = 'G';
                                break;
                            case ' ':
                                currentState = 'F';
                                break;
                            case 'E':
                                currentState = 'W';
                                break;
                            case 'H':
                                currentState = 'B';
                                break;
                            default:
                                currentState = 'A';
                                break;
                        }
                        break;
                    case 'F':
                        switch (currentChar)
                        {
                            case 'a':
                                currentState = 'I';
                                break;
                            case 'E':
                                currentState = 'W';
                                break;
                            case 'H':
                                currentState = 'B';
                                break;
                            default:
                                currentState = 'A';
                                break;
                        }
                        break;
                    case 'G':
                        switch (currentChar)
                        {
                            case 'y':
                                currentState = 'H';
                                break;
                            case 'E':
                                currentState = 'W';
                                break;
                            case 'H':
                                currentState = 'B';
                                break;
                            default:
                                currentState = 'A';
                                break;
                        }
                        break;
                    case 'H':
                        switch (currentChar)
                        {
                            case 'E':
                                currentState = 'W';
                                break;
                            case 'H':
                                currentState = 'B';
                                break;
                            default:
                                currentState = 'A';
                                break;
                        }
                        break;
                    case 'I':
                        switch (currentChar)
                        {
                            case 'r':
                                currentState = 'J';
                                break;
                            case 'E':
                                currentState = 'W';
                                break;
                            case 'H':
                                currentState = 'B';
                                break;
                            default:
                                currentState = 'A';
                                break;
                        }
                        break;
                    case 'J':
                        switch (currentChar)
                        {
                            case 'e':
                                currentState = 'K';
                                break;
                            case 'E':
                                currentState = 'W';
                                break;
                            case 'H':
                                currentState = 'B';
                                break;
                            default:
                                currentState = 'A';
                                break;
                        }
                        break;
                    case 'K':
                        switch (currentChar)
                        {
                            case ' ':
                                currentState = 'L';
                                break;
                            case 'E':
                                currentState = 'W';
                                break;
                            case 'H':
                                currentState = 'B';
                                break;
                            default:
                                currentState = 'A';
                                break;
                        }
                        break;
                    case 'L':
                        switch (currentChar)
                        {
                            case 'y':
                                currentState = 'M';
                                break;
                            case 'E':
                                currentState = 'W';
                                break;
                            case 'H':
                                currentState = 'B';
                                break;
                            default:
                                currentState = 'A';
                                break;
                        }
                        break;
                    case 'M':
                        switch (currentChar)
                        {
                            case 'o':
                                currentState = 'N';
                                break;
                            case 'E':
                                currentState = 'W';
                                break;
                            case 'H':
                                currentState = 'B';
                                break;
                            default:
                                currentState = 'A';
                                break;
                        }
                        break;
                    case 'N':
                        switch (currentChar)
                        {
                            case 'u':
                                currentState = 'O';
                                break;
                            case 'E':
                                currentState = 'W';
                                break;
                            case 'H':
                                currentState = 'B';
                                break;
                            default:
                                currentState = 'A';
                                break;
                        }
                        break;
                    case 'O':
                        switch (currentChar)
                        {
                            case '?':
                                currentState = 'P';
                                break;
                            case 'E':
                                currentState = 'W';
                                break;
                            case 'H':
                                currentState = 'B';
                                break;
                            default:
                                currentState = 'A';
                                break;
                        }
                        break;
                    case 'P':
                        switch (currentChar)
                        {
                            case 'E':
                                currentState = 'W';
                                break;
                            case 'H':
                                currentState = 'B';
                                break;
                            default:
                                currentState = 'A';
                                break;
                        }
                        break;
                    case 'Q':
                        switch (currentChar)
                        {
                            case 'h':
                                currentState = 'R';
                                break;
                            case 'E':
                                currentState = 'W';
                                break;
                            case 'H':
                                currentState = 'B';
                                break;
                            default:
                                currentState = 'A';
                                break;
                        }
                        break;
                    case 'R':
                        switch (currentChar)
                        {
                            case 'o':
                                currentState = 'S';
                                break;
                            case 'E':
                                currentState = 'W';
                                break;
                            case 'H':
                                currentState = 'B';
                                break;
                            default:
                                currentState = 'A';
                                break;
                        }
                        break;
                    case 'S':
                        switch (currentChar)
                        {
                            case ' ':
                                currentState = 'T';
                                break;
                            case 'E':
                                currentState = 'W';
                                break;
                            case 'H':
                                currentState = 'B';
                                break;
                            default:
                                currentState = 'A';
                                break;
                        }
                        break;
                    case 'T':
                        switch (currentChar)
                        {
                            case 'h':
                                currentState = 'U';
                                break;
                            case 'E':
                                currentState = 'W';
                                break;
                            case 'H':
                                currentState = 'B';
                                break;
                            default:
                                currentState = 'A';
                                break;
                        }
                        break;
                    case 'U':
                        switch (currentChar)
                        {
                            case 'o':
                                currentState = 'V';
                                break;
                            case 'E':
                                currentState = 'W';
                                break;
                            case 'H':
                                currentState = 'B';
                                break;
                            default:
                                currentState = 'A';
                                break;
                        }
                        break;
                    case 'V':
                        switch (currentChar)
                        {
                            case 'E':
                                currentState = 'W';
                                break;
                            case 'H':
                                currentState = 'B';
                                break;
                            default:
                                currentState = 'A';
                                break;
                        }
                        break;
                    case 'W':
                        switch (currentChar)
                        {
                            case 'x':
                                currentState = 'X';
                                break;
                            case 'E':
                                currentState = 'W';
                                break;
                            case 'H':
                                currentState = 'B';
                                break;
                            default:
                                currentState = 'A';
                                break;
                        }
                        break;
                    case 'X':
                        switch (currentChar)
                        {
                            case 'i':
                                currentState = 'Y';
                                break;
                            case 'E':
                                currentState = 'W';
                                break;
                            case 'H':
                                currentState = 'B';
                                break;
                            default:
                                currentState = 'A';
                                break;
                        }
                        break;
                    case 'Y':
                        switch (currentChar)
                        {
                            case 't':
                                currentState = 'Z';
                                break;
                            case 'E':
                                currentState = 'W';
                                break;
                            case 'H':
                                currentState = 'B';
                                break;
                            default:
                                currentState = 'A';
                                break;
                        }
                        break;
                    case 'Z':
                        currentState = 'Z';
                        break;
                    default:
                        currentState = 'A';
                        break;

                }
            }

            // end
            string responseString = string.Empty;
            switch (currentState)
            {
                case 'C':
                    responseString = "Hello";
                    break;
                case 'H':
                    responseString = "Let's ride buckaroo!";
                    break;
                case 'P':
                    responseString = "Fine, and you?";
                    break;
                case 'V':
                    responseString = "Who do you think you are, Santa?";
                    break;
                case 'Z':
                    responseString = "Bye!";
                    break;
                default:
                    responseString = "Tell me about yourself";
                    break;
            }

            return responseString;
        }

    }

    public class StringStream : IEnumerator<char>
    {
        private string _innerString;
        private int _stringLength;
        private int _index;

        public StringStream(string s)
        {
            _innerString = s;
            _stringLength = s.Length;
            _index = -1;
        }

        public char Current => _innerString[_index];

        object IEnumerator.Current => Current;

        public void Dispose() { }

        public bool MoveNext()
        {
            _index++;
            return (_index < _stringLength);
        }

        public void Reset()
        {
            _index = 0;
        }
    }
}
