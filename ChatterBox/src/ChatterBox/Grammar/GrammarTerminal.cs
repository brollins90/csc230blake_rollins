namespace ChatterBox.Grammar
{
    using Parser;

    public class GrammarTerminal : GrammarSymbol
    {
        public string Value { get; set; }

        public GrammarTerminal(string value)
        {
            Value = value;
        }

        public override string Compare => Value;
        public ParserNode ToNode()
        {
            return new TerminalNode(Value);
        }
        public override string ToString() => $"{Value}";
    }
}
