namespace ChatterBox.Grammar
{
    using Parser;
    using System;

    public abstract class GrammarSymbol : IEquatable<GrammarSymbol>
    {
        public abstract string Compare { get; }


        public override bool Equals(object obj)
        {
            if (obj == null) { return false; }
            return Equals(obj as GrammarSymbol);
        }

        public bool Equals(GrammarSymbol other)
        {
            if ((object)other == null) { return false; }
            return Compare.Equals(other.Compare);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        // Ugly hack?
        public bool Equals(ParserNode other)
        {
            if ((object)other == null) { return false; }
            return Compare.Equals(other.Compare);
        }
    }
}