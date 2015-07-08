namespace ChatterBox
{
    using System;

    public class Program
    {
        public void Main(string[] args)
        {
            IChatterBox box = new ChatterBox();
            bool running = true;
            while (running)
            {
                var input = Console.ReadLine();
                var processed = box.ProcessString(input);
                Console.WriteLine(processed);
                if (processed.Contains("Bye")) running = false;
            }
            //Console.WriteLine(box.ProcessString("How are you?"));

            // "Bye!"

        }
    }
}
