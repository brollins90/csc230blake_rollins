namespace ChatterBox.B.Parser
{
    public abstract class ParserNode
    {
        public virtual string Type { get; set; }
        public virtual string Text { get; set; }
        public virtual string Compare { get { return Type.ToLowerInvariant(); } }

        public ParserNode(string type)
        {
            Type = type;
        }

        public override string ToString() => Text;
    }
}