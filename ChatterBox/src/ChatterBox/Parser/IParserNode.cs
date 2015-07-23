namespace ChatterBox.Parser
{
    public interface IParserNode
    {
        string Type { get; }
        string Compare { get; }
    }
}