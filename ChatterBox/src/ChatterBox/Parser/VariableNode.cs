namespace ChatterBox.Parser
{
    using System.Collections.Generic;

    public class VariableNode : IParserNode
    {
        private string _type;

        public Stack<IParserNode> Children { get; }
        public string Compare => Type.ToUpperInvariant();
        public string Text => $"{string.Join(" ", Children)}";
        public string Type => _type;

        public VariableNode(string type, params IParserNode[] children)
        {
            _type = type;
            Children = new Stack<IParserNode>(children);
        }

        public override string ToString() => Text;
    }
}