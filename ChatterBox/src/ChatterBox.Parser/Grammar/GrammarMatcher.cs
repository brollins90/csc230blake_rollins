namespace ChatterBox.Grammar
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

        public bool TryMatch(string lookahead, Stack<ParserNode> nodes)
        {
            var sArray = Symbols.ToArray().Reverse().ToArray();
            bool result = false;
            if (nodes.Count() >= Symbols.Count)
            {
                // set to true until something fails
                result = true;
                var tArray = new ParserNode[Symbols.Count];
                for (int i = 0; i < Symbols.Count; i++)
                {
                    tArray[i] = nodes.Pop();

                    if (!sArray[i].Equals(tArray[i]))
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

                //if (!result)
                //{
                    tArray = tArray.Reverse().ToArray();
                    foreach (var n in tArray)
                    {
                        nodes.Push(n);
                    }
                //}
                //else
                //{

                //}
            }
            return result;
        }

        public override string ToString() => $"{string.Join(" ", Symbols)}";
    }
}
