namespace ChatterBox.B.Syntax
{
    using Parser;

    public class VerbPhraseNode : ParserNode
    {
        public VerbNode Verb { get; set; }
        public NounPhraseNode NounPhrase { get; set; }

        public VerbPhraseNode(VerbNode verb)
            : base($"{verb.Text}")
        {
            Verb = verb;
        }

        public VerbPhraseNode(VerbNode verb, NounPhraseNode nounPhrase)
            : base($"{verb.Text} {nounPhrase.Text}")
        {
            Verb = verb;
            NounPhrase = nounPhrase;
        }
    }
}
