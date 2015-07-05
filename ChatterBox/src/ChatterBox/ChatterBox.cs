namespace ChatterBox
{
    using System.Collections;
    using System.Collections.Generic;


    public class ChatterBox : IChatterBox
    {
        public enum State
        {
            A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z, STOP
        }

        public string ProcessString(string s)
        {
            var stream = new StringStream(s);

            State currentState = State.A;

            while (stream.MoveNext() && currentState != State.STOP)
            {
                char currentChar = stream.Current;
                switch (currentState)
                {
                    case State.A:
                        switch (currentChar)
                        {
                            case 'E':
                                currentState = State.W;
                                break;
                            case 'H':
                                currentState = State.B;
                                break;
                            default:
                                currentState = State.STOP;
                                break;
                        }
                        break;
                    case State.B:
                        switch (currentChar)
                        {
                            case 'i':
                                currentState = State.C;
                                break;
                            case 'o':
                                currentState = State.D;
                                break;
                            default:
                                currentState = State.STOP;
                                break;
                        }
                        break;
                    case State.C:
                        currentState = State.STOP;
                        break;
                    case State.D:
                        switch (currentChar)
                        {
                            case 'w':
                                currentState = State.E;
                                break;
                            case ' ':
                                currentState = State.Q;
                                break;
                            default:
                                currentState = State.STOP;
                                break;
                        }
                        break;
                    case State.E:
                        switch (currentChar)
                        {
                            case 'd':
                                currentState = State.G;
                                break;
                            case ' ':
                                currentState = State.F;
                                break;
                            default:
                                currentState = State.STOP;
                                break;
                        }
                        break;
                    case State.F:
                        switch (currentChar)
                        {
                            case 'a':
                                currentState = State.I;
                                break;
                            default:
                                currentState = State.STOP;
                                break;
                        }
                        break;
                    case State.G:
                        switch (currentChar)
                        {
                            case 'y':
                                currentState = State.H;
                                break;
                            default:
                                currentState = State.STOP;
                                break;
                        }
                        break;
                    case State.H:
                        currentState = State.STOP;
                        break;
                    case State.I:
                        switch (currentChar)
                        {
                            case 'r':
                                currentState = State.J;
                                break;
                            default:
                                currentState = State.STOP;
                                break;
                        }
                        break;
                    case State.J:
                        switch (currentChar)
                        {
                            case 'e':
                                currentState = State.K;
                                break;
                            default:
                                currentState = State.STOP;
                                break;
                        }
                        break;
                    case State.K:
                        switch (currentChar)
                        {
                            case ' ':
                                currentState = State.L;
                                break;
                            default:
                                currentState = State.STOP;
                                break;
                        }
                        break;
                    case State.L:
                        switch (currentChar)
                        {
                            case 'y':
                                currentState = State.M;
                                break;
                            default:
                                currentState = State.STOP;
                                break;
                        }
                        break;
                    case State.M:
                        switch (currentChar)
                        {
                            case 'o':
                                currentState = State.N;
                                break;
                            default:
                                currentState = State.STOP;
                                break;
                        }
                        break;
                    case State.N:
                        switch (currentChar)
                        {
                            case 'u':
                                currentState = State.O;
                                break;
                            default:
                                currentState = State.STOP;
                                break;
                        }
                        break;
                    case State.O:
                        switch (currentChar)
                        {
                            case '?':
                                currentState = State.P;
                                break;
                            default:
                                currentState = State.STOP;
                                break;
                        }
                        break;
                    case State.P:
                        currentState = State.STOP;
                        break;
                    case State.Q:
                        switch (currentChar)
                        {
                            case 'h':
                                currentState = State.R;
                                break;
                            default:
                                currentState = State.STOP;
                                break;
                        }
                        break;
                    case State.R:
                        switch (currentChar)
                        {
                            case 'o':
                                currentState = State.S;
                                break;
                            default:
                                currentState = State.STOP;
                                break;
                        }
                        break;
                    case State.S:
                        switch (currentChar)
                        {
                            case ' ':
                                currentState = State.T;
                                break;
                            default:
                                currentState = State.STOP;
                                break;
                        }
                        break;
                    case State.T:
                        switch (currentChar)
                        {
                            case 'h':
                                currentState = State.U;
                                break;
                            default:
                                currentState = State.STOP;
                                break;
                        }
                        break;
                    case State.U:
                        switch (currentChar)
                        {
                            case 'o':
                                currentState = State.V;
                                break;
                            default:
                                currentState = State.STOP;
                                break;
                        }
                        break;
                    case State.V:
                        currentState = State.STOP;
                        break;
                    case State.W:
                        switch (currentChar)
                        {
                            case 'x':
                                currentState = State.X;
                                break;
                            default:
                                currentState = State.STOP;
                                break;
                        }
                        break;
                    case State.X:
                        switch (currentChar)
                        {
                            case 'i':
                                currentState = State.Y;
                                break;
                            default:
                                currentState = State.STOP;
                                break;
                        }
                        break;
                    case State.Y:
                        switch (currentChar)
                        {
                            case 't':
                                currentState = State.Z;
                                break;
                            default:
                                currentState = State.STOP;
                                break;
                        }
                        break;
                    case State.Z:
                        currentState = State.STOP;
                        break;
                    default:
                        currentState = State.STOP;
                        break;
                }
            }

            // end
            string responseString = string.Empty;
            switch (currentState)
            {
                case State.C:
                    responseString = "Hello";
                    break;
                case State.H:
                    responseString = "Let's ride buckaroo!";
                    break;
                case State.P:
                    responseString = "Fine, and you?";
                    break;
                case State.V:
                    responseString = "Who do you think you are, Santa?";
                    break;
                case State.Z:
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
