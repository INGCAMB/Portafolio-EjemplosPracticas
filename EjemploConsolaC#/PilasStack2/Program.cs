using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace PilasStack2
{
    class Program
    {
        class Recursividad
        {
            public int[] A;
            public int[] B;
            public int N;

            public void Insertar(ref Stack miPila, ref Stack miPila2, ref Stack miPila3)
            {
                miPila.Clear();
                miPila2.Clear();
                miPila3.Clear();
                Console.Write("De cuanto sera el tamaño de las dos pilas: ");
                N = int.Parse(Console.ReadLine());
                A = new int[N];
                B = new int[N];

                Random ran = new Random();
                for (int i = 0; i < N; i++)
                {
                    int valor = ran.Next(0, 100);
                    miPila.Push(valor);
                    A[i] = valor;
                }
                for (int i = 0; i < N; i++)
                {
                    int valor2 = ran.Next(0, 100);
                    miPila2.Push(valor2);
                    B[i] = valor2;
                }
            }

            public void Sumar(ref Stack miPila, ref Stack miPila2, ref Stack miPila3)
            {
                while(miPila.Count > 0 && miPila2.Count > 0)
                {
                    miPila3.Push((int)miPila.Pop() + (int)miPila2.Pop());
                }
                Console.Write("La suma fue realizada");
                Console.Write("\n");
            }

            public void Imprimir(ref Stack miPila3, int[] A, int[] B)
            {
                if (miPila3.Count > 0)
                {
                    for (int i = N - 1; i >= 0; i--)
                    {
                        Console.WriteLine(A[i]);
                    }
                    Console.Write("\n");
                    for (int i = N - 1; i >= 0; i--)
                    {
                        Console.WriteLine(B[i]);
                    }
                    Console.Write("\n");
                    foreach (int dato in miPila3)
                    {
                        Console.Write(" | |");
                        if (dato < 10)
                            Console.WriteLine(" | 0{0} |", dato);
                        else
                            Console.WriteLine(" | {0} |", dato);
                    }
                }
                else
                {
                    Console.Write("La Pila esta vacia");
                }
            }

            public void Limpiar(ref Stack miPila, ref Stack miPila2, ref Stack miPila3)
            {
                miPila.Clear();
                miPila2.Clear();
                miPila3.Clear();
                Imprimir(ref miPila, A, B);
            }
        }

        static void Main(string[] args)
        {
            int opcion;
            Recursividad re = new Recursividad();
            Stack miPila = new Stack();
            Stack miPila2 = new Stack();
            Stack miPila3 = new Stack();
            do
            {
                Console.Clear();
                Console.WriteLine("Menu Sumas de Pilas");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("\nOpcion 1 Agregar el tamaño de las dos pilas");
                Console.WriteLine("Opcion 2 Calcular la suma");
                Console.WriteLine("Opcion 3 Imprimir pilas");
                Console.WriteLine("Opcion 4 Limpiar pila");
                Console.WriteLine("Opcion 5 Salir del programa");
                Console.Write("\nQue deseas realizar? ");
                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        re.Insertar(ref miPila, ref miPila2, ref miPila3);
                        Console.Write("\nPresiona enter para regresar");
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        re.Sumar(ref miPila, ref miPila2, ref miPila3);
                        Console.Write("\nPresiona enter para regresar");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        re.Imprimir(ref miPila3, re.A, re.B);
                        Console.Write("\nPresiona enter para regresar");
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        re.Limpiar(ref miPila, ref miPila2, ref miPila3);
                        Console.Write("\nPresiona enter para regresar");
                        Console.ReadKey();
                        break;
                    case 5:
                        break;
                    default:
                        Console.Clear();
                        Console.Write("Escoga una opción valida - presiona enter");
                        Console.ReadKey();
                        break;
                }
            } while (opcion != 5);
        }
    }
}
