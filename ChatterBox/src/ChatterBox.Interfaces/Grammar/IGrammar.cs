namespace ChatterBox.Grammar
{
    using System.Collections.Generic;

    public interface IGrammar
    {
        List<Production> Productions { get; }
        GrammarVariable First { get; }
        GrammarVariable Last { get; }
    }
}