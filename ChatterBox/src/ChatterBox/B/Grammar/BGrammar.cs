namespace ChatterBox.B.Grammar
{
    using System.Collections.Generic;
    using System.Linq;

    public class BGrammar
    {
        public List<Production> Productions { get; } = new List<Production>();
        public GrammarVariable First() => Productions.FirstOrDefault()?.Variable;
        public GrammarVariable Last() => Productions.LastOrDefault()?.Variable;

        public BGrammar()
        {
            Productions.Add(new Production(GrammarVariable.Get("SENTENCE"),
                new GrammarMatcher(GrammarVariable.Get("STATEMENT"))));

            Productions.Add(new Production(GrammarVariable.Get("SENTENCE"),
                new GrammarMatcher(GrammarVariable.Get("LIKESTATEMENT"))));

            Productions.Add(new Production(GrammarVariable.Get("LIKESTATEMENT"),
                new GrammarMatcher(GrammarVariable.Get("PRONOUN"), GrammarVariable.Get("LIKE"), GrammarVariable.Get("VERB"))));

            Productions.Add(new Production(GrammarVariable.Get("STATEMENT"),
                new GrammarMatcher(GrammarVariable.Get("NOUNPHRASE"), GrammarVariable.Get("VERBPHRASE"))));

            Productions.Add(new Production(GrammarVariable.Get("NOUNPHRASE"),
                new GrammarMatcher(GrammarVariable.Get("ARTICLE"), GrammarVariable.Get("NOUN")) {Lookahead = "with", LookaheadBool = false }));

            Productions.Add(new Production(GrammarVariable.Get("NOUNPHRASE"),
                new GrammarMatcher(GrammarVariable.Get("ARTICLE"), GrammarVariable.Get("NOUN"), GrammarVariable.Get("PREPOSITION"), GrammarVariable.Get("NOUNPHRASE"))));

            Productions.Add(new Production(GrammarVariable.Get("VERBPHRASE"),
                new GrammarMatcher(GrammarVariable.Get("VERB"))));

            Productions.Add(new Production(GrammarVariable.Get("VERBPHRASE"),
                new GrammarMatcher(GrammarVariable.Get("VERB"), GrammarVariable.Get("NOUNPHRASE"))));

            Productions.Add(new Production(GrammarVariable.Get("ARTICLE"),
                new GrammarMatcher(new GrammarTerminal("a"))));

            Productions.Add(new Production(GrammarVariable.Get("ARTICLE"),
                new GrammarMatcher(new GrammarTerminal("the"))));

            Productions.Add(new Production(GrammarVariable.Get("NOUN"),
                new GrammarMatcher(new GrammarTerminal("cat"))));

            Productions.Add(new Production(GrammarVariable.Get("NOUN"),
                new GrammarMatcher(new GrammarTerminal("dog"))));

            Productions.Add(new Production(GrammarVariable.Get("NOUN"),
                new GrammarMatcher(new GrammarTerminal("fish"))));

            Productions.Add(new Production(GrammarVariable.Get("VERB"),
                new GrammarMatcher(new GrammarTerminal("bites"))));

            Productions.Add(new Production(GrammarVariable.Get("VERB"),
                new GrammarMatcher(new GrammarTerminal("chases"))));

            Productions.Add(new Production(GrammarVariable.Get("PREPOSITION"),
                new GrammarMatcher(new GrammarTerminal("with"))));

            Productions.Add(new Production(GrammarVariable.Get("PRONOUN"),
                new GrammarMatcher(new GrammarTerminal("i"))));

            Productions.Add(new Production(GrammarVariable.Get("PRONOUN"),
                new GrammarMatcher(new GrammarTerminal("you"))));

            Productions.Add(new Production(GrammarVariable.Get("PRONOUN"),
                new GrammarMatcher(new GrammarTerminal("he"))));

            Productions.Add(new Production(GrammarVariable.Get("PRONOUN"),
                new GrammarMatcher(new GrammarTerminal("she"))));

            Productions.Add(new Production(GrammarVariable.Get("EXIT"),
                new GrammarMatcher(new GrammarTerminal("exit"))));
        }
    }
}