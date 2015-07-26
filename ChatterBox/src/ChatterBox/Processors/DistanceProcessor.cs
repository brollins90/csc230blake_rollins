namespace ChatterBox.Processors
{
    using System;
    using System.Collections.Generic;
    using Parser;
    using System.Linq;
    using System.Diagnostics;
    using Distance;

    public class DistanceProcessor : IProcessor
    {
        private int _roadCount;
        private List<CityNode> _cities;

        public DistanceProcessor()
        {
            _roadCount = 0;
            _cities = new List<CityNode>();
        }

        public bool TryProcess(ParserTree tree, out string response)
        {
            response = string.Empty;

            if ((tree.HeadNode as VariableNode).Children.First().Type == "DISTANCESTATEMENT")
            {
                string distance = null;
                ParserNode city1 = null;
                ParserNode city2 = null;

                foreach (var f in tree.HeadNode)
                {
                    if (f.Type == "NUMBER")
                    {
                        if (distance == null)
                        {
                            distance = f.ToString();
                        }
                        else
                        {
                            response = "Distance was already set once.  I dont know what to do.";
                            return true;
                        }
                    }
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
                    //Debug.WriteLine($"f: {f.Type} {f.ToString()}");
                }

                var node1 = GetCityNode(city1.ToString());
                var node2 = GetCityNode(city2.ToString());
                node1.AddConnection(node2, double.Parse(distance));
                _roadCount++;

                response = $"Thanks for the information, I know about {_roadCount} roads.  Tell me about yourself.";
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
                    //Debug.WriteLine($"f: {f.Type} {f.ToString()}");
                }

                response = $"The best route between {city1} and {city2} is TBD";
                return true;
            }

            return false;
        }

        private CityNode GetCityNode(string name)
        {

            var node = _cities.FirstOrDefault(x => x.Name.Equals(name));
            if (node == null)
            {
                Debug.WriteLine($"Created new CityNode {name}");
                node = new CityNode(name);
                _cities.Add(node);
            }
            return node;
        }
    }
}