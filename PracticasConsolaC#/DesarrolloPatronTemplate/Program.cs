using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Medina Beltran Carlos Alberto
//Patrón Template - Cibercafe
namespace DesarrolloPatronTemplate
{
    class Program
    {
        static void Main(string[] args)
        { 
            //Instancia de clase abstracta Beverage
            Beverage bebida;
            //Int para las opciones del menu
            int opt;
            //Booleano para la repetición de menu
            bool repetir = true;

            //Ciclo de repeticiones
            while (repetir)
            {
                opt = 0;
                bebida = null;

                //Menu
                Console.WriteLine("¡Bienvenido al cibercafé donde sí servimos café!");
                Console.WriteLine("Menú de bebidas:");
                Console.WriteLine("1) Té.");
                Console.WriteLine("2) Café.");
                Console.Write("¿Qué bebida desea? (Ingrese número) ");

                //Aqui se agrega la opción que de el usuario
                opt = int.Parse(Console.ReadLine().ToString());

                //Un switch para los diferentes casos que habra
                switch (opt)
                {
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

                //Si la instancia es distancia a null, se metera al codigo
                if (bebida != null)
                {
                    //Se llama a PrepareRecipe 
                    bebida.prepareRecipe();

                    //Imprimes y luego respondes y se condiciona para ver si su respueta es true o false
                    Console.Write("\nBebida servida, ¿Desea otra bebida? (y/n) ");
                    repetir = Console.ReadLine().ToString() == "y" ? true : false;
                }

                //Código de limpiar
                Console.Clear();
            }
        }
    }

    //Clase abstracta de las bebidas
    public abstract class Beverage
    {
        public void prepareRecipe()
        {
            boilWater();
            brew();
            pourInCup();
            addCondiments();
        }

        public abstract void brew();

        public abstract void addCondiments();

        void boilWater()
        {
            Console.WriteLine("Hirviendo agua...");
        }

        void pourInCup()
        {
            Console.WriteLine("Sirviendo el vaso...");
        }
    }

    //Subclase Tea
    public class Tea : Beverage
    {
        //Sobrescribir brew
        public override void brew()
        {
            Console.WriteLine("Remojando el té...");
        }

        //Sobrescribir addCondiments
        public override void addCondiments()
        {
            Console.WriteLine("Agregando limón...");
        }
    }

    //Subclase Coffee
    public class Coffee : Beverage
    {
        //Sobrescribir brew
        public override void brew()
        {
            Console.WriteLine("Preparando el café desde la cafetera...");
        }

        //Sobrescribir addCondiments
        public override void addCondiments()
        {
            Console.WriteLine("Agregando azúcar y leche...");
        }
    }
}
