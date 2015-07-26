namespace ChatterBox
{
    using Parser;

    public interface IChatterBox
    {
        void Go();

        ParserTree ProcessString(string input);

        string ProcessParseTree(ParserTree tree);
    }
}