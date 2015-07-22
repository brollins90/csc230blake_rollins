namespace ChatterBox.B.Parser
{
    using Grammar;

    public class ParseTree
    {
        public ParserNode HeadNode { get; set; }

        public bool IsValid() => HeadNode.Compare.Equals(new BGrammar().First());
        public bool IsExit() => HeadNode.Compare.Equals(new BGrammar().Last());

        public override string ToString() => HeadNode?.Text ?? "";
    }
}