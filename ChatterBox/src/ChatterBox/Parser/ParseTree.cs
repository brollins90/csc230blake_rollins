﻿namespace ChatterBox.Parser
{
    using Grammar;
    using System.Collections.Generic;

    public class ParseTree
    {
        private IGrammar _grammarReference;

        public ParseTree(IGrammar grammarReference)
        {
            _grammarReference = grammarReference;
        }

        public Stack<ParserNode> HackingStack { get; set; }
        public ParserNode HeadNode => (HackingStack.Count > 0) ? HackingStack.Peek() : null;

        public bool IsValid() => HeadNode.Compare.Equals(_grammarReference.First.Compare);
        public bool IsExit() => HeadNode.Compare.Equals(_grammarReference.Last.Compare);

        public override string ToString() => $"{string.Join("\n", HackingStack)}"; //HeadNode?.Text ?? "";
    }
}