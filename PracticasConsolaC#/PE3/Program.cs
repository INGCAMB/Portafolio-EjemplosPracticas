using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("El maximo comun divisor de 10 y 20 es: " + sacar_mcd(10, 20));

            int sacar_mcd(int a, int b)
            {
                if (b == 0)
                {
                    return a;
                }
                else
                {
                    return sacar_mcd(b, a % b);
                }
            }
            Console.ReadKey();
        }
    }
}
