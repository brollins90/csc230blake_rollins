namespace ChatterBox.B.Syntax
{
    using Parser;

    public class TerminalNode : ParserNode
    {
        public override string Text { get; }

        public TerminalNode(Grammar.B type, string text) 
            : base(type)
        {
            Text = text;
        }
    }
}
