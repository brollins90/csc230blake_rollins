﻿namespace ChatterBox.Parser
{
    using Grammar;
    using System;
    using System.Collections.Generic;
    using System.Collections;

    public abstract class ParserNode : IEquatable<ParserNode>, IEnumerable<ParserNode>
    {
        public abstract string Compare { get; }
        public abstract string Type { get; }


        public override bool Equals(object obj)
        {
            if (obj == null) { return false; }
            return Equals(obj as ParserNode);
        }

        public bool Equals(ParserNode other)
        {
            if ((object)other == null) { return false; }
            return Compare.Equals(other.Compare);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        // Ugly hack?
        public bool Equals(GrammarSymbol other)
        {
            if ((object)other == null) { return false; }
            return Compare.Equals(other.Compare);
        }

        public abstract IEnumerator<ParserNode> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}