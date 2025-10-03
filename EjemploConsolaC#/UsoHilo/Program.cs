using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HilosEjemplo
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(metodo);
            t.Start("Programación con hilos");
            t.Join();
            Thread.Sleep(3000);
            Console.Write("\nHilo finalizado");
            Console.Read();
        }

        static void metodo(object o)
        {
            Console.Write(o.ToString());
            for(int i = 1; i <= 100; i++)
            {
                Console.Write(i + ",");
            }
        }
    }
}
