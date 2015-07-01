using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatterBox;

namespace CompTheoryA2
{
    public class Program
    {

        // xx
        // xyz
        // xyzzy

        public void Main(string[] args)
        {
            IChatterBox box = new ChatterBox.ChatterBox();
            Console.WriteLine(box.Input("How are you?"));

            // "Bye!"

        }
    }
}
