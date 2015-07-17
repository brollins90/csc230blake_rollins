namespace ChatterBox.B.Syntax
{
    using Parser;

    public interface ISyntaxFactory
    {
        ParserNode CreateNode(string input);
    }
}