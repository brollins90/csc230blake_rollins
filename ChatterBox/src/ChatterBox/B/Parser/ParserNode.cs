namespace ChatterBox.B.Parser
{
    public abstract class ParserNode
    {
        public Grammar.B Type { get; set; }
        public virtual string Text { get; }

        public ParserNode(Grammar.B type)
        {
            Type = type;
        }

        public override string ToString() => Text;
    }
}