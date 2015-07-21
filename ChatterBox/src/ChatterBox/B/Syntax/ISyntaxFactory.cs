namespace ChatterBox.B.Syntax
{
    using Parser;

    public interface ITerminalFactory
    {
        ParserNode CreateNode(string input);
    }
}