namespace ChatterBox.B.Parser
{
    public interface IParser
    {
        ParseTree ParseStringToTree(string input);
    }
}