namespace ChatterBox.Parser
{
    using System.Collections.Generic;

    public class TerminalNode : ParserNode
    {
        private string _text;

        // A Terminal node is equal if the TEXT is the same
        public override string Compare => _text.ToLowerInvariant();
        public override string Type => "TERMINAL";

        public TerminalNode(string text)
        {
            //Debug.WriteLine($"created  {Type} ({text})");
            _text = text;
        }

        public override string ToString() => _text;

        public override IEnumerator<ParserNode> GetEnumerator()
        {
            yield return this;
        }
    }
}