namespace ChatterBox.Parser
{
    using Extensions;
    using Grammar;
    using System.Collections.Generic;

    public class BParser : IParser
    {
        private Stack<IParserNode> _internalStack = new Stack<IParserNode>();
        private IGrammar _grammar;
        private ITokenizer tokenizer;

        public BParser(IGrammar grammar)
        {
            _grammar = grammar;
        }

        public ParseTree ParseStringToTree(string input)
        {
            tokenizer = new BTokenizer(input);
            
            while (tokenizer.MoveNext())
            {
                string currentToken = tokenizer.Current;

                _internalStack.DoPush(new TerminalNode(currentToken));

                while (Reduce()) { }
            }

            ParseTree tree = new ParseTree(_grammar) { HackingStack = _internalStack };
            return tree;
        }

        public bool Reduce()
        {
            bool reduced = false;

            for (int i = 0; i < _grammar.Productions.Count && !reduced; i++)
            {
                var production = _grammar.Productions[i];

                var t1 = _internalStack.DoPop();
                var t2 = _internalStack.DoPop();
                var t3 = _internalStack.DoPop();
                var t4 = _internalStack.DoPop();
                var lookahead = tokenizer.LookAhead();

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
