using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectoresRandomSuma
{
    class Program
    {
        static void Main(string[] args)
        {
            bool Seguir = true;
            byte Opc = 0;
            Numeros numeros = new Numeros();

            do
            {
                Console.Clear();

                Console.WriteLine("=== MENU ===\n");
                Console.WriteLine("1. Generar vector aleatoriamente.");
                Console.WriteLine("2. Sumar los elementos del vector.");
                Console.WriteLine("3. Desplegar el vector, su suma y el promedio.");
                Console.WriteLine("4. Salir del programa.");
                Console.Write("\nEscoga una opción: ");

                try
                {
                    Opc = byte.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.Write("Favor de ingresar un valor válido.\n\n" + e + "\n\n");
                    Console.ReadKey();
                }
                catch (Exception e)
                {
                    Console.Write("Ha ocurrido un error desconocido.\n\n" + e + "\n\n");
                    Console.ReadKey();
                }

                Console.Clear();

                switch (Opc)
                {
                    case 1:
                        Console.Write("Favor de ingresar la cantidad de elementos del vector: ");
                        try
                        {
                            int cantidad = int.Parse(Console.ReadLine());

                            Console.Clear();

                            numeros.GenerarVector(cantidad);

                            Console.Write("Los números han sido generados exitosamente.\nPresione cualquier botón para regresar al menú.");
                        }
                        catch (FormatException e)
                        {
                            Console.Write("Favor de ingresar un valor válido.\n\n" + e + "\n\n");
                        }
                        catch (Exception e)
                        {
                            Console.Write("Ha ocurrido un error desconocido.\n\n" + e + "\n\n");
                        }
                        Console.ReadKey();
                        break;
                    case 2:
                        if (numeros.Num is null)
                            Console.Write("No hay números declarados todavía, ejecute la opción 1 primero.");
                        else
                        {
                            numeros.Suma = numeros.SumarElementos(0);
                            Console.Write("Suma realizada exitosamente.\nPresione cualquier botón para regresar al menú.");
                        }
                        Console.ReadKey();
                        break;
                    case 3:
                        numeros.DesplegarDatos();
                        Console.ReadKey();
                        break;
                    case 4:
                        Seguir = false;
                        break;
                    default:
                        Console.Write("Ingrese una opción válida.");
                        Console.ReadKey();
                        break;
                }
            } while (Seguir);
        }

        class Numeros
        {
            private int[] num;
            public int Suma { get; set; }
            public float Promedio { get; set; }
            public int[] Num { get => num; set => num = value; }

            public void GenerarVector(int cant)
            {
                num = new int[cant];
                Random random = new Random();

                for (int i = 0; i < cant; i++)
                    num[i] = random.Next(0, 50);
            }

            public int SumarElementos(int posicion)
            {
                if (num.Length - 1 != posicion)
                    return num[posicion] + SumarElementos(posicion + 1);
                else
                    return num[posicion];
            }

            public void DesplegarDatos()
            {
                Console.Write("Vector: { ");
                for (int c = 0; c < num.Length; c++)
                {
                    Console.Write(num[c].ToString());
                    if (c != num.Length - 1)
                        Console.Write(", ");
                }
                Console.WriteLine("} ");
                Console.WriteLine("Suma: " + Suma);
                Console.WriteLine("Promedio: " + Suma / Num.Length);
                Console.WriteLine("\nPresione cualquier botón para regresar al menú.");
            }
        }
    }
}
