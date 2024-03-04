using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ввидете число от 6 до 14");
            int k = int.Parse(Console.ReadLine());

            if (k >= 6 && k <= 14)
            {
                switch (k)
                {
                    case 11:
                    Console.WriteLine("Валет");
                    break;

                    case 12:
                    Console.WriteLine("Дамма");
                    break;

                    case 13:
                    Console.WriteLine("Король");
                    break;

                    case 14:
                    Console.WriteLine("Король");
                    break;

                    default:
                        Console.WriteLine(k);
                    break;
                }
            }
            else
            {
                Console.WriteLine("Вы ввели не то число");
            }

            Console.ReadLine();
        }
    }
}
