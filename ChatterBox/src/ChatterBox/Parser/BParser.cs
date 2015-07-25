namespace ChatterBox.Parser
{
    using Extensions;
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

        public ParseTree ParseStringToTree(string input)
        {
            tokenizer = new BTokenizer(input);

            while (tokenizer.MoveNext())
            {
                string currentToken = tokenizer.Current;

                _internalStack.DoPush(new TerminalNode(currentToken));

                while (Reduce()) { }
            }

            ParseTree tree = new ParseTree(_grammar, _internalStack);
            return tree;
        }

        public bool Reduce()
        {
            bool reduced = false;

            for (int i = 0; i < _grammar.Productions.Count && !reduced; i++)
            {
                var production = _grammar.Productions[i];
                //int symbolCount = production.Matcher.Symbols.Count;
                //int stackSize = _internalStack.Count;
                //int currentCount = Math.Max(symbolCount, stackSize);
                //Console.WriteLine($"Prod: {production}");
                //Console.WriteLine($"{string.Join(" ", _internalStack)}");

                //var tArray = new ParserNode[currentCount];

                ////for (int j = currentCount - 1; j >= 0; j--)
                //for (int j = 0; j < currentCount; j++)
                //{
                //    tArray[j] = _internalStack.DoPop();
                //}

                //var t1 = _internalStack.DoPop();
                //var t2 = _internalStack.DoPop();
                //var t3 = _internalStack.DoPop();
                //var t4 = _internalStack.DoPop();
                var lookahead = tokenizer.LookAhead();

                if (production.Matcher.TryMatch(lookahead, _internalStack))
                {
                    //int itemsToPushBack = stackSize - symbolCount;
                    //for (int j = 0; j < itemsToPushBack; j++)
                    //{
                    //    _internalStack.DoPush(tArray[j]);
                    //}
                    var tArray = new ParserNode[production.Matcher.Symbols.Count];
                    for (int j = 0; j < production.Matcher.Symbols.Count; j++)
                    {
                        tArray[j] = _internalStack.Pop();
                    }
                    _internalStack.DoPush(production.Variable.ToNode(tArray));
                    reduced = true;
                }

                //if (!reduced)
                //{
                //    for (int j = 0; j < currentCount; j++)
                //    {
                //        _internalStack.DoPush(tArray[j]);
                //    }

                //}

                //if (symbols.Count == 4 && production.Matcher.TryMatch(lookahead, t4, t3, t2, t1))
                //{
                //    _internalStack.DoPush(production.Variable.ToNode(t1, t2, t3, t4));
                //    reduced = true;
                //}
                //else if (symbols.Count == 3 && production.Matcher.TryMatch(lookahead, t3, t2, t1))
                //{
                //    _internalStack.DoPush(t4);
                //    _internalStack.DoPush(production.Variable.ToNode(t1, t2, t3));
                //    reduced = true;
                //}
                //else if (symbols.Count == 2 && production.Matcher.TryMatch(lookahead, t2, t1))
                //{
                //    _internalStack.DoPush(t4);
                //    _internalStack.DoPush(t3);
                //    _internalStack.DoPush(production.Variable.ToNode(t1, t2));
                //    reduced = true;
                //}
                //else if (symbols.Count == 1 && production.Matcher.TryMatch(lookahead, t1))
                //{
                //    _internalStack.DoPush(t4);
                //    _internalStack.DoPush(t3);
                //    _internalStack.DoPush(t2);
                //    _internalStack.DoPush(production.Variable.ToNode(t1));
                //    reduced = true;
                //}
                //else
                //{
                //    _internalStack.DoPush(t4);
                //    _internalStack.DoPush(t3);
                //    _internalStack.DoPush(t2);
                //    _internalStack.DoPush(t1);
                //}
            }
            return reduced;
        }
    }
}
