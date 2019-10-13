using logic_gates.Operators;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace logic_gates
{
    class TruthTable
    {
        Bit[] List { set; get; }

        public TruthTable(Bit[] components)
        {
            List = components;
        }

        public void Print()
        {
            int trueV = 1;
            int falseV = 0;

            int n = List.Length;
            int rows = Pow(n); //1,2,4,8,16,32,64,128

            PrintVariables(List);
            for (int i = 0; i < rows; i++) //if n = 4; it loops 16 times
            {
                for (int j = n - 1; j >= 0; j--) //if n = 4; it loops 4 times; j goes from 4 to 0
                {
                    if (i / Pow(j) % 2 == 0)
                    {
                        Console.Write("{0} ", trueV);
                    }
                    else
                    {
                        Console.Write("{0} ", falseV);
                    }
                }
                Console.Write(" |  ");
                Console.WriteLine();
                if (i % 4 == 3)
                {
                    PrintLine();
                }
            }
        }

        public int Pow(int x)
        {
            return (int)Math.Pow(2, x);
        }

        public void PrintVariables(Bit[] bits)
        {
            Bit last = bits.Last();
            foreach (Bit c in bits)
            {
                if(c.Equals(last))
                {
                    Console.Write("{0}  |  ", c.Name);
                } else
                {
                    Console.Write("{0} ", c.Name);
                }
            }
            Console.WriteLine();
            PrintLine();
        }

        public void PrintLine()
        {
            Console.WriteLine("------------------------------------------------------");
        }
    }
}
