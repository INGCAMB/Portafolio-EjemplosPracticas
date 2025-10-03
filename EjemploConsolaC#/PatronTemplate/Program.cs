using System;

namespace PatronTemplate
{
    class Program
    {
        static void Main(string[] args)
        {
            Beverage bebida;
            int opt;
            bool repetir = true;
            
            while (repetir) {
                opt = 0;
                bebida = null;

                Console.WriteLine("¡Bienvenido al cibercafé donde sí servimos café!");
                Console.WriteLine("Menú de bebidas:");
                Console.WriteLine("1) Té.");
                Console.WriteLine("2) Café.");
                Console.Write("¿Qué bebida desea? (Ingrese número) ");

                opt = int.Parse(Console.ReadLine().ToString());

                switch (opt) {
                    case 1:
                        bebida = new Tea();
                    break;
                    case 2:
                        bebida = new Coffee();
                    break;
                    default:
                        Console.WriteLine("Escoja una opción válida.");
                    break;
                }

                if (bebida != null) {
                    bebida.prepareRecipe();

                    Console.Write("\nBebida servida, ¿Desea otra bebida? (y/n) ");
                    repetir = Console.ReadLine().ToString() == "y" ? true : false;
                }

                Console.Clear();
            }
        }
    }

    public abstract class Beverage
    {
        public void prepareRecipe() {
            boilWater();
            brew();
            pourInCup();
            addCondiments();
        }

        public abstract void brew();

        public abstract void addCondiments();

        void boilWater() {
            Console.WriteLine("Hirviendo agua...");
        }

        void pourInCup() {
            Console.WriteLine("Sirviendo el vaso...");
        }
    }

    public class Tea : Beverage
    {
        public override void brew() {
            Console.WriteLine("Remojando el té...");
        }

        public override void addCondiments() {
            Console.WriteLine("Agregando limón...");
        }
    }

    public class Coffee : Beverage
    {
        public override void brew() {
            Console.WriteLine("Preparando el café desde la cafetera...");
        }

        public override void addCondiments() {
            Console.WriteLine("Agregando azúcar y leche...");
        }
    }
}
