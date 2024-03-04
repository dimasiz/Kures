using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите a=");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Введите b=");
            int b = int.Parse(Console.ReadLine());

            Console.Write("Введите c=");
            int c = int.Parse(Console.ReadLine());

            if(a == b || b == c ||c == a)
            {
                Console.WriteLine("Треугольник Равнобедренный");
            }
            else
            {
                Console.WriteLine("Треугольник не равнобедренный");
            }
            Console.ReadLine();
        }
    }
}
