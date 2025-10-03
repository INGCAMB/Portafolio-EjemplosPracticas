using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_raiz
{
    class Program
    {
        static void Main(string[] args)
        {
            float valor;
            float resultado;
            Console.Write("Dame la raiz: ");
            valor = float.Parse(Console.ReadLine());
            resultado = (float)Math.Sqrt(valor);
            //Este es para de raiz a decimales
            Console.Write("\n\n" + resultado);
            //Ahora de decimales a raiz
            Console.Write("\n\n" + Math.Round(resultado));
            Console.ReadKey();
        }
    }
}
