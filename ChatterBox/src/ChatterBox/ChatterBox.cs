﻿namespace ChatterBox
{
    using System;
    using Parser;
    using System.Diagnostics;

    public class ChatterBox : IChatterBox
    {
        const string NeutralResponse = "Tell me something about yourself?";

        /// <summary>
        /// 
        /// Main loop 
        /// </summary>
        public void Go()
        {
            bool running = true;
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
            // only continue if the tree is a valid sentence
            if (!tree.IsValid()) { return NeutralResponse; }


            return "Yay a good one";
        }

        public ParseTree ProcessString(string input)
        {
            return new BParser().ParseStringToTree(input);
        }
    }
}
