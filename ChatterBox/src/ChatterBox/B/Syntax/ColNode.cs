namespace ChatterBox.B.Syntax
{
    using Parser;
    using System.Collections.Generic;
    using System.Linq;

    public class ColNode : ParserNode
    {
        public Stack<ParserNode> Children { get; set; }

        public ColNode(Grammar.B type, params ParserNode[] children)
            : base(type)
        {
            Children = new Stack<ParserNode>(children.Reverse());
        }

        public override string Text => $"{Type} {{{string.Join(" ", Children)}}}";
    }
}
