namespace ChatterBox.B.Syntax
{
    using Parser;

    public class NounPhraseNode : ParserNode
    {
        public ArticleNode Article { get; private set; }
        public NounNode Noun { get; private set; }
        public PrepositionNode Preposition { get; private set; }

        public NounPhraseNode(ArticleNode article, NounNode noun)
            : base($"{article.Text} {noun.Text}")
        {
            Article = article;
            Noun = noun;
        }

        public NounPhraseNode(ArticleNode article, NounNode noun, PrepositionNode preposition)
            : base($"{article.Text} {noun.Text}")
        {
            Article = article;
            Noun = noun;
            Preposition = preposition;
        }
    }
}
