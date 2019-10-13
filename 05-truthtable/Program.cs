using System;
using logic_gates.Operators;

namespace logic_gates
{
    class Program
    {
        static void Main(string[] args)
        {
            Bit a = new Bit("a", true);
            Bit b = new Bit("b", false);
            Bit c = new Bit("c", true);
            Bit d = new Bit("d", false);
            Bit e = new Bit("e", true);
            Bit f = new Bit("f", false);
            Bit g = new Bit("g", true);
            Bit h = new Bit("h", false);
            Bit[] list = { a, b, c, d, e, f, g, h };

            TruthTable table = new TruthTable(list);


            table.Print();
            Console.ReadLine();
        }
    }
}
