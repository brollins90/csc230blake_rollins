namespace ChatterBox
{
    using B.Parser;

    public interface IChatterBox
    {
        void Go();

        ParseTree ProcessString(string input);

        string ProcessParseTree(ParseTree tree);
    }
}