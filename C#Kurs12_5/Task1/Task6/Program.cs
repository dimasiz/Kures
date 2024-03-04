using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    internal class Program
    {
        static double F(double x)
        {
            return Math.Sin(1/x);
        }

        static List<double> TabulateFunction(double A, double B, int M)
        {
            double H = (B - A) / M; 
            double x = A;  
            List<double> table = new List<double>();  

            for (int i = 0; i <= M; i++)
            {
                table.Add(F(x));  
                x += H;
            }

            return table;
        }

        static void Main()
        {
          
            double A = Math.PI / 8; 
            double B = 2 / Math.PI; 
            int M = 15; 

            List<double> result = TabulateFunction(A, B, M);

          
            for (int i = 0; i < result.Count; i++)
            {
                double xi = A + i * ((B - A) / M);
                Console.WriteLine("F({0}) = {1}", xi, result[i]);
            }

            Console.ReadLine();
        }
    }
}
