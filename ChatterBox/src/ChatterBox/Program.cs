namespace ChatterBox
{
    using global::ChatterBox.B.Parser;
    using System;

    public class Program
    {
        public void Main(string[] args)
        {
            var box = new BParser();
            bool running = true;
            while (running)
            {
                var input = Console.ReadLine();
                var processed = box.ProcessString(input);
                Console.WriteLine(processed);
                //if (processed.Contains("Bye")) running = false;
            }
            Console.WriteLine(box.ProcessString("How are you?"));

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
