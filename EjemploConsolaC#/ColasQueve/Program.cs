using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ColasQueve
{
    class Program
    {
        static void Main(string[] args)
        {
            string palabra, ingpalabra;
            int numero;
            Queue miCola = new Queue();
            Console.Write("Cuantas palabras quieres agregar a la cola? ");
            numero = int.Parse(Console.ReadLine());
            Console.Write("\n");
            for (int i = 0; i < numero; i++)
            {
                Console.Write("Dame la palabra " + (i+1) + ": ");
                ingpalabra = Console.ReadLine();
                miCola.Enqueue(ingpalabra);
            }
            Console.Write("\n");
            Console.WriteLine("Elementos totales que se encuentran en la cola: " + miCola.Count);
            Console.WriteLine("El proximo elemento que queda en la cola es: " + miCola.Peek());
            Console.Write("\n");
            for (int i = 0; i < numero; i++)
            {
                palabra = (string)miCola.Dequeue();
                Console.WriteLine(palabra);
            }
            Console.Write("\n");
            Console.WriteLine("Elementos totales que se encuentran en la cola: " + miCola.Count);
            Console.ReadKey();
        }
    }
}
