namespace ChatterBox.Parser
{
    public class TerminalNode : ParserNode
    {
        public string Text { get; }

        public TerminalNode(string text)
        {
            Text = text;
        }

        public override string Type => "Terminal";
        public override string Compare => Text.ToLowerInvariant();
    }
}