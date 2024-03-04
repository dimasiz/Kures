using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ввидите а=");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Ввидите b=");
            int b = int.Parse(Console.ReadLine());

            Console.WriteLine("For");
            for(int i = a;i <= b; i++)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("While");
            int p = a;
            while(p <= b)
            {
                Console.WriteLine(p++);
            }

            Console.WriteLine("do while");
            do
            {
                Console.WriteLine(a++);
            } while (a <= b);
            Console.ReadLine();


        }
    }
}
