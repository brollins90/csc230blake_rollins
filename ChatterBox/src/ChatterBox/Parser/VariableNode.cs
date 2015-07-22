namespace ChatterBox.Parser
{
    using System.Collections.Generic;
    using System.Linq;

    public class VariableNode : ParserNode
    {
        private Stack<ParserNode> _children;
        private string _type;

        public string Text => $"{string.Join(" ", _children)}";

        public VariableNode(string type, params ParserNode[] children)
        {
            _children = new Stack<ParserNode>(children);
            _type = type;
        }

        public override string Type => _type;
        public override string Compare => Type.ToUpperInvariant();
    }
}