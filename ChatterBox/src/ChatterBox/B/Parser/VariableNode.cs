namespace ChatterBox.B.Parser
{
    using System.Collections.Generic;
    using System.Linq;

    public class VariableNode : ParserNode
    {
        public Stack<ParserNode> Children { get; set; }

        public VariableNode(string type, params ParserNode[] children)
            : base(type)
        {
            Children = new Stack<ParserNode>(children);
            //Children = new Stack<ParserNode>(children.Reverse());
        }

        public override string Text => $"{Type} {{{string.Join(" ", Children)}}}";

        public override string Compare => Type.ToUpperInvariant();
    }
}