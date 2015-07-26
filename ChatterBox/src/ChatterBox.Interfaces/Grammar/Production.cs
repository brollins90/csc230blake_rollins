namespace ChatterBox.Grammar
{
    public class Production
    {
        public GrammarVariable Variable { get; set; }
        public GrammarMatcher Matcher { get; set; }

        public Production(GrammarVariable variable, GrammarMatcher matcher)
        {
            Variable = variable;
            Matcher = matcher;
        }

        public override string ToString() => $"{Variable} : {Matcher}";
    }
}