﻿namespace ChatterBox.B.Parser
{
    using Extensions;
    using Syntax;
    using System.Collections.Generic;

    public class BParser : IParser
    {
        private Stack<ParserNode> _internalStack = new Stack<ParserNode>();
        private ISymbolizer symbolizer;

        public ParseTree ProcessString(string input)
        {
            symbolizer = new Symbolizer(input);
            ParseTree tree = new ParseTree();

            while (symbolizer.MoveNext())
            {
                string current = symbolizer.Current;
                _internalStack.DoPush(current);

                while (Reduce()) { }
            }

            tree = new ParseTree { HeadNode = _internalStack.DoPop() };
            return tree;
        }

        public bool Reduce()
        {
            bool reduced = false;

            var t1 = _internalStack.DoPop();
            var t2 = _internalStack.DoPop();
            var t3 = _internalStack.DoPop();
            var t4 = _internalStack.DoPop();
            var lookahead = symbolizer.LookAhead();

            System.Console.WriteLine($"t1:{t1},t2:{t2},t3:{t3},t4:{t4},lookahead:{lookahead}");

            // Sentence -> NounPhrase VerbPhrase
            if (t1 is VerbPhraseNode
                && t2 is NounPhraseNode)
            {
                _internalStack.DoPush(t4);
                _internalStack.DoPush(t3);
                _internalStack.DoPush(new SentenceNode(t2 as NounPhraseNode, t1 as VerbPhraseNode));
                reduced = true;
            }

            // NounPhrase -> Article Noun (not with)
            else if (t1 is NounNode
                && t2 is ArticleNode
                && !lookahead.ToLowerInvariant().Equals("with".ToLowerInvariant()))
            {
                _internalStack.DoPush(t4);
                _internalStack.DoPush(t3);
                _internalStack.DoPush(new NounPhraseNode(t2 as ArticleNode, t1 as NounNode));
                reduced = true;
            }

            // NounPhrase -> Article Noun Preposition //NounPhrase
            else if (t1 is PrepositionNode
                && t2 is NounNode
                && t3 is ArticleNode)
            {
                _internalStack.DoPush(t4);
                _internalStack.DoPush(new NounPhraseNode(t3 as ArticleNode, t2 as NounNode, t1 as PrepositionNode));
                reduced = true;
            }

            // VerbPhrase -> Verb NounPhrase
            else if (t1 is NounPhraseNode
                && t2 is VerbNode)
            {
                _internalStack.DoPush(t4);
                _internalStack.DoPush(t3);
                _internalStack.DoPush(new VerbPhraseNode(t2 as VerbNode, t1 as NounPhraseNode));
                reduced = true;
            }

            // VerbPhrase -> Verb (without nounphrase...)
            else if (t1 is VerbNode
                &&
                !(
                    lookahead.ToLowerInvariant().Equals("a".ToLowerInvariant())
                || lookahead.ToLowerInvariant().Equals("the".ToLowerInvariant())
                || lookahead.ToLowerInvariant().Equals("dog".ToLowerInvariant())
                || lookahead.ToLowerInvariant().Equals("cat".ToLowerInvariant())
                || lookahead.ToLowerInvariant().Equals("fish".ToLowerInvariant())
                ))
            {
                _internalStack.DoPush(t4);
                _internalStack.DoPush(t3);
                _internalStack.DoPush(t2);
                _internalStack.DoPush(new VerbPhraseNode(t1 as VerbNode));
                reduced = true;
            }

            //// VerbPhrase -> Verb
            //else if (t1.ToLowerInvariant().Equals(G.Verb.ToString().ToLowerInvariant()))
            //{
            //    stack.DoPush(t3.ToLowerInvariant());
            //    stack.DoPush(t2.ToLowerInvariant());
            //    stack.DoPush(G.VerbPhrase.ToString().ToLowerInvariant());
            //    reduced = true;
            //}

            else
            {
                _internalStack.DoPush(t4);
                _internalStack.DoPush(t3);
                _internalStack.DoPush(t2);
                _internalStack.DoPush(t1);
            }
            return reduced;
        }
    }
}
