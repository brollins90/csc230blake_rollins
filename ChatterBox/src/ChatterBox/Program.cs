using ChatterBox.Grammar;

namespace ChatterBox
{
    public class Program
    {
        public void Main(string[] args)
        {
            var reader = new BFileGrammarReader(@"C:\_\src\School\csc230blake_rollins - Computational Theory\ChatterBox\src\ChatterBox.Parser\Grammar\B3.BNF");
            var grammar = reader.ReadGrammar();

            var chatterBox = new ChatterBox(grammar);
            chatterBox.Go();
        }
    }
}