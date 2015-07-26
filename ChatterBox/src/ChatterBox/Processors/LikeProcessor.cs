namespace ChatterBox.Processors
{
    using System;
    using System.Collections.Generic;
    using Parser;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;

    public class LikeProcessor : IProcessor
    {
        public bool TryProcess(ParserTree tree, out string response)
        {
            response = string.Empty;

            if ((tree.HeadNode as VariableNode).Children.First().Type == "LIKESTATEMENT")
            {
                string previousNonTerminal = string.Empty;

                StringBuilder sb = new StringBuilder();

                sb.Append("Do ");
                foreach (var f in tree.HeadNode)
                {
                    if (f.Type == "TERMINAL")
                    {
                        if (previousNonTerminal == "PRONOUN")
                        {
                            sb.Append($"{ResponseUtils.PronounReverse(f.ToString())} ");
                        }
                        else
                        {
                            sb.Append($"{f} ");
                        }
                    }
                    else
                    {
                        previousNonTerminal = f.Type;
                    }
                    //Debug.WriteLine($"f: {f.Type} {f.ToString()}");
                }
                sb.Append("often?");

                response = sb.ToString();
                return true;

                //string a = $"Do {tree.ToString()} often?";
                //a = a.Replace("I ", "you ");
                //a = a.Replace("i ", "you ");
                //Console.WriteLine(a);
            }

            return false;
        }
    }

    public static class ResponseUtils
    {
        public static string PronounReverse(string inString)
        {
            if (inString.Equals("i"))
            {
                return "you";
            }
            else if (inString.Equals("I"))
            {
                return "you";
            }
            else if (inString.Equals("you"))
            {
                return "I";
            }
            else
            {
                return "IDK";
            }
        }
    }
}