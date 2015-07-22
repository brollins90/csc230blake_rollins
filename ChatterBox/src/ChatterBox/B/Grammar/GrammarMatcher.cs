namespace ChatterBox.B.Grammar
{
    using Parser;
    using System.Collections.Generic;
    using System.Linq;

    public class GrammarMatcher
    {
        public List<GrammarSymbol> Symbols { get; set; }
        public string Lookahead { get; set; }
        public bool LookaheadBool { get; set; }

        public GrammarMatcher(params GrammarSymbol[] symbols)
        {
            Symbols = new List<GrammarSymbol>(symbols);
        }

        public bool TryMatch(string lookahead, params ParserNode[] nodes)
        {
            nodes = nodes.Where(x => x != null).ToArray();
            bool result = false;
            if (Symbols.Count == nodes.Count())
            {
                // set to true until something fails
                result = true;
                for (int i = 0; i < Symbols.Count && result; i++)
                {
                    if (!Symbols[i].Compare.Equals(nodes[i].Compare))
                    {
                        result = false;
                    }
                }

                // at this point, we match, but we havent checked ahead yet
                if (result && Lookahead != null)
                {
                    var doesLookaheadMatch = Lookahead.Equals(lookahead);
                    result = doesLookaheadMatch == LookaheadBool;
                }
            }
            return result;
        }

        public override string ToString() => $"{string.Join(" ", Symbols)}";
    }
}
