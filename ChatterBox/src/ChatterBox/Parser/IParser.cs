namespace ChatterBox.Parser
{
    public interface IParser
    {
        ParseTree ParseStringToTree(string input);
    }
}