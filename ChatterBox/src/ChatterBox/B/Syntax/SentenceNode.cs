namespace ChatterBox.B.Syntax
{
    using Parser;

    public class SentenceNode : ColNode
    {

        public SentenceNode(params ParserNode[] children)
            : base(Grammar.B.Sentence, children)
        {
        }
    }
}