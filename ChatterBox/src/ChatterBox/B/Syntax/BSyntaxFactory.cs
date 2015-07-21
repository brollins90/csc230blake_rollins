namespace ChatterBox.B.Syntax
{
    using Parser;

    public class BTerminalFactory : ITerminalFactory
    {
        public ParserNode CreateNode(string input)
        {
            if (input.ToLowerInvariant().Equals("a"))
            {
                return new ArticleNode(input);
            }
            else if (input.ToLowerInvariant().Equals("the"))
            {
                return new ArticleNode(input);
            }
            else if (input.ToLowerInvariant().Equals("cat"))
            {
                return new NounNode(input);
            }
            else if (input.ToLowerInvariant().Equals("dog"))
            {
                return new NounNode(input);
            }
            else if (input.ToLowerInvariant().Equals("fish"))
            {
                return new NounNode(input);
            }
            else if (input.ToLowerInvariant().Equals("bites"))
            {
                return new VerbNode(input);
            }
            else if (input.ToLowerInvariant().Equals("chases"))
            {
                return new VerbNode(input);
            }
            else if (input.ToLowerInvariant().Equals("exit"))
            {
                return new TerminalNode(Grammar.B.Exit, input);
            }
            return null;
        }
    }
}
