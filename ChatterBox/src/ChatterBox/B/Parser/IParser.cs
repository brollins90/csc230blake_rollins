namespace ChatterBox.B.Parser
{
    public interface IParser
    {
        ParseTree ProcessString(string input);
    }
}