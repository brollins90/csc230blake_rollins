namespace ChatterBox.Parser
{
    using System.Diagnostics;

    public class TerminalNode : ParserNode
    {
        private string _text;

        // A Terminal node is equal if the TEXT is the same
        public override string Compare => _text.ToLowerInvariant();
        public override string Type => "Terminal";

        public TerminalNode(string text)
        {
            Debug.WriteLine($"created  TERMINAL ({text})");
            _text = text;
        }

        //public override string ToString() => _text;
        public string ToTextString() => _text;
    }
}