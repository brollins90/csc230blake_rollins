using System.Collections.Generic;

namespace ChatterBox.B.Grammar
{
    public enum B
    {
        Sentence,
        NounPhrase,
        VerbPhrase,
        Article,
        Noun,
        Verb,
        Preposition,
        Pronoun,
        Exit
    }

    public class BGrammar
    {
        Dictionary<string, List<List<string>>> _dict;
        public Dictionary<string, List<List<string>>> Dict { get { return _dict; } }

        public BGrammar()
        {
            _dict = new Dictionary<string, List<List<string>>>
            {
                { "SENTENCE", new List<List<string>>
                    { new List<string> { "STATEMENT" },
                      new List<string> { "LIKESTATEMENT" } } },
                { "LIKESTATEMENT", new List<List<string>>
                    { new List<string> { "PRONOUN", "LIKE", "VERB" } } },
                { "STATEMENT", new List<List<string>>
                    { new List<string> { "NOUNPHRASE", "VERBPHRASE" } } },
                { "NOUNPHRASE", new List<List<string>>
                    { new List<string> { "ARTICLE", "NOUN" },
                      new List<string> { "ARTICLE", "NOUN", "PREPOSITION", "NOUNPHRASE" } } },
                { "VERBPHRASE", new List<List<string>>
                    { new List<string> { "VERB" },
                      new List<string> { "VERB", "NOUNPHRASE" } } },
                { "ARTICLE", new List<List<string>>
                    { new List<string> { "a" },
                      new List<string> { "the" } } },
                { "NOUN", new List<List<string>>
                    { new List<string> { "dog" },
                      new List<string> { "cat" },
                      new List<string> { "fish" } } },
                { "VERB", new List<List<string>>
                    { new List<string> { "bite" },
                      new List<string> { "bites" },
                      new List<string> { "chase" },
                      new List<string> { "chases" },
                      new List<string> { "eat" },
                      new List<string> { "ski" } } },
                { "PREPOSITION", new List<List<string>>
                    { new List<string> { "with" } } },
                { "PRONOUN", new List<List<string>>
                    { new List<string> { "i" },
                      new List<string> { "you" },
                      new List<string> { "he" },
                      new List<string> { "she" } } },
                { "LIKE", new List<List<string>>
                    { new List<string> { "like" },
                      new List<string> { "likes" },
                      new List<string> { "LIKE", "to" } } },
                { "EXIT", new List<List<string>>
                    { new List<string> { "exit" } } }
            };
        }
    }
}