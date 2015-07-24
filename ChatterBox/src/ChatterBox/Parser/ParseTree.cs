namespace ChatterBox.Parser
{
    using Grammar;
    using System;
    using System.Collections.Generic;

    public class ParseTree : IEquatable<ParseTree>
    {
        private IGrammar _grammarReference;

        public Stack<ParserNode> HackingStack { get; }


        public ParseTree(IGrammar grammarReference, Stack<ParserNode> stack)
        {
            _grammarReference = grammarReference;
            HackingStack = stack;
        }

        public ParseTree(IGrammar grammarReference, ParserNode singleNode)
        {
            _grammarReference = grammarReference;
            HackingStack = new Stack<ParserNode>(new[] { singleNode });
        }

        public ParserNode HeadNode => (HackingStack.Count > 0) ? HackingStack.Peek() : null;
        public bool IsValid() => HeadNode.Equals(_grammarReference.First);
        public bool IsExit() => HeadNode.Equals(_grammarReference.Last);

        public override string ToString() => HeadNode?.ToString() ?? "";//$"{string.Join("\n", HackingStack)}"; //HeadNode?.Text ?? "";


        public override bool Equals(object obj)
        {
            if (obj == null) { return false; }
            return Equals(obj as ParseTree);
        }

        public bool Equals(ParseTree other)
        {
            if ((object)other == null) { return false; }
            return HeadNode.Equals(HeadNode);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}