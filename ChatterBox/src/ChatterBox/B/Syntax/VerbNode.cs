namespace ChatterBox.B.Syntax
{
    public class VerbNode : TerminalNode
    {
        public VerbNode(string text)
            : base(Grammar.B.Verb, text)
        {
        }
    }
}