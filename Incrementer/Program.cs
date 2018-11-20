using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incrementer
{
    class Program
    {
        static void Main(string[] args)
        {

            var test = new Identity("A22");
            test.Increment();
            Console.Write(test);

            System.Console.WriteLine("Testing 000 - 030 ...");
            Identity i = new Identity("000");
            for(int count = 0; count<31; count++)
            {
                System.Console.Write(i + "\t");
                i.Increment();
            }

            i.Set("090");
            System.Console.WriteLine("\n\nTesting 090 - 120 ...");
            for (int count = 0; count < 31; count++)
            {
                System.Console.Write(i + "\t");
                i.Increment();
            }

            i.Set("990");
            System.Console.WriteLine("\n\nTesting 990 - A20 ...");
            for (int count = 0; count < 31; count++)
            {
                System.Console.Write(i + "\t");
                i.Increment();
            }

            i.Set("Z90");
            System.Console.WriteLine("\n\nTesting Z90 - ZA0 ...");
            for (int count = 0; count < 31; count++)
            {
                System.Console.Write(i + "\t");
                i.Increment();
            }

            i.Set("ZY0");
            System.Console.WriteLine("\n\nTesting ZY0 - ZZZ ...");
            while(i.ToString() != "ZZZ")
            {
                System.Console.Write(i + "\t");
                i.Increment();
            }
            System.Console.WriteLine(i + "\t");

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }      
    }
}
