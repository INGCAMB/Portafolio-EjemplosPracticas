using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploColas
{
    class Program
    {
        public class Colas
        {
            public int Max, Frente, Final, Apuntador;
            public float Elemento;
            public float[] Cola;

            public Colas(int M)
            {
                Max = M;
                Cola = new float[M];
                Frente = -1;
                Final = -1;
            }

            public void Push(float Elemento)
            {
                if(Frente == 0 && Final == Max - 1)
                {
                    Console.Write("La cola esta llena");
                }
                else
                {
                    if(Frente == -1)
                    {
                        Frente = 0;
                        Final = 0;
                    }
                    else
                    {
                        Final = Final + 1;
                    }
                    Cola[Final] = Elemento;
                    Console.Write("Dato agregado a la cola");
                }
            }

            public void Pop()
            {
                if(Frente != -1)
                {
                    Console.Write("Dato eliminado: " + Cola[Frente]);
                    Cola[Frente] = 0;
                    if(Frente == Final)
                    {
                        Frente = -1;
                        Final = -1;
                    }
                    else
                    {
                        Frente = Frente + 1;
                    }
                }
                else
                {
                    Console.Write("La cola esta vacia");
                }
            }

            public void Recorrido()
            {
                if (Frente != -1)
                {
                    Apuntador = Frente;
                    while(Apuntador <= Final)
                    {
                        Console.Write("Elemento: " + Cola[Apuntador] + " posicion " + Apuntador);
                        Apuntador = Apuntador + 1;
                    }
                }
                else
                {
                    Console.Write("La cola esta vacia");
                }
            }

            public void Busqueda(float Elemento)
            {
                if (Frente != -1)
                {
                    Apuntador = Frente;
                    while (Apuntador <= Final)
                    {
                        if(Cola[Apuntador] == Elemento)
                        {
                            Console.Write("Elemento: " + Elemento + " posicion " + Apuntador);
                        }
                        else
                        {
                            Apuntador = Apuntador + 1;
                        }
                        Console.Write("Elemento: " + Elemento + " NO esta en la cola");
                    }
                }
                else
                {
                    Console.Write("La cola esta vacia");
                }
            }

            ~Colas()
            {
                Console.Write("Cola destruida");
            }
        }

        static void Main(string[] args)
        {
            int opcion;
            Colas co = null;
            do
            {
                Console.Clear();
                Console.WriteLine("Menu Colas");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("\nOpcion 1 Crear la cola");
                Console.WriteLine("Opcion 2 Insertar elementos");
                Console.WriteLine("Opcion 3 Eliminar elementos");
                Console.WriteLine("Opcion 4 Recorrer la cola");
                Console.WriteLine("Opcion 5 Buscar elementos en la cola");
                Console.WriteLine("Opcion 6 Salir del programa");
                Console.Write("\nQue deseas realizar? ");
                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("De cuantos elementos quieres que sea el vector? ");
                        int M = int.Parse(Console.ReadLine());
                        co = new Colas(M);
                        Console.Write("\npresiona enter para regresar");
                        Console.ReadKey();
                        break;
                    case 2:
                        if (co is null)
                        {
                            Console.Clear();
                            Console.Write("La Cola se encuentra sin tamaño, favor de ir a opcion 1");
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.Write("Ingresa el dato a agregar en la Cola: ");
                            co.Elemento = float.Parse(Console.ReadLine());
                            co.Push(co.Elemento);
                            Console.Write("\npresiona enter para regresar");
                            Console.ReadKey();
                            break;
                        }
                    case 3:
                        if (co is null)
                        {
                            Console.Clear();
                            Console.Write("La Cola se encuentra sin tamaño, favor de ir a opcion 1");
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            co.Pop();
                            Console.Write("\n\npresiona enter para regresar");
                            Console.ReadKey();
                            break;
                        }
                    case 4:
                        if (co is null)
                        {
                            Console.Clear();
                            Console.Write("La Cola se encuentra sin tamaño, favor de ir a opcion 1");
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            co.Recorrido();
                            Console.Write("\npresiona enter para regresar");
                            Console.ReadKey();
                            break;
                        }
                    case 5:
                        if (co is null)
                        {
                            Console.Clear();
                            Console.Write("La Cola se encuentra sin tamaño, favor de ir a opcion 1");
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.Write("Que dato deseas buscar en la Cola? ");
                            co.Elemento = float.Parse(Console.ReadLine());
                            Console.Write("\n");
                            co.Busqueda(co.Elemento);
                            Console.Write("\n\npresiona enter para regresar");
                            Console.ReadKey();
                        }
                        break;
                    case 6:
                        Console.Clear();
                        Console.Write("Salir del programa - presiona enter");
                        Console.ReadKey();
                        break;
                    default:
                        Console.Clear();
                        Console.Write("Escoga una opción valida - presiona enter");
                        Console.ReadKey();
                        break;
                }
            } while (opcion != 6);
        }
    }
}
