﻿namespace ChatterBox
{
    using Grammar;
    using Parser;
    using Processors;
    using Processors.Distance;
    using System;
    using System.Collections.Generic;

    public class ChatterBox : IChatterBox
    {
        const string NeutralResponse = "Tell me something about yourself?";
        private IGrammar _grammar;
        private List<IProcessor> _processors;

        public ChatterBox(IGrammar grammar)
        {
            _grammar = grammar;
            _processors = new List<IProcessor>();

            _processors.Add(new LikeProcessor());
            _processors.Add(new DistanceProcessor());
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

        public string ProcessParseTree(ParserTree tree)
        {
            Console.WriteLine(tree);

            // only continue if the tree is a valid sentence
            if (!tree.IsValid()) { return NeutralResponse; }

            string response = string.Empty;
            bool foundAResponse = false;
            for (int i = 0; i < _processors.Count && !foundAResponse; i++)
            {
                if (_processors[i].TryProcess(tree, out response))
                {
                    foundAResponse = true;
                }
            }

            if (!foundAResponse)
            {
                response = NeutralResponse;
            }

            return response;



            ////var t = tree.HeadNode.ToString();
            ////Console.WriteLine(t);



            //return "Yay a good one";
        }

        public ParserTree ProcessString(string input)
        {
            return new BParser(_grammar).ParseStringToTree(input);
        }

        public string ConvertLikeTree(ParserTree tree)
        {


            return "";
        }

        private void Preload()
        {
            //ProcessParseTree(ProcessString("New York"));

            //ProcessParseTree(ProcessString("A 2443 mile road connects New York to Los Angeles"));
            //ProcessParseTree(ProcessString("A 789 mile road connects New York to Chicago"));
            //ProcessParseTree(ProcessString("A 1626 mile road connects New York to Houston"));
            //ProcessParseTree(ProcessString("A 96 mile road connects New York to Philadelphia"));
            //ProcessParseTree(ProcessString("A 2406 mile road connects New York to Phoenix"));
            //ProcessParseTree(ProcessString("A 1821 mile road connects New York to San Antonio"));
            //ProcessParseTree(ProcessString("A 2761 mile road connects New York to San Diego"));
            //ProcessParseTree(ProcessString("A 1546 mile road connects New York to Dallas"));
            //ProcessParseTree(ProcessString("A 2939 mile road connects New York to San Jose"));

            //ProcessParseTree(ProcessString("A 2015 mile road connects Los Angeles to Chicago"));
            //ProcessParseTree(ProcessString("A 1569 mile road connects Los Angeles to Houston"));
            //ProcessParseTree(ProcessString("A 2711 mile road connects Los Angeles to Philadelphia"));
            //ProcessParseTree(ProcessString("A 418 mile road connects Los Angeles to Phoenix"));
            //ProcessParseTree(ProcessString("A 1374 mile road connects Los Angeles to San Antonio"));
            //ProcessParseTree(ProcessString("A 120 mile road connects Los Angeles to San Diego"));
            //ProcessParseTree(ProcessString("A 1458 mile road connects Los Angeles to Dallas"));
            //ProcessParseTree(ProcessString("A 339 mile road connects Los Angeles to San Jose"));

            //ProcessParseTree(ProcessString("A 1083 mile road connects Chicago to Houston"));
            //ProcessParseTree(ProcessString("A 759 mile road connects Chicago to Philadelphia"));
            //ProcessParseTree(ProcessString("A 1753 mile road connects Chicago to Phoenix"));
            //ProcessParseTree(ProcessString("A 1242 mile road connects Chicago to San Antonio"));
            //ProcessParseTree(ProcessString("A 2076 mile road connects Chicago to San Diego"));
            //ProcessParseTree(ProcessString("A 968 mile road connects Chicago to Dallas"));
            //ProcessParseTree(ProcessString("A 2076 mile road connects Chicago to San Jose"));

            //ProcessParseTree(ProcessString("A 1545 mile road connects Houston to Philadelphia"));
            //ProcessParseTree(ProcessString("A 1175 mile road connects Houston to Phoenix"));
            //ProcessParseTree(ProcessString("A 197 mile road connects Houston to San Antonio"));
            //ProcessParseTree(ProcessString("A 1471 mile road connects Houston to San Diego"));
            //ProcessParseTree(ProcessString("A 239 mile road connects Houston to Dallas"));
            //ProcessParseTree(ProcessString("A 1908 mile road connects Houston to San Jose"));

            //ProcessParseTree(ProcessString("A 2342 mile road connects Philadelphia to Phoenix"));
            //ProcessParseTree(ProcessString("A 1742 mile road connects Philadelphia to San Antonio"));
            //ProcessParseTree(ProcessString("A 2696 mile road connects Philadelphia to San Diego"));
            //ProcessParseTree(ProcessString("A 1467 mile road connects Philadelphia to Dallas"));
            //ProcessParseTree(ProcessString("A 2909 mile road connects Philadelphia to San Jose"));

            //ProcessParseTree(ProcessString("A 980 mile road connects Phoenix to San Antonio"));
            //ProcessParseTree(ProcessString("A 356 mile road connects Phoenix to San Diego"));
            //ProcessParseTree(ProcessString("A 1064 mile road connects Phoenix to Dallas"));
            //ProcessParseTree(ProcessString("A 734 mile road connects Phoenix to San Jose"));

            //ProcessParseTree(ProcessString("A 1277 mile road connects San Antonio to San Diego"));
            //ProcessParseTree(ProcessString("A 273 mile road connects San Antonio to Dallas"));
            //ProcessParseTree(ProcessString("A 1713 mile road connects San Antonio to San Jose"));

            //ProcessParseTree(ProcessString("A 1358 mile road connects San Diego to Dallas"));
            //ProcessParseTree(ProcessString("A 459 mile road connects San Diego to San Jose"));

            //ProcessParseTree(ProcessString("A 1690 mile road connects Dallas to San Jose"));

            //ProcessParseTree(ProcessString("What is the shortest route between Dallas and Houston ?"));

            ProcessParseTree(ProcessString("A 173 mile road connects Seattle to Portland"));
            ProcessParseTree(ProcessString("A 580 mile road connects Portland to Sacramento"));
            ProcessParseTree(ProcessString("A 384 mile road connects Sacramento to Los Angeles"));
            ProcessParseTree(ProcessString("A 120 mile road connects Los Angeles to San Diego"));



            //ProcessParseTree(ProcessString("A 173 mile road connects Seattle to Portland"));
            //ProcessParseTree(ProcessString("A 173 mile road connects Seattle to Portland"));
            //ProcessParseTree(ProcessString("A 173 mile road connects Seattle to Portland"));
            //ProcessParseTree(ProcessString("A 173 mile road connects Seattle to Portland"));
            //ProcessParseTree(ProcessString("A 173 mile road connects Seattle to Portland"));
            //ProcessParseTree(ProcessString("A 173 mile road connects Seattle to Portland"));
            //ProcessParseTree(ProcessString("A 173 mile road connects Seattle to Portland"));
        }
    }
}
