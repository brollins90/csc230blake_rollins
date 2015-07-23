namespace ChatterBoxTests.Parser
{
    using ChatterBox.Grammar;
    using ChatterBox.Parser;
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

            var t1 = new TerminalNode("new");
            var t2 = new TerminalNode("york");
            var t3 = new VariableNode("CITY", t1, t2);
            var expected = new ParseTree(grammar) { HackingStack = new Stack<IParserNode>(new[] { t3 }) };

            var actual = parser.ParseStringToTree("New York");

            Assert.Equal(expected, actual);

        }
    }
}
