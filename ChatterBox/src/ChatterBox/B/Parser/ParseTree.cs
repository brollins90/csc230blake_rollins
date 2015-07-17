namespace ChatterBox.B.Parser
{
    using Syntax;

    public class ParseTree
    {
        public ParserNode HeadNode { get; set; }

        public bool IsValid() => typeof(SentenceNode) == HeadNode?.GetType();
    }
}