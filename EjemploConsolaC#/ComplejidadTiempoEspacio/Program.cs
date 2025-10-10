using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ComplejidadTiempoEspacio
{
    class Burbuja
    {
        private int[] vector;

        public void Cargar()
        {
            Console.WriteLine("Metodo de Burbuja");
            Console.Write("Cuantos longitud del vector: ");
            string linea;
            linea = Console.ReadLine();
            int cant;
            cant = int.Parse(linea);
            vector = new int[cant];
            for (int f = 0; f < vector.Length; f++)
            {
                Console.Write("Ingrese elemento " + (f + 1) + ": ");
                linea = Console.ReadLine();
                vector[f] = int.Parse(linea);
            }
            Console.WriteLine("");
        }

        //Aqui se usa el complejo en el tiempo para medir el tiempo del método burbuja
        public void MetodoBurbuja()
        {
            //Parte del complejo en el tiempo donde inicia el conteo
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int t;
            for (int a = 1; a < vector.Length; a++)
            {
                for (int b = vector.Length - 1; b >= a; b--)
                {
                    if (vector[b - 1] > vector[b])
                    {
                        t = vector[b - 1];
                        vector[b - 1] = vector[b];
                        vector[b] = t;
                    }
                }
            }

            //Termina conteo y lo representa en milisegundos
            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;

            Console.WriteLine("Tiempo en milisegundos: " + ts.TotalMilliseconds);
        }

        public void Imprimir()
        {
            Console.WriteLine("");
            Console.WriteLine("Vector ordenados en forma ascendente");
            for (int f = 0; f < vector.Length; f++)
            {
                Console.Write(vector[f] + "  ");
            }
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            Burbuja pv = new Burbuja();
            pv.Cargar();
            pv.MetodoBurbuja();
            pv.Imprimir();
        }
    }
}
