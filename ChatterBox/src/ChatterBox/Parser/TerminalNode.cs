namespace ChatterBox.Parser
{
    public class TerminalNode : IParserNode
    {
        public string Compare => Text.ToLowerInvariant();
        public string Text { get; }
        public string Type => "Terminal";

        public TerminalNode(string text)
        {
            Text = text;
        }

        public override string ToString() => Text;
    }
}