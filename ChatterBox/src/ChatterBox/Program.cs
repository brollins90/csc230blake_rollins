namespace ChatterBox
{
    using B.Parser;
    using System;

    public class Program
    {
        public void Main(string[] args)
        {
            var chatterBox = new ChatterBox();
            chatterBox.Go();

            // "Bye!"

            //var input = Console.ReadLine();
            //var symb = new Symbolizer(input);
            //while (symb.MoveNext())
            //{
            //    Console.WriteLine(symb.Current());
            //}


        }
    }
}
