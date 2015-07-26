namespace ChatterBox.Parser
{
    using Grammar;
    using System;
    using System.Collections.Generic;
    using System.Collections;

    public abstract class ParserNode : IEquatable<ParserNode>
    {
        private Stack<ParserNode> _children;
        private GrammarSymbol _value;
        internal string FirstChildType => _children?.Peek()._value.Compare;

        public ParserNode(GrammarSymbol symbol, Stack<ParserNode> children)
        {
            _value = symbol;
            _children = children;
        }


        public override bool Equals(object obj)
        {
            if (obj == null) { return false; }
            return Equals(obj as ParserNode);
        }

        public bool Equals(ParserNode other)
        {
            if ((object)other == null) { return false; }
            return _value.Equals(other._value);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        // Ugly hack?
        public bool Equals(GrammarSymbol other)
        {
            if ((object)other == null) { return false; }
            return _value.Equals(other);
        }

        public IEnumerable<ParserNode> NodeEnumerator
        {
            get
            {
                yield return this;
                if (_children != null)
                {
                    foreach (ParserNode child in _children)
                    {
                        IEnumerator<ParserNode> childEnum = child.NodeEnumerator.GetEnumerator();
                        while (childEnum.MoveNext())
                            yield return childEnum.Current;
                    }
                }
            }
        }
    }
}