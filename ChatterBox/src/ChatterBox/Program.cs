namespace ChatterBox
{
    using System;

    public class Program
    {        
        public void Main(string[] args)
        {
            IChatterBox box = new ChatterBox();
            Console.WriteLine(box.ProcessString("How are you?"));

            // "Bye!"

        }
    }
}
