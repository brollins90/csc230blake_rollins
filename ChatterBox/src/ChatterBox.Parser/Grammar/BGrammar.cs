namespace ChatterBox.Grammar
{
    using System.Collections.Generic;
    using System.Linq;

    public class BGrammar : IGrammar
    {
        private static List<Production> _internalProductions;

        public BGrammar()
        {
            _internalProductions = new List<Production>();
        }

        public List<Production> Productions => _internalProductions;
        public GrammarVariable First => Productions.FirstOrDefault()?.Variable;
        public GrammarVariable Last => Productions.LastOrDefault()?.Variable;

        internal void AddProduction(Production newProduction)
        {
            _internalProductions.Add(newProduction);
        }

        internal void AddProduction(Production[] newProductions)
        {
            _internalProductions.AddRange(newProductions);
        }
    }
}