namespace ChatterBox.B.Parser
{
    using Extensions;
    using Grammar;
    using System.Collections.Generic;

    public class BParser : IParser
    {
        private BGrammar _grammar = new BGrammar();

        private Stack<ParserNode> _internalStack = new Stack<ParserNode>();
        private ISymbolizer symbolizer;

        public ParseTree ParseStringToTree(string input)
        {
            symbolizer = new Symbolizer(input);
            
            while (symbolizer.MoveNext())
            {
                string current = symbolizer.Current;

                _internalStack.DoPush(new TerminalNode(current));

                while (Reduce()) { }
            }

            ParseTree tree = new ParseTree { HackingStack = _internalStack };
            return tree;
        }

        public bool Reduce()
        {
            bool reduced = false;

            for (int i = 0; i < _grammar.Productions.Count && !reduced; i++)
            {
                var production = _grammar.Productions[i];
                //System.Console.WriteLine(production);

                var t1 = _internalStack.DoPop();
                var t2 = _internalStack.DoPop();
                var t3 = _internalStack.DoPop();
                var t4 = _internalStack.DoPop();
                var lookahead = symbolizer.LookAhead();

                //System.Console.WriteLine($"t1:{t1},t2:{t2},t3:{t3},t4:{t4},lookahead:{lookahead}");
                
                var symbols = production.Matcher.Symbols;

                if (symbols.Count == 4 && production.Matcher.TryMatch(lookahead, t4, t3, t2, t1))
                {
                    _internalStack.DoPush(production.Variable.ToNode(t1, t2, t3, t4));
                    reduced = true;
                }
                else if (symbols.Count == 3 && production.Matcher.TryMatch(lookahead, t3, t2, t1))
                {
                    _internalStack.DoPush(t4);
                    _internalStack.DoPush(production.Variable.ToNode(t1, t2, t3));
                    reduced = true;
                }
                else if (symbols.Count == 2 && production.Matcher.TryMatch(lookahead, t2, t1))
                {
                    _internalStack.DoPush(t4);
                    _internalStack.DoPush(t3);
                    _internalStack.DoPush(production.Variable.ToNode(t1, t2));
                    reduced = true;
                }
                else if (symbols.Count == 1 && production.Matcher.TryMatch(lookahead, t1))
                {
                    _internalStack.DoPush(t4);
                    _internalStack.DoPush(t3);
                    _internalStack.DoPush(t2);
                    _internalStack.DoPush(production.Variable.ToNode(t1));
                    reduced = true;
                }
                else
                {
                    _internalStack.DoPush(t4);
                    _internalStack.DoPush(t3);
                    _internalStack.DoPush(t2);
                    _internalStack.DoPush(t1);
                }
            }
            return reduced;
        }
    }
}
