namespace ChatterBox.B.Syntax
{
    public class PrepositionNode : TerminalNode
    {
        public PrepositionNode(string text)
            : base(Grammar.B.Preposition, text)
        {
        }
    }
}