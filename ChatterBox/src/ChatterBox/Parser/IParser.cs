namespace ChatterBox.Parser
{
    public interface IParser
    {
        ParserTree ParseStringToTree(string input);
    }
}