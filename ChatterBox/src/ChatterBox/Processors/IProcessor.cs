namespace ChatterBox.Processors
{
    using Parser;

    public interface IProcessor
    {
        bool TryProcess(ParserTree tree, out string response);
    }
}