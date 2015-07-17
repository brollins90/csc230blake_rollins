namespace ChatterBox
{
    using global::ChatterBox.B.Parser;

    public interface IChatterBox
    {
        string ProcessString(string s);
        string ProcessParseTree(ParseTree tree);
    }
}