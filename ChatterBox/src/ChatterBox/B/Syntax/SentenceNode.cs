namespace ChatterBox.B.Syntax
{
    using Parser;

    public class SentenceNode : ParserNode
    {
        public NounPhraseNode NounPhrase { get; private set; }
        public VerbPhraseNode VerbPhrase { get; private set; }

        public SentenceNode(NounPhraseNode nounPhrase, VerbPhraseNode verbPhrase)
            : base($"{nounPhrase.Text} {verbPhrase.Text}")
        {
            NounPhrase = nounPhrase;
            VerbPhrase = verbPhrase;
        }
    }
}