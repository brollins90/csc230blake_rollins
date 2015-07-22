namespace ChatterBox.Parser
{
    using Grammar;
    using System.Collections.Generic;

    public class ParseTree
    {
        public Stack<ParserNode> HackingStack { get; set; }
        public ParserNode HeadNode
        {
            get
            {
                return (HackingStack.Count > 0) ? HackingStack.Peek() : null;
            }
        }

        public bool IsValid() => HeadNode.Compare.Equals(new BGrammar().First().Compare);
        public bool IsExit() => HeadNode.Compare.Equals(new BGrammar().Last().Compare);

        public override string ToString() => $"{string.Join("\n", HackingStack)}"; //HeadNode?.Text ?? "";
    }
}