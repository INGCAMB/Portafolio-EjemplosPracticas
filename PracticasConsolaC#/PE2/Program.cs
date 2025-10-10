using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("El suma de sus digitos 123 es: " + invertir(123));

            int invertir(int n)
            {
                if (n < 10)
                {         //caso base
                    return n;
                }
                else
                {
                    return (n % 10) + invertir(n / 10);
                }

            }
            Console.ReadKey();
        }
    }
}
