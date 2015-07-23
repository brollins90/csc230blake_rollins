namespace ChatterBox.Parser
{
    using Grammar;
    using System.Collections.Generic;
    using Xunit;

    public class CityParseNodeTests
    {
        [Fact]
        public void NewYorkParse()
        {
            var reader = new BFileGrammarReader(@"C:\_\src\School\csc230blake_rollins - Computational Theory\ChatterBox\src\ChatterBox\Grammar\B2.BNF");
            var grammar = reader.ReadGrammar();
            BParser parser = new BParser(grammar);
            
            var t3 = new VariableNode("CITY", new TerminalNode("York"), new TerminalNode("New"));
            var expected = new ParseTree(grammar) { HackingStack = new Stack<IParserNode>(new[] { t3 }) };

            var actual = parser.ParseStringToTree("New York");

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void NewYorkReduce()
        {
            Stack<IParserNode> _internalStack = new Stack<IParserNode>();
        }
    }
}
