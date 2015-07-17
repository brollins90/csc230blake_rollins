namespace ChatterBox
{
    using System;

    public class Program
    {
        public void Main(string[] args)
        {
            IChatterBox box = new LR1Parser();
            bool running = true;
            while (running)
            {
                var input = Console.ReadLine();
                var processed = box.ProcessString(input);
                Console.WriteLine(processed);
                if (processed.Contains("Bye")) running = false;
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
