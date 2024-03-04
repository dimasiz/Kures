using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите X=");
            double x = int.Parse(Console.ReadLine());
            double y;
            if (1 < x && x > 2)
            {
                y = Math.Pow((x - 2), 2) + 6;
                Console.WriteLine($"Функция равна:={y}");
            }
            else if (x >= 2)
            {
                y = Math.Log10(x + 3 * Math.Sqrt(x));
                Console.WriteLine($"Функция равна:={y}");
            }
            else 
            {
                Console.WriteLine("Функция не решаема");
            }

            Console.ReadLine();
        }
    }
}
