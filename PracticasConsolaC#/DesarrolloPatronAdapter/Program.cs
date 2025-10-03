using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrolloPatronAdapter
{
    //Medina Beltran Carlos Alberto
    //Desarrollo Patrón Adapter - Pato/Pavo/AdaptadorPavo

    //Clase principal DuctTestDrive
    class DuckTestDrive
    {
        static void Main(string[] args)
        {
            //Creamos un pato
            MallardDuck duck = new MallardDuck();

            //Creamos un pavo normal
            WildTurkey wildTurkey = new WildTurkey(); 

            //Envuelve el pavo en un adaptador para pavo para que parezca un pato
            TurkeyAdapter turkeyAdapter = new TurkeyAdapter(wildTurkey);

            Console.WriteLine("\nEl Pavo dice ...");
            wildTurkey.gobble();
            wildTurkey.fly();

            Console.WriteLine("\nEl Pato dice ...");
            testDuck(duck);

            Console.WriteLine("\nEl adaptador de pavo dice ...");
            testDuck(turkeyAdapter);

            Console.ReadKey();
        }

        static void testDuck(Duck duck)
        {
            duck.quack();
            duck.fly();
        }
    }

    //Se definen dos métodos en la interfaz del pato, para saber que el pato hace "quack" y el pato puede volar
    public interface Duck
    {
        public void quack();
        public void fly();
    }

    //Se definen dos métodos en la interfaz del pavo, a saber, el cacareo del pavo y el vuelo del pavo
    public interface Turkey
    {
        public void gobble();
        public void fly();
    }

    //Subclase implementada de la interfaz pato con los dos metodos para describir
    public class MallardDuck : Duck
    {
        public void quack()
        {
            Console.WriteLine("Quack");
        }

        public void fly()
        {
            Console.WriteLine("Estoy volando");
        }
    }

    //Subclase implementada de la interfaz pavo con los dos metodos para describir
    public class WildTurkey : Turkey
    {
        public void gobble()
        {
            Console.WriteLine("Gobble gobble!");
        }

        public void fly()
        {
            Console.WriteLine("Estoy volando a corta distancia!");
        }
    }

    //La clase de adaptador, que implementa la interfaz pato, tiene como objetivo convertir un pavo en un pato, para hacerlo falso
    public class TurkeyAdapter : Duck
    {
        Turkey turkey;

        public TurkeyAdapter(Turkey turkey)
        {
            this.turkey = turkey;
        }

        public void quack()
        {
            turkey.gobble();
        }

        public void fly()
        {
            // Dado que el pavo vuela más cerca del pato, para pretender ser un pato, déjelo volar 5 veces para que corresponda a la distancia de vuelo del pato.
            for (int i = 0; i < 5; i++)
            {
                turkey.fly();
            }
        }
    }
}
