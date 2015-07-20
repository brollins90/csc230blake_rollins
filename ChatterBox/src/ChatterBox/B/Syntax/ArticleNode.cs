namespace ChatterBox.B.Syntax
{
    using Parser;

    public class ArticleNode : TerminalNode
    {
        public ArticleNode(string text)
            : base(Grammar.B.Article, text)
        {
        }
    }
}
