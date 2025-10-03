using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//Medina Beltran Carlos Alberto
//Patrón Template Method - Cibercafe
namespace DesarrolloPatronTemplateMethod
{
    class BeverageTestDrive
    {
        static void Main(string[] args)
        {
            //Instancia de clase abstracta CaffeineBeverageWithHook
            CaffeineBeverageWithHook bebida;
            //Int para las opciones del menu
            int opt;

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

                    bebida = new TeaWithHook();
                    break;
                case 2:

                    bebida = new CoffeeWithHook();
                    break;
                default:
                    Console.WriteLine("Escoja una opción válida.");
                    break;
            }

            //Si la instancia es distinta a null, se metera al codigo a preparar el cafe o te
            if (bebida != null)
            {
                //Se llama a PrepareRecipe 
                bebida.prepareRecipe();

                //Imprimes
                Console.Write("\nBebida servida serian 50 pesos");
            }

            //Código para parar programa
            Console.ReadKey();
        }
    }

    //Clase abstracta de las bebidas de cafeina que contiene el metodo template
    public abstract class CaffeineBeverageWithHook
    {
        public void prepareRecipe()
        {
            boilWater();
            brew();
            pourInCup();
            if (customerWantsCondiments())
            {
                addCondiments();
            }
        }

        //Operaciones primitivas 
        public abstract void brew();

        public abstract void addCondiments();

        //Operaciones concretas
        public void boilWater()
        {
            Console.WriteLine("Hirviendo agua...");
        }

        public void pourInCup()
        {
            Console.WriteLine("Sirviendo el vaso...");
        }

        //Metodo Hook
        public virtual bool customerWantsCondiments()
        {
            return true;
        }
    }

    //Subclase o clase concreta TeaWithHook
    public class TeaWithHook : CaffeineBeverageWithHook
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

        //Aqui sobrescribe si habra condimentos o no
        public override bool customerWantsCondiments()
        {
            string answer = getUserInput();

            /*Este metodo es en Java
            if (answer.toLowerCase().startsWith("y"))
            {
                return true;
            }*/

            //Si usa Y mayuscula convertimos a minuscula y checamos que inicie con "y"
            if (answer.ToLower().StartsWith("y"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Aqui el usuario dira si le gustaria agregar condimentos
        private string getUserInput()
        {
            string answer;

            //Console.WriteLine("Would you like milk and suggar with your coffee (y/n)? ");
            Console.Write("Le gustaria limon en su té (y/n)? ");

            answer = Console.ReadLine().ToString();

            return answer;
        }
    }

    //Subclase o clase concreta CoffeeWithhook
    public class CoffeeWithHook : CaffeineBeverageWithHook
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

        //Aqui sobrescribe si habra condimentos o no
        public override bool customerWantsCondiments()
        {
            string answer = getUserInput();

            /*Este metodo es en Java
            if (answer.toLowerCase().startsWith("y"))
            {
                return true;
            }*/

            //Si usa Y mayuscula convertimos a minuscula y checamos que inicie con "y"
            if (answer.ToLower().StartsWith("y"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Aqui el usuario dira si le gustaria agregar condimentos
        private string getUserInput()
        {
            string answer;

            //Console.WriteLine("Would you like milk and suggar with your coffee (y/n)? ");
            Console.Write("Le gustaria leche y azucar a su cafe (y/n)? ");

            answer = Console.ReadLine().ToString();

            return answer;
        }
    }
}
