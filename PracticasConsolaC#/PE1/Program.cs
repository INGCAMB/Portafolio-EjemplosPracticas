using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE1
{
    class Program
    {
        class Recursividad
        {
            Random ran = new Random();
            public int[] A;
            public int N, mayor;

            public void Generar()
            {
                Console.Write("Que tamaño de vector deseas? ");
                N = int.Parse(Console.ReadLine());
                A = new int[N];

                for(int i = 0; i < N; i++)
                {
                    A[i] = ran.Next(0,100);
                }
            }

            public int Mayor(int[] A, int N, int High)
            {
                if (N == 0)
                {
                    if (High > A[0])
                        return High;
                    else
                        return A[0];
                }
                else
                {
                    if (High > A[N])
                    {
                        return Mayor(A, N - 1, High);
                    }
                    else
                    {
                        High = A[N];
                        return Mayor(A, N - 1, High);
                    }
                }
            }

            public void Imprimir()
            {
                for(int i = 0; i < N; i++)
                {
                    Console.WriteLine(A[i]);
                }

                Console.Write("\n");
                Console.Write("\nEl mayor numero es de: " + mayor);
            }
        }

        static void Main(string[] args)
        {
            Recursividad re = new Recursividad();
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("Opcion 1 Generar vector");
                Console.WriteLine("Opcion 2 Encontrar el mayor del vector");
                Console.WriteLine("Opcion 3 Mostrar el mayor e imprimir vector");
                Console.WriteLine("Opcion 4 Salir del programa");
                Console.Write("\n\nQue desea realizar? ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        re.Generar();
                        Console.Write("\n\nPresiona enter para seguir");
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        re.mayor = re.Mayor(re.A, re.N - 1, re.A[re.N - 1]);
                        Console.Write("Numero mayor encontrad0");
                        Console.Write("\n\nPresiona enter para seguir");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        re.Imprimir();
                        Console.Write("\n\nPresiona enter para seguir");
                        Console.ReadKey();
                        break;
                    case 4:
                        break;
                    default:
                        Console.Write("Favor de ingresar una opcion valida");
                        break;
                }
            } while (opcion != 4);
        }
    }
}
