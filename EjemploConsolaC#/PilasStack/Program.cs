using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace PilasStack
{
    class Program
    {
        class Recursividad
        {
            public void Insertar(ref Stack miPila)
            {
                Console.Write("Ingrese valor: ");
                int valor = int.Parse(Console.ReadLine());
                miPila.Push(valor);

                Console.Write("\nElemento " + valor + " agregado a la pila");
            }

            public void Eliminar(ref Stack miPila)
            {
                if (miPila.Count > 0)
                {
                    int valor = (int)miPila.Pop();
                    Console.WriteLine("Elemento " + valor + " eliminado");
                }
                else
                {
                    Imprimir(ref miPila);
                }
            }

            public void Imprimir(ref Stack miPila)
            {
                if (miPila.Count > 0)
                {
                    Console.WriteLine("");
                    foreach (int dato in miPila)
                    {
                        Console.WriteLine(" | |");
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

            public void Limpiar(ref Stack miPila)
            {
                miPila.Clear();
                Imprimir(ref miPila);
            }
        }

        static void Main(string[] args)
        {
            int opcion;
            Recursividad re = new Recursividad();
            Stack miPila = new Stack();
            do
            {
                Console.Clear();
                Console.WriteLine("Menu Pila");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("\nOpcion 1 Agregar un elemento a la pila");
                Console.WriteLine("Opcion 2 Eliminar un elemento a la pila");
                Console.WriteLine("Opcion 3 Imprimir pila");
                Console.WriteLine("Opcion 4 Limpiar pila");
                Console.WriteLine("Opcion 5 Salir del programa");
                Console.Write("\nQue deseas realizar? ");
                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        re.Insertar(ref miPila);
                        Console.Write("\n\nPresiona enter para regresar");
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        re.Eliminar(ref miPila);
                        Console.Write("\nPresiona enter para regresar");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        re.Imprimir(ref miPila);
                        Console.Write("\nPresiona enter para regresar");
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        re.Limpiar(ref miPila);
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
