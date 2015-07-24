namespace ChatterBox.Parser
{
    using Grammar;
    using Xunit;

    public class CityParseNodeTests
    {
        private IGrammar _grammar;
        private IGrammar GetGrammar()
        {
            return _grammar ?? (_grammar = new BFileGrammarReader(@"C:\_\src\School\csc230blake_rollins - Computational Theory\ChatterBox\src\ChatterBox\Grammar\B2.BNF").ReadGrammar());
        }

        [Fact]
        public void NewYorkParse()
        {
            var grammar = GetGrammar();
            BParser parser = new BParser(grammar);

            var cityNode = new VariableNode("CITY", new TerminalNode("York"), new TerminalNode("New"));
            var expected = new ParseTree(grammar, cityNode);

            var actual = parser.ParseStringToTree("New York");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LosAngelesParse()
        {
            var grammar = GetGrammar();
            BParser parser = new BParser(grammar);

            var cityNode = new VariableNode("CITY", new TerminalNode("Angeles"), new TerminalNode("Los"));
            var expected = new ParseTree(grammar, cityNode);

            var actual = parser.ParseStringToTree("Los Angeles");

            Assert.Equal(expected, actual);
        }

        //[Fact]
        //public void NewYorkReduce()
        //{
        //    Stack<ParserNode> _internalStack = new Stack<ParserNode>();
        //}
    }
}
