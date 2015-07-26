namespace ChatterBox.Processors.Distance
{
    using System;
    using System.Collections.Generic;

    public class Edge
    {
        private CityNode FromCity { get; set; }
        public CityNode ToCity { get; set; }
        public double Distance { get; set; }

        public Edge(CityNode to, CityNode from, double distance)
        {
            ToCity = to;
            FromCity = from;
            Distance = distance;
        }

        public override string ToString() => $"{FromCity} -> {ToCity} ({Distance})";
    }
}