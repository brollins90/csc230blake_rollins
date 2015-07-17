namespace ChatterBox
{
    using System.Collections;
    using System.Collections.Generic;


    public class ChatterBox : IChatterBox
    {
        public enum State
        {
            A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z, AA, AB, STOP
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
                        currentState =
                            (currentChar == 'E') ? State.B :
                            (currentChar == 'H') ? State.F :
                            State.STOP;
                        break;
                    case State.B:
                        currentState =
                            (currentChar == 'x') ? State.C :
                            State.STOP;
                        break;
                    case State.C:
                        currentState =
                            (currentChar == 'i') ? State.D :
                            State.STOP;
                        break;
                    case State.D:
                        currentState =
                            (currentChar == 't') ? State.E :
                            State.STOP;
                        break;
                    case State.E:
                        currentState = State.STOP;
                        break;
                    case State.F:
                        currentState =
                            (currentChar == 'e') ? State.G :
                            (currentChar == 'o') ? State.K :
                            State.STOP;
                        break;
                    case State.G:
                        currentState =
                            (currentChar == 'l') ? State.H :
                            State.STOP;
                        break;
                    case State.H:
                        currentState =
                            (currentChar == 'l') ? State.I :
                            State.STOP;
                        break;
                    case State.I:
                        currentState =
                            (currentChar == 'o') ? State.J :
                            State.STOP;
                        break;
                    case State.J:
                        currentState =
                            (currentChar == 'o') ? State.J :
                            State.STOP;
                        break;
                    case State.K:
                        currentState =
                            (currentChar == ' ') ? State.L :
                            (currentChar == 'w') ? State.O :
                            State.STOP;
                        break;
                    case State.L:
                        currentState =
                            (currentChar == 'h') ? State.M :
                            State.STOP;
                        break;
                    case State.M:
                        currentState =
                            (currentChar == 'o') ? State.N :
                            State.STOP;
                        break;
                    case State.N:
                        currentState =
                            (currentChar == ' ') ? State.L :
                            State.STOP;
                        break;
                    case State.O:
                        currentState =
                            (currentChar == ' ') ? State.R :
                            (currentChar == 'd') ? State.P :
                            State.STOP;
                        break;
                    case State.P:
                        currentState =
                            (currentChar == 'y') ? State.Q :
                            State.STOP;
                        break;
                    case State.Q:
                        currentState = State.STOP;
                        break;
                    case State.R:
                        currentState =
                            (currentChar == 'd') ? State.S :
                            State.STOP;
                        break;
                    case State.S:
                        currentState =
                            (currentChar == 'o') ? State.T :
                            State.STOP;
                        break;
                    case State.T:
                        currentState =
                            (currentChar == ' ') ? State.U :
                            State.STOP;
                        break;
                    case State.U:
                        currentState =
                            (currentChar == 'y') ? State.V :
                            State.STOP;
                        break;
                    case State.V:
                        currentState =
                            (currentChar == 'o') ? State.W :
                            State.STOP;
                        break;
                    case State.W:
                        currentState =
                            (currentChar == 'u') ? State.X :
                            State.STOP;
                        break;
                    case State.X:
                        currentState =
                            (currentChar == ' ') ? State.Y :
                            State.STOP;
                        break;
                    case State.Y:
                        currentState =
                            (currentChar == 'd') ? State.Z :
                            State.STOP;
                        break;
                    case State.Z:
                        currentState =
                            (currentChar == 'o') ? State.AA :
                            State.STOP;
                        break;
                    case State.AA:
                        currentState =
                            (currentChar == '?') ? State.AB :
                            State.STOP;
                        break;
                    case State.AB:
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
                case State.E:
                    responseString = "Bye!";
                    break;
                case State.J:
                    responseString = "Hi";
                    break;
                case State.K:
                case State.N:
                    responseString = "You must be quite the jolly person";
                    break;
                case State.Q:
                    responseString = "Let's Ride!";
                    break;
                case State.AB:
                    responseString = "I do fine, and you?";
                    break;
                default:
                    responseString = "Tell me about yourself";
                    break;
            }
            return responseString;
        }

    }
}
