namespace ChatterBox.Parser
{
    using Extensions;
    using Tokenizer;
    using Grammar;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BParser : IParser
    {
        private Stack<ParserNode> _internalStack = new Stack<ParserNode>();
        private IGrammar _grammar;
        private ITokenizer tokenizer;

        public BParser(IGrammar grammar)
        {
            _grammar = grammar;
        }

        public ParserTree ParseStringToTree(string input)
        {
            tokenizer = new BTokenizer(input);

            while (tokenizer.MoveNext())
            {
                string currentToken = tokenizer.Current;

                _internalStack.DoPush(new TerminalNode(currentToken));

                while (Reduce()) { }
            }

            ParserTree tree = new ParserTree(_grammar, _internalStack);
            return tree;
        }

        public bool Reduce()
        {
            bool reduced = false;

            for (int i = 0; i < _grammar.Productions.Count && !reduced; i++)
            {
                var production = _grammar.Productions[i];
                var lookahead = tokenizer.LookAhead();

                // hack for numbers now
                int t;
                if (production.Variable.Compare.Equals("NUMBER") && int.TryParse(_internalStack.Peek().Compare, out t))
                {
                    _internalStack.DoPush(production.Variable.ToNode(new[] { _internalStack.Pop() }));
                    reduced = true;
                }
                // end hack

                if (production.Matcher.TryMatch(lookahead, _internalStack))
                {
                    var tArray = new ParserNode[production.Matcher.Symbols.Count];
                    for (int j = 0; j < production.Matcher.Symbols.Count; j++)
                    {
                        tArray[j] = _internalStack.Pop();
                    }
                    _internalStack.DoPush(production.Variable.ToNode(tArray));
                    reduced = true;
                }
            }
            return reduced;
        }
    }
}
