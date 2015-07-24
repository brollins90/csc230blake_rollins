namespace ChatterBox.Parser
{
    using System.Collections.Generic;

    public class VariableNode : ParserNode
    {
        public Stack<ParserNode> Children { get; }

        // A Variable node is equal if the TYPE is the same
        public override string Compare => Type.ToUpperInvariant();
        public override string Type { get; }

        public VariableNode(string type, params ParserNode[] children)
        {
            Type = type;
            Children = new Stack<ParserNode>(children);
        }

        public override string ToString() => $"{string.Join(" ", Children)}";
    }
}