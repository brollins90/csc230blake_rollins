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

        //internal BGrammar()
        //{
        //    _staticProductions.Add(new Production(GrammarVariable.Get("SENTENCE"),
        //        new GrammarMatcher(GrammarVariable.Get("STATEMENT"))));

        //    _staticProductions.Add(new Production(GrammarVariable.Get("SENTENCE"),
        //        new GrammarMatcher(GrammarVariable.Get("LIKESTATEMENT"))));

        //    _staticProductions.Add(new Production(GrammarVariable.Get("LIKESTATEMENT"),
        //        new GrammarMatcher(GrammarVariable.Get("PRONOUN"), GrammarVariable.Get("LIKE"), GrammarVariable.Get("VERB"))));

        //    _staticProductions.Add(new Production(GrammarVariable.Get("STATEMENT"),
        //        new GrammarMatcher(GrammarVariable.Get("NOUNPHRASE"), GrammarVariable.Get("VERBPHRASE"))));

        //    _staticProductions.Add(new Production(GrammarVariable.Get("NOUNPHRASE"),
        //        new GrammarMatcher(GrammarVariable.Get("ARTICLE"), GrammarVariable.Get("NOUN")) { Lookahead = "with", LookaheadBool = false }));

        //    _staticProductions.Add(new Production(GrammarVariable.Get("NOUNPHRASE"),
        //        new GrammarMatcher(GrammarVariable.Get("ARTICLE"), GrammarVariable.Get("NOUN"), GrammarVariable.Get("PREPOSITION"), GrammarVariable.Get("NOUNPHRASE"))));

        //    _staticProductions.Add(new Production(GrammarVariable.Get("VERBPHRASE"),
        //        new GrammarMatcher(GrammarVariable.Get("VERB")) { Lookahead = string.Empty, LookaheadBool = true }));

        //    _staticProductions.Add(new Production(GrammarVariable.Get("VERBPHRASE"),
        //        new GrammarMatcher(GrammarVariable.Get("VERB"), GrammarVariable.Get("NOUNPHRASE"))));

        //    _staticProductions.Add(new Production(GrammarVariable.Get("ARTICLE"),
        //        new GrammarMatcher(new GrammarTerminal("a"))));

        //    _staticProductions.Add(new Production(GrammarVariable.Get("ARTICLE"),
        //        new GrammarMatcher(new GrammarTerminal("the"))));

        //    _staticProductions.Add(new Production(GrammarVariable.Get("NOUN"),
        //        new GrammarMatcher(new GrammarTerminal("cat"))));

        //    _staticProductions.Add(new Production(GrammarVariable.Get("NOUN"),
        //        new GrammarMatcher(new GrammarTerminal("dog"))));

        //    _staticProductions.Add(new Production(GrammarVariable.Get("NOUN"),
        //        new GrammarMatcher(new GrammarTerminal("fish"))));

        //    _staticProductions.Add(new Production(GrammarVariable.Get("VERB"),
        //        new GrammarMatcher(new GrammarTerminal("bites"))));

        //    _staticProductions.Add(new Production(GrammarVariable.Get("VERB"),
        //        new GrammarMatcher(new GrammarTerminal("chases"))));

        //    _staticProductions.Add(new Production(GrammarVariable.Get("PREPOSITION"),
        //        new GrammarMatcher(new GrammarTerminal("with"))));

        //    _staticProductions.Add(new Production(GrammarVariable.Get("PRONOUN"),
        //        new GrammarMatcher(new GrammarTerminal("i"))));

        //    _staticProductions.Add(new Production(GrammarVariable.Get("PRONOUN"),
        //        new GrammarMatcher(new GrammarTerminal("you"))));

        //    _staticProductions.Add(new Production(GrammarVariable.Get("PRONOUN"),
        //        new GrammarMatcher(new GrammarTerminal("he"))));

        //    _staticProductions.Add(new Production(GrammarVariable.Get("PRONOUN"),
        //        new GrammarMatcher(new GrammarTerminal("she"))));

        //    _staticProductions.Add(new Production(GrammarVariable.Get("EXIT"),
        //        new GrammarMatcher(new GrammarTerminal("exit"))));

        //    _staticProductions.Add(new Production(GrammarVariable.Get("EXIT"),
        //        new GrammarMatcher(new GrammarTerminal("bye"))));

        //    _staticProductions.Add(new Production(GrammarVariable.Get("EXIT"),
        //        new GrammarMatcher(new GrammarTerminal("goodbye"))));
        //}
    }
}