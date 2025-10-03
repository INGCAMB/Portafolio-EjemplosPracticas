using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrolloPatronStrategy
{
    class Program
    {
        //Medina Beltran Carlos Alberto
        //Variables globales de cada tipo de pato
        static MallardDuck mallard = new MallardDuck();
        static RedHeadDuck redHead = new RedHeadDuck();
        static DecoyDuck decoy = new DecoyDuck();
        static ModelDuck model = new ModelDuck();
        static RubberDuck rubber = new RubberDuck();

        //Variable que se utilizara para guardar la última selección de pato
        static int lastSelection;

        static void Main(string[] args)
        {
            //Variables locales del programa las cuales no se pueden usar mas que en esta parte
            Duck pato = null;
            int opcion;
            bool repetir = true;
            lastSelection = 0;

            pato = SelectDuck(pato);

            //Ciclo para repetir el menu las veces que sean necesarias mientras no pulse 7 en el programa
            while (repetir)
            {
                opcion = 0;

                pato.display();
                Console.WriteLine("Acciones que puede realizar:");
                Console.WriteLine("1) Volar.");
                Console.WriteLine("2) Hacer quack.");
                Console.WriteLine("3) Nadar.");
                Console.WriteLine("4) Hacer todo.");
                Console.WriteLine("5) Cambiar un comportamiento.");
                Console.WriteLine("6) Cambiar de pato.");
                Console.WriteLine("7) Salir del programa.");
                Console.Write("¿Qué debería hacer? ");

                opcion = int.Parse(Console.ReadLine().ToString());
                Console.WriteLine();

                switch (opcion)
                {
                    case 1:
                        //Acción de volar
                        pato.performFly();
                        Console.ReadLine();
                        break;
                    case 2:
                        //Acción de hacer sonido de quack
                        pato.performQuack();
                        Console.ReadLine();
                        break;
                    case 3:
                        //Acción de nadar
                        pato.performSwim();
                        Console.ReadLine();
                        break;
                    case 4:
                        //Aqui se realizan todas las acciones
                        pato.performFly();
                        pato.performQuack();
                        pato.performSwim();
                        Console.ReadLine();
                        break;
                    case 5:
                        //Cambia uno de los comportamientos
                        int opc = 0;

                        //Submenu de comportamientos del pato para modificar
                        Console.WriteLine("Comportamientos disponibles del pato:");
                        Console.WriteLine("1) Volar.");
                        Console.WriteLine("2) Hacer quack.");
                        Console.WriteLine("3) Nadar.");
                        Console.Write("¿Cuál comportamiento desea modificar? ");

                        //Verifica si esta poniendo un tipo de valor que sea byte
                        try
                        {
                            opc = byte.Parse(Console.ReadLine().ToString());
                        }
                        catch (Exception) { }

                        switch (opc)
                        {
                            case 1:
                                //Submenu de comportamientos del vuelo del pato
                                Console.WriteLine("Comportamientos de vuelo:");
                                Console.WriteLine("1) Volar con alas.");
                                Console.WriteLine("2) No poder volar.");
                                Console.WriteLine("3) Volar con cohete.");
                                Console.Write("¿A cuál comportamiento desea cambiar? ");

                                //Verifica si esta poniendo un tipo de valor que sea byte
                                try
                                {
                                    opc = byte.Parse(Console.ReadLine().ToString());
                                }
                                catch (Exception) { }

                                //Limpiar
                                Console.Clear();

                                switch (opc)
                                {
                                    //Estan los tres casos para llamar a modificar el vuelo
                                    case 1:
                                        pato.setFlyBehavior(new FlyWithWings());
                                        break;
                                    case 2:
                                        pato.setFlyBehavior(new FlyNoWay());
                                        break;
                                    case 3:
                                        pato.setFlyBehavior(new FlyRocketPowered());
                                        break;
                                    default:
                                        //Default
                                        Console.WriteLine("Escoja una opción válida.");
                                        break;
                                }
                                break;
                            case 2:
                                //Submenu de comportamientos del sonido del pato
                                Console.WriteLine("Comportamientos de sonido:");
                                Console.WriteLine("1) Hacer quack.");
                                Console.WriteLine("2) Ningun sonido.");
                                Console.WriteLine("3) Hacer squeak.");
                                Console.Write("¿A cuál comportamiento desea cambiar? ");

                                //Verifica si esta poniendo un tipo de valor que sea byte
                                try
                                {
                                    opc = byte.Parse(Console.ReadLine().ToString());
                                }
                                catch (Exception) { }

                                //Limpiar
                                Console.Clear();

                                switch (opc)
                                {
                                    //Estan los tres casos para llamar a modificar el sonido
                                    case 1:
                                        pato.setQuackBehavior(new Quack());
                                        break;
                                    case 2:
                                        pato.setQuackBehavior(new MuteQuack());
                                        break;
                                    case 3:
                                        pato.setQuackBehavior(new Squeak());
                                        break;
                                    default:
                                        //Default
                                        Console.WriteLine("Escoja una opción válida.");
                                        break;
                                }
                                break;
                            case 3:
                                //Submenu de comportamientos de nadar del pato
                                Console.WriteLine("Comportamientos de nadar:");
                                Console.WriteLine("1) Nadar con patas.");
                                Console.WriteLine("2) Solo flotar.");
                                Console.WriteLine("3) Navegar en barco.");
                                Console.Write("¿A cuál comportamiento desea cambiar? ");

                                //Verifica si esta poniendo un tipo de valor que sea byte
                                try
                                {
                                    opc = byte.Parse(Console.ReadLine().ToString());
                                }
                                catch (Exception) { }

                                //Limpiar
                                Console.Clear();

                                switch (opc)
                                {
                                    //Estan los tres casos para llamar a modificar el nadar
                                    case 1:
                                        pato.setSwimBehavior(new SwimWithPaws());
                                        break;
                                    case 2:
                                        pato.setSwimBehavior(new SwimFloat());
                                        break;
                                    case 3:
                                        pato.setSwimBehavior(new SwimInBoat());
                                        break;
                                    default:
                                        //Default
                                        Console.WriteLine("Escoja una opción válida.");
                                        break;
                                }
                                break;
                            default:
                                //Cuando se escoja otra
                                Console.WriteLine("Escoja una opción válida.");
                                break;
                        }
                        break;
                    case 6:
                        //Limpia y cambiamos de pata 
                        Console.Clear();
                        pato = SelectDuck(pato);
                        break;
                    case 7:
                        //Termina el programa y se sale del ciclo
                        repetir = false;
                        break;
                    default:
                        //Cuando se escoja un valor que no sea entre 1 y 7
                        Console.WriteLine("Escoja una opción válida.");
                        break;
                }

                //Console.ReadLine();
                //Este código limpia
                Console.Clear();
            }
        }

        static Duck SelectDuck(Duck duck)
        {
            byte opc = 0;

            while (true)
            {
                Console.WriteLine("Selección de patos disponibles:");
                Console.WriteLine("1) Pato Mallard");
                Console.WriteLine("2) Pato Pelirrojo");
                Console.WriteLine("3) Pato Señuelo");
                Console.WriteLine("4) Pato de modelo");
                Console.WriteLine("5) Pato de hule");
                Console.Write("¿Cuál pato desea tomar? ");

                try
                {
                    opc = byte.Parse(Console.ReadLine().ToString());
                }
                catch (Exception) { }

                Console.Clear();

                switch (lastSelection)
                {
                    case 1:
                        mallard = (MallardDuck)duck;
                        break;
                    case 2:
                        redHead = (RedHeadDuck)duck;
                        break;
                    case 3:
                        decoy = (DecoyDuck)duck;
                        break;
                    case 4:
                        model = (ModelDuck)duck;
                        break;
                    case 5:
                        rubber = (RubberDuck)duck;
                        break;
                    default:
                        break;
                }

                lastSelection = opc;
                switch (opc)
                {
                    case 1:
                        return mallard;
                    case 2:
                        return redHead;
                    case 3:
                        return decoy;
                    case 4:
                        return model;
                    case 5:
                        return rubber;
                    default:
                        break;
                }
            }
        }

        //Clase primaria de patos
        public abstract class Duck
        {
            public FlyBehavior flyBehavior;
            public QuackBehavior quackBehavior;
            public SwimBehavior swimBehavior;

            public Duck() { }

            public abstract void display();

            //Seters para los comportamientos en corrida de programa
            public void setFlyBehavior(FlyBehavior fb) => flyBehavior = fb;

            public void setQuackBehavior(QuackBehavior qb) => quackBehavior = qb;

            public void setSwimBehavior(SwimBehavior sb) => swimBehavior = sb;

            //Métodos de comportamiento
            public void performFly() => flyBehavior.fly();

            public void performQuack() => quackBehavior.quack();

            public void performSwim() => swimBehavior.swim();
        }

        //Interfaces para los comportamientos
        public interface FlyBehavior
        {
            public void fly();
        }

        public interface QuackBehavior
        {
            public void quack();
        }

        public interface SwimBehavior
        {
            public void swim();
        }

        //Clases de comportamientos de Fly
        public class FlyWithWings : FlyBehavior
        {
            public void fly()
            {
                Console.WriteLine("¡Estoy volando con mis alas!");
            }
        }

        public class FlyNoWay : FlyBehavior
        {
            public void fly()
            {
                Console.WriteLine("¡No puedo volar!");
            }
        }

        public class FlyRocketPowered : FlyBehavior
        {
            public void fly()
            {
                Console.WriteLine("¡Estoy volando en un cohete!");
            }
        }

        //Clases de comportamientos de Quack
        public class Quack : QuackBehavior
        {
            public void quack()
            {
                Console.WriteLine("Quack!");
            }
        }

        public class MuteQuack : QuackBehavior
        {
            public void quack()
            {
                Console.WriteLine("*Silencio*");
            }
        }

        public class Squeak : QuackBehavior
        {
            public void quack()
            {
                Console.WriteLine("Squeak!");
            }
        }

        //Clases de comportamiento de Swim
        public class SwimWithPaws : SwimBehavior
        {
            public void swim()
            {
                Console.WriteLine("Estoy nadando con las patas.");
            }
        }

        public class SwimFloat : SwimBehavior
        {
            public void swim()
            {
                Console.WriteLine("Solo estoy flotando, no puedo nadar.");
            }
        }

        public class SwimInBoat : SwimBehavior
        {
            public void swim()
            {
                Console.WriteLine("Estoy viajando en bote.");
            }
        }

        //Clases de cada especie de pato
        public class MallardDuck : Duck
        {
            public MallardDuck()
            {
                flyBehavior = new FlyWithWings();
                quackBehavior = new Quack();
                swimBehavior = new SwimWithPaws();
            }

            public override void display()
            {
                Console.WriteLine("Soy un pato Mallard.");
            }
        }

        public class RedHeadDuck : Duck
        {
            public RedHeadDuck()
            {
                flyBehavior = new FlyWithWings();
                quackBehavior = new Quack();
                swimBehavior = new SwimWithPaws();
            }

            public override void display()
            {
                Console.WriteLine("Soy un pato pelirrojo.");
            }
        }

        public class DecoyDuck : Duck
        {
            public DecoyDuck()
            {
                flyBehavior = new FlyNoWay();
                quackBehavior = new MuteQuack();
                swimBehavior = new SwimFloat();
            }

            public override void display()
            {
                Console.WriteLine("Soy un señuelo de pato.");
            }
        }

        public class ModelDuck : Duck
        {
            public ModelDuck()
            {
                flyBehavior = new FlyNoWay();
                quackBehavior = new Quack();
                swimBehavior = new SwimFloat();
            }

            public override void display()
            {
                Console.WriteLine("Soy un modelo de un pato.");
            }
        }

        public class RubberDuck : Duck
        {
            public RubberDuck()
            {
                flyBehavior = new FlyNoWay();
                quackBehavior = new Squeak();
                swimBehavior = new SwimFloat();
            }

            public override void display()
            {
                Console.WriteLine("Soy un pato de hule.");
            }
        }
    }
}
