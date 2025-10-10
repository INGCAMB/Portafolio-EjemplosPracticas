using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploPilas
{
    class Program
    {
        class Pilas
        {
            public int Max, Top, Apuntador;
            public float Elemento;
            public float[] Pila;

            public Pilas(int M)
            {
                Max = M;
                Pila = new float[M];
                Top = -1;
            }

            public void Push(float Elemento)
            {
                if (Top != Max - 1)
                {
                    Top = Top + 1;
                    Pila[Top] = Elemento;
                    Console.Write("Dato agregado a la pila");
                }
                else
                {
                    Console.Write("La pila esta llena");
                }
            }

            public void Pop()
            {
                if (Top != -1)
                {
                    Console.Write("Elemento eliminado: " + Pila[Top]);
                    Pila[Top] = 0;
                    Top = Top - 1;
                }
                else
                {
                    Console.Write("La pila esta vacia");
                }
            }

            public void Recorrer()
            {
                if (Top != -1)
                {
                    Apuntador = Top;
                    while (Apuntador != -1)
                    {
                        Console.WriteLine("Elemento: " + Pila[Apuntador] + " Posicion: " + Apuntador);
                        Apuntador = Apuntador - 1;
                    }
                }
                else
                {
                    Console.Write("La pila esta vacia");
                }
            }

            public void Buscar(float Elemento)
            {
                if (Top != -1)
                {
                    Apuntador = Top;
                    while (Apuntador != -1)
                    {
                        if (Pila[Apuntador] == Elemento)
                        {
                            Console.WriteLine("Elemento: " + Elemento + " localizacion posicion: " + Apuntador);
                        }
                        else
                        {
                            Apuntador = Apuntador - 1;
                        }
                    }
                    Console.WriteLine("Elemento: " + Elemento + " NO esta en la pila");
                }
                else
                {
                    Console.Write("La pila esta vacia");
                }
            }
        }

        static void Main(string[] args)
        {
            char opcion;
            Pilas pi = null;

            do
            {
                Console.Clear();
                Console.WriteLine("Menu pilas");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("\nOpcion a) Crear pilas");
                Console.WriteLine("Opcion b) Insertar elemento en la pila");
                Console.WriteLine("Opcion c) Eliminar elemento en la pila");
                Console.WriteLine("Opcion d) Recorrer pila");
                Console.WriteLine("Opcion e) Buscar un elemento en la pila");
                Console.WriteLine("Opcion f) Salir del programa");
                Console.Write("\nQue deseas realizar? ");
                opcion = char.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 'a':
                        Console.Clear();
                        Console.Write("Dame el tamaño del vector: ");
                        int M = int.Parse(Console.ReadLine());
                        pi = new Pilas(M);
                        Console.Write("\nPresiona enter para regresar");
                        Console.ReadKey();
                        break;
                    case 'b':
                        if (pi is null)
                        {
                            Console.Clear();
                            Console.Write("La pila no tiene tamaño favor de ir a la opcion a) - Presiona enter para regresar");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Clear();
                            Console.Write("Ingresa el dato a agregar a la pila: ");
                            pi.Elemento = float.Parse(Console.ReadLine());
                            pi.Push(pi.Elemento);
                            Console.Write("\nPresiona enter para regresar");
                            Console.ReadKey();
                        }
                        break;
                    case 'c':
                        if (pi is null)
                        {
                            Console.Clear();
                            Console.Write("La pila no tiene tamaño favor de ir a la opcion a) - Presiona enter para regresar");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Clear();
                            pi.Pop();
                            Console.Write("\nPresiona enter para regresar");
                            Console.ReadKey();
                        }
                        break;
                    case 'd':
                        if (pi is null)
                        {
                            Console.Clear();
                            Console.Write("La pila no tiene tamaño favor de ir a la opcion a) - Presiona enter para regresar");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Clear();
                            pi.Recorrer();
                            Console.Write("\nPresiona enter para regresar");
                            Console.ReadKey();
                        }
                        break;
                    case 'e':
                        if (pi is null)
                        {
                            Console.Clear();
                            Console.Write("La pila no tiene tamaño favor de ir a la opcion a) - Presiona enter para regresar");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Clear();
                            Console.Write("Que numero deseas buscar: ");
                            pi.Elemento = float.Parse(Console.ReadLine());
                            pi.Busqueda(pi.Elemento);
                            Console.Write("\nPresiona enter para regresar");
                            Console.ReadKey();
                        }
                        break;
                    case 'f':
                        Console.Clear();
                        Console.Write("salida del programa");
                        Console.ReadKey();
                        break;
                    default:
                        Console.Clear();
                        Console.Write("Opcion no valida, favor de poner una opcion valida");
                        Console.ReadKey();
                        break;
                }
            } while (opcion != 'f');
        }
    }
}
