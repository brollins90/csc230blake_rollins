namespace ChatterBox.B.Parser
{
    public class ParseTree
    {
        public ParserNode HeadNode { get; set; }

        public bool IsValid() => (HeadNode.Type == Grammar.B.Sentence);
        public bool IsExit() => (HeadNode.Type == Grammar.B.Exit);

        public override string ToString() => HeadNode?.Text ?? "";
    }
}