namespace ChatterBox.Parser
{
    public abstract class ParserNode
    {
        public abstract string Type { get; }
        public abstract string Compare { get; }

        public override string ToString() => Compare;
    }
}