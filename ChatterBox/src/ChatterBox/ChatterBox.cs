namespace ChatterBox
{
    using System;
    using B.Parser;

    public class ChatterBox : IChatterBox
    {
        public void Go()
        {


            bool running = true;
            while (running)
            {
                var input = Console.ReadLine();

                var tree = ProcessString(input);
                Console.WriteLine(tree);

                var response = ProcessParseTree(tree);
                Console.WriteLine(response);
            }
        }

        public string ProcessParseTree(ParseTree tree)
        {
            Console.WriteLine(tree);

            return "";
        }

        public ParseTree ProcessString(string input)
        {
            var parser = new BParser();
            return parser.ProcessString(input);
        }
    }
}
