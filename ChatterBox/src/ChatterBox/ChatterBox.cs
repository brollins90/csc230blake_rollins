namespace ChatterBox
{
    using System;
    using Parser;
    using System.Diagnostics;
    using Grammar;
    using System.Linq;

    public class ChatterBox : IChatterBox
    {
        const string NeutralResponse = "Tell me something about yourself?";
        private IGrammar _grammar;

        public ChatterBox(IGrammar grammar)
        {
            _grammar = grammar;
        }

        /// <summary>
        /// 
        /// Main loop 
        /// </summary>
        public void Go()
        {
            bool running = true;
            Preload();
            string botResponse = NeutralResponse;

            do
            {
                // Ask
                AskUser(botResponse);
                // Receive
                string input = Receive();
                // make a tree
                var tree = ProcessString(input);
                // process the tree
                botResponse = ProcessParseTree(tree);

                if (tree.IsExit()) { running = false; }

            } while (running);
        }

        private void AskUser(string s)
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
            // only continue if the tree is a valid sentence
            if (!tree.IsValid()) { return NeutralResponse; }

            if ((tree.HeadNode as VariableNode).Children.First().Type == "LIKESTATEMENT")
            {
                string a = $"Do {tree.ToString()} often?";
                a = a.Replace("I ", "you ");
                a = a.Replace("i ", "you ");
                Console.WriteLine(a);
            }
            //var t = tree.HeadNode.ToString();
            //Console.WriteLine(t);



            return "Yay a good one";
        }

        public ParseTree ProcessString(string input)
        {
            return new BParser(_grammar).ParseStringToTree(input);
        }

        public string ConvertLikeTree(ParseTree tree)
        {
            

            return "";
        }

        private void Preload()
        {
            //ProcessParseTree(ProcessString(""));
        }
    }
}
