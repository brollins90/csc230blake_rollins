namespace ChatterBox.Processors.Distance
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    public class CityNode
    {
        public List<Edge> Connections { get; }
        public string Name { get; }

        public CityNode(string name)
        {
            Connections = new List<Edge>();
            Name = name;
        }

        public void AddConnection(CityNode otherCity, double distance)
        {
            AddConnectionLocal(otherCity, distance);
            otherCity.AddConnectionLocal(this, distance);
        }

        private void AddConnectionLocal(CityNode otherCity, double distance)
        {
            if (!Connections.Any(x => x.ToCity.Equals(otherCity)))
            {
                Debug.WriteLine($"Adding connection from {this} to {otherCity}");
                Connections.Add(new Edge(otherCity, this, distance));
            }
            else
            {
                Debug.WriteLine($"NOT adding connection from {this} to {otherCity}, already exists");
            }
        }

        public override string ToString() => Name;
    }
}