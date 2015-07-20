namespace ChatterBox.B.Extensions
{
    using Parser;
    using Syntax;
    using System.Collections.Generic;

    public static class StackExtensions
    {
        public static ParserNode DoPop(this Stack<ParserNode> i)
        {
            if (i.Count > 0)
            {
                return i.Pop();
            }
            return null;
        }

        public static void DoPush(this Stack<ParserNode> i, ParserNode s)
        {
            if (s != null)
            {
                i.Push(s);
            }
        }

        public static void DoPush(this Stack<ParserNode> i, string s)
        {
            ISyntaxFactory factory = new BSyntaxFactory();

            if (!string.IsNullOrWhiteSpace(s))
            {
                i.Push(factory.CreateNode(s));
            }
        }
    }
}