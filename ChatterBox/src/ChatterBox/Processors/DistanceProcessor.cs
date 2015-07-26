namespace ChatterBox.Processors
{
    using System;
    using System.Collections.Generic;
    using Parser;
    using System.Linq;
    using System.Diagnostics;

    public class DistanceProcessor : IProcessor
    {
        private int _distances;

        public bool TryProcess(ParserTree tree, out string response)
        {
            response = string.Empty;

            if ((tree.HeadNode as VariableNode).Children.First().Type == "DISTANCESTATEMENT")
            {
                _distances++;
                response = $"Thanks for the information, I know about {_distances} roads.  Tell me about yourself.";
                return true;
            }

            if ((tree.HeadNode as VariableNode).Children.First().Type == "DISTANCEQUESTION")
            {
                ParserNode city1 = null;
                ParserNode city2 = null;

                foreach (var f in tree.HeadNode)
                {
                    if (f.Type == "CITY")
                    {
                        if (city1 == null)
                        {
                            city1 = f;
                        }
                        else
                        {
                            if (city2 == null)
                            {
                                city2 = f;
                            }
                            else
                            {
                                response = "Sorry i dont know what to do with 3 cities.";
                                return true;
                            }
                        }
                    }
                    Debug.WriteLine($"f: {f.Type} {f.ToString()}");
                }

                response = $"The best route between {city1} and {city2} is TBD";
                return true;
            }

            return false;
        }
    }
}