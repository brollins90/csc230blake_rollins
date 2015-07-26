namespace ChatterBox.Parser
{
    using Grammar;
    using System;
    using System.Collections.Generic;
    using System.Collections;

    public class ParserTree // : IEnumerator<ParserNode> //IEquatable<ParseTree>
    {
        private IGrammar _grammarReference;

        private Stack<ParserNode> _hackingStack;


        public ParserTree(IGrammar grammarReference, Stack<ParserNode> stack)
        {
            _grammarReference = grammarReference;
            _hackingStack = stack;
        }

        public ParserTree(IGrammar grammarReference, ParserNode singleNode)
        {
            _grammarReference = grammarReference;
            _hackingStack = new Stack<ParserNode>(new[] { singleNode });
        }

        public ParserNode HeadNode => (_hackingStack.Count > 0) ? _hackingStack.Peek() : null;

        public bool IsValid() => HeadNode.Equals(_grammarReference.First);
        public bool IsExit() => HeadNode.Equals(_grammarReference.Last);

        public override string ToString() => HeadNode?.ToString() ?? "";//$"{string.Join("\n", HackingStack)}"; //HeadNode?.Text ?? "";

        public IEnumerator<ParserNode> GetEnumerator()
        {
            foreach (ParserNode node in HeadNode)
                yield return node;
        }



        //public override bool Equals(object obj)
        //{
        //    if (obj == null) { return false; }
        //    return Equals(obj as ParseTree);
        //}

        //public bool Equals(ParseTree other)
        //{
        //    if ((object)other == null) { return false; }
        //    return HeadNode.Equals(HeadNode);
        //}

        //public override int GetHashCode()
        //{
        //    return base.GetHashCode();
        //}
    }
}