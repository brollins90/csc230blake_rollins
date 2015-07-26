using System.Diagnostics;

namespace ChatterBox.Parser
{
    public class TerminalNode : ParserNode
    {
        private string _text;

        public override string Compare => _text.ToLowerInvariant();
        public override string Type => "Terminal";

        public TerminalNode(string text)
        {
            Debug.WriteLine($"created  TERMINAL ({text})");
            _text = text;
        }

        public override string ToString() => _text;
    }
}