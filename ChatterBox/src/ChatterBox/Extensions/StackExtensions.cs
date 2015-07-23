namespace ChatterBox.Extensions
{
    using Parser;
    using System.Collections.Generic;

    public static class StackExtensions
    {
        public static IParserNode DoPop(this Stack<IParserNode> i)
        {
            if (i.Count > 0)
            {
                return i.Pop();
            }
            return null;
        }

        public static void DoPush(this Stack<IParserNode> i, IParserNode s)
        {
            if (s != null)
            {
                i.Push(s);
            }
        }
    }
}