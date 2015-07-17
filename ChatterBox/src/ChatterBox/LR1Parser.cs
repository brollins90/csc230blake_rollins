namespace ChatterBox
{
    using System.Collections;
    using System.Collections.Generic;

    public static class StackUtils
    {
        public static string DoPop(this Stack<string> i)
        {
            if (i.Count > 0)
            {
                return i.Pop();
            }
            return "";
        }
        public static void DoPush(this Stack<string> i, string s)
        {
            if (!string.IsNullOrWhiteSpace(s))
            {
                i.Push(s);
            }
        }
    }
    public class LR1Parser : IChatterBox
    {
        public enum G
        {
            Sentence,
            NounPhrase,
            VerbPhrase,
            Article,
            Noun,
            Verb,
            Preposition
        }

        Stack<string> stack = new Stack<string>();
        ISymbolizer symbolizer;

        public string ProcessString(string s)
        {
            symbolizer = new Symbolizer(s);

            while (symbolizer.MoveNext())
            {
                string current = $"{symbolizer.Current}";
                stack.Push(current);

                while (Reduce())
                {
                }
            }

            if (stack.Count == 1 && stack.Pop().Equals(G.Sentence.ToString().ToLowerInvariant()))
            {
                return "true";
            }
            return "false";
        }

        public bool Reduce()
        {
            bool reduced = false;

            string t1 = stack.DoPop();
            string t2 = stack.DoPop();
            string t3 = stack.DoPop();
            string lookahead = symbolizer.LookAhead();

            System.Console.WriteLine($"t1:{t1},t2:{t2},t3:{t3},lookahead:{lookahead}");

            // Sentence -> NounPhrase VerbPhrase
            if (t1.ToLowerInvariant().Equals(G.VerbPhrase.ToString().ToLowerInvariant())
                && t2.ToLowerInvariant().Equals(G.NounPhrase.ToString().ToLowerInvariant()))
            {
                stack.DoPush(t3.ToLowerInvariant());
                stack.DoPush(G.Sentence.ToString().ToLowerInvariant());
                reduced = true;
            }

            // NounPhrase -> Article Noun (not with)
            else if (t1.ToLowerInvariant().Equals(G.Noun.ToString().ToLowerInvariant())
                && t2.ToLowerInvariant().Equals(G.Article.ToString().ToLowerInvariant())
                && !lookahead.ToLowerInvariant().Equals("with".ToLowerInvariant()))
            {
                stack.DoPush(t3.ToLowerInvariant());
                stack.DoPush(G.NounPhrase.ToString().ToLowerInvariant());
                reduced = true;
            }

            // NounPhrase -> Article Noun Preposition //NounPhrase
            else if (t1.ToLowerInvariant().Equals(G.Preposition.ToString().ToLowerInvariant())
                && t2.ToLowerInvariant().Equals(G.Noun.ToString().ToLowerInvariant())
                && t3.ToLowerInvariant().Equals(G.Article.ToString().ToLowerInvariant()))
            {
                stack.DoPush(G.NounPhrase.ToString().ToLowerInvariant());
                reduced = true;
            }

            // NounPhrase -> Article Noun (not with)
            else if (t1.ToLowerInvariant().Equals(G.Verb.ToString().ToLowerInvariant())
                && !(lookahead.ToLowerInvariant().Equals("a".ToLowerInvariant())
                || lookahead.ToLowerInvariant().Equals("the".ToLowerInvariant())
                || lookahead.ToLowerInvariant().Equals("dog".ToLowerInvariant())
                || lookahead.ToLowerInvariant().Equals("cat".ToLowerInvariant())
                || lookahead.ToLowerInvariant().Equals("fish".ToLowerInvariant())))
            {
                stack.DoPush(t3.ToLowerInvariant());
                stack.DoPush(t2.ToLowerInvariant());
                stack.DoPush(G.VerbPhrase.ToString().ToLowerInvariant());
                reduced = true;
            }

            else if (t1.ToLowerInvariant().Equals(G.NounPhrase.ToString().ToLowerInvariant())
                && t2.ToLowerInvariant().Equals(G.Verb.ToString().ToLowerInvariant()))
            {
                stack.DoPush(t3.ToLowerInvariant());
                stack.DoPush(G.VerbPhrase.ToString().ToLowerInvariant());
                reduced = true;
            }

            else if (t1.ToLowerInvariant().Equals(G.Verb.ToString().ToLowerInvariant()))
            {
                stack.DoPush(t3.ToLowerInvariant());
                stack.DoPush(t2.ToLowerInvariant());
                stack.DoPush(G.VerbPhrase.ToString().ToLowerInvariant());
                reduced = true;
            }

            else if (t1.ToLowerInvariant().Equals("a".ToLowerInvariant())
                || t1.ToLowerInvariant().Equals("the".ToLowerInvariant()))
            {
                stack.DoPush(t3.ToLowerInvariant());
                stack.DoPush(t2.ToLowerInvariant());
                stack.DoPush(G.Article.ToString().ToLowerInvariant());
                reduced = true;
            }

            else if (t1.ToLowerInvariant().Equals("dog".ToLowerInvariant())
                || t1.ToLowerInvariant().Equals("cat".ToLowerInvariant())
                || t1.ToLowerInvariant().Equals("fish".ToLowerInvariant()))
            {
                stack.DoPush(t3.ToLowerInvariant());
                stack.DoPush(t2.ToLowerInvariant());
                stack.DoPush(G.Noun.ToString().ToLowerInvariant());
                reduced = true;
            }

            else if (t1.ToLowerInvariant().Equals(G.NounPhrase.ToString().ToLowerInvariant())
                && t2.ToLowerInvariant().Equals("with".ToLowerInvariant()))
            {
                stack.DoPush(t3.ToLowerInvariant());
                stack.DoPush(G.Preposition.ToString().ToLowerInvariant());
                reduced = true;
            }

            else
            {
                stack.DoPush(t3.ToLowerInvariant());
                stack.DoPush(t2.ToLowerInvariant());
                stack.DoPush(t1.ToLowerInvariant());
            }
            return reduced;
        }

    }
}
