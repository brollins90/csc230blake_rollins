namespace ChatterBox.B.Parser
{
    public abstract class ParserNode
    {
        public string Text { get; private set; }

        public ParserNode(string text)
        {
            Text = text;
        }

        public override string ToString() => Text;
    }
}