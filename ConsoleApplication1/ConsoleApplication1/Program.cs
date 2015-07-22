using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Dot> dots = new List<Dot>();
            dots.Add(new Dot { Group = 1, True = true, Type = 'X' });
            dots.Add(new Dot { Group = 1, True = false, Type = 'Y' });
            dots.Add(new Dot { Group = 1, True = true, Type = 'Z' });
            dots.Add(new Dot { Group = 2, True = false, Type = 'X' });
            dots.Add(new Dot { Group = 2, True = true, Type = 'Y' });
            dots.Add(new Dot { Group = 2, True = false, Type = 'Z' });
            dots.Add(new Dot { Group = 3, True = false, Type = 'X' });
            dots.Add(new Dot { Group = 3, True = false, Type = 'Y' });
            dots.Add(new Dot { Group = 3, True = true, Type = 'Z' });


            foreach (var dot1 in dots)
            {
                foreach (var dot2 in dots)
                {
                    if ((dot1.Group != dot2.Group))
                    {
                        if ((dot1.Type != dot2.Type) || ((dot1.Type == dot2.Type) && (dot1.True == dot2.True)))
                        {
                            dot1.Connections.Add(dot2);
                        }
                    }
                }
            }

            Console.ReadLine();
        }
    }

    class Dot
    {
        public int Group { get; set; }
        public bool True { get; set; }
        public char Type { get; set; }
        public List<Dot> Connections { get; set; } = new List<Dot>();

        public override string ToString() => $"{Group} {Type}";
    }
}
