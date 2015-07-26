namespace ChatterBox.Grammar
{
    using Parser;
    using System.Collections.Generic;
    using System.Diagnostics;

    public class GrammarVariable : GrammarSymbol
    {
        private static Dictionary<string, GrammarVariable> _variables = new Dictionary<string, GrammarVariable>();

        public static GrammarVariable Get(string name)
        {
            name = name.ToUpperInvariant();
            if (!_variables.ContainsKey(name))
            {
                _variables[name] = new GrammarVariable(name);
            }
            return _variables[name];
        }

        public string Name { get; set; }

        private GrammarVariable(string name)
        {
            Name = name;
        }
        public override string Compare => Name;

        public ParserNode ToNode(params ParserNode[] nodes)
        {
            //Debug.WriteLine($"reduced to {Name} ({string.Join<ParserNode>(", ", nodes)})");
            return new VariableNode(Name, nodes);
        }

        public override string ToString() => $"{Name}";
    }
}
