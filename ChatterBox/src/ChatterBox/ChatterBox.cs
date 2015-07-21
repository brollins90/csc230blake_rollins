namespace ChatterBox
{
    using System;
    using B.Parser;
    using System.Diagnostics;

    public class ChatterBox : IChatterBox
    {
        /// <summary>
        /// 
        /// Main loop 
        /// </summary>
        public void Go()
        {
            bool running = true;
            string botResponse = "Tell me something about yourself?";

            do
            {
                // Ask
                Ask(botResponse);
                // Receive
                string input = Receive();
                // make a tree
                var tree = ProcessString(input);
                Console.WriteLine(tree);
                
                if (tree.ToString().ToLowerInvariant().Equals("exit"))
                {
                    running = false;
                    Console.WriteLine("Bye!");
                }

                botResponse = ProcessParseTree(tree);                
            } while (running) ;
        }

        private void Ask(string s)
        {
            Console.WriteLine(s);
        }

        private string Receive()
        {
            return Console.ReadLine();
        }

        public string ProcessParseTree(ParseTree tree)
        {
            Console.WriteLine(tree);

            return "";
        }

        public ParseTree ProcessString(string input)
        {
            return new BParser().ParseStringToTree(input);
        }
    }
}
