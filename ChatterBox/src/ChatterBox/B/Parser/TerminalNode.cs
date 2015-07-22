namespace ChatterBox.B.Parser
{
    public class TerminalNode : ParserNode
    {
        public override string Text { get; set; }

        public TerminalNode(string text) 
            : base("TERMINAL")
        {
            Text = text;
        }

        public override string Compare => Text.ToLowerInvariant();
    }
}
