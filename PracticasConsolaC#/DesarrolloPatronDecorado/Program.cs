using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrolloPatronDecorado
{
    class StarbuzzCoffee
    {
        //Desarrollo: Patron Decorador
        //Medina Beltran Carlos Alberto
        static void Main(string[] args)
        {
            //Variables para opciones, para continuar, para pasar, y el subtotal de la compra
            int opc = 1;
            bool continuar = true, pasa;
            double subtotal;
            //Instancia de objeto Beverage
            Beverage bebida = null;
            //Lista de objetos de Beverage
            List<Beverage> carrito = new List<Beverage>();

            //Bienvenida
            Console.WriteLine("-------- Cafetería Los Beltran --------");
            Console.WriteLine("Bienvenido a la cafetería Los Beltran.\n");
            while (continuar)
            {
                pasa = true;
                //Ciclo para escoger los cafes que necesite
                while (pasa)
                {
                    //Menu principal de cafes
                    Console.WriteLine("Lista de bebidas:");
                    Console.WriteLine("1) Café expreso              $1.99");
                    Console.WriteLine("2) Café de mezcla de la casa $0.89");
                    Console.WriteLine("3) Café tostado oscuro       $0.99");
                    Console.WriteLine("4) Café descafeinado         $1.05");
                    Console.Write("\n¿Qué desea comprar? ");

                    try
                    {
                        opc = int.Parse(Console.ReadLine().ToString());
                        pasa = false;
                    }
                    catch (Exception) { }
                    Console.Clear();
                }

                //Casos que se utilizan para mandar a llamar la bebida seleccionada
                switch (opc)
                {
                    case 1:
                        bebida = new Expresso();
                        break;
                    case 2:
                        bebida = new HouseBlend();
                        break;
                    case 3:
                        bebida = new DarkRoast();
                        break;
                    case 4:
                        bebida = new Decaf();
                        break;
                    default:
                        Console.Clear();
                        continue;
                }

                //Ciclo para agregar los condimentos que sean hasta que sea disntinto a la opc 5
                while (opc != 5)
                {
                    pasa = true;
                    while (pasa)
                    {
                        //Submenu donde ya se agregan condimentos
                        Console.WriteLine("¿Desea agregar algo a la bebida?\n");
                        Console.WriteLine("1) Moca              $0.20");
                        Console.WriteLine("2) Leche al vapor    $0.10");
                        Console.WriteLine("3) Soya              $0.15");
                        Console.WriteLine("4) Crema batida      $0.10");
                        Console.WriteLine("5) Terminar bebida");
                        Console.Write("\nSeleccione una opción: ");

                        try
                        {
                            opc = int.Parse(Console.ReadLine().ToString());
                            pasa = false;
                        }
                        catch (Exception) { }
                        Console.Clear();
                    }

                    //Mandamos a llamar a los condimentos
                    switch (opc)
                    {
                        case 1:
                            bebida = new Mocha(bebida);
                            break;
                        case 2:
                            bebida = new Milk(bebida);
                            break;
                        case 3:
                            bebida = new Soy(bebida);
                            break;
                        case 4:
                            bebida = new Whip(bebida);
                            break;
                        case 5:
                            break;
                    }
                }

                carrito.Add(bebida);

                //Submenu donde la bebida se preparo y pregunta si deseas otra
                Console.WriteLine("Bebida terminada.\n");
                Console.WriteLine("¿Desea otra bebida?\n");
                Console.WriteLine("1) Sí");
                Console.WriteLine("2) No");
                Console.Write("\nRespuesta: ");

                try
                {
                    opc = int.Parse(Console.ReadLine().ToString());
                }
                catch (Exception) { }

                //Si es uno es true si es 2 se ira a false
                continuar = opc == 1;
                Console.Clear();
            }

            //Suma los costos de la lista que hay en "carrito"
            subtotal = carrito.Sum(item => item.cost());

            //Aqui se imprime la descripcion del cafe y los costos de cada uno
            Console.WriteLine("Cantidad        Descripción        Total");
            Console.WriteLine("----------------------------------------\n");
            foreach (Beverage beverage in carrito)
                Console.WriteLine("1 {0} ${1}", beverage.getDescription(), Math.Round(beverage.cost(), 2));
            //Mostramos el subtotal, el IVA, y el total con el IVA todo redondeado a dos decimales 
            Console.WriteLine("\n----------------------------------------");
            Console.WriteLine("Subtotal: {0}", Math.Round(subtotal, 2));
            Console.WriteLine("IVA 16%: {0}", Math.Round(subtotal * 0.16, 2));
            Console.WriteLine("Total: {0}", Math.Round(subtotal * 1.16, 2));
            Console.WriteLine("\nGracias por su compra.");
            Console.ReadKey();
        }

        //Clase de Beverage
        public abstract class Beverage
        {
            //Variable string para la descripción
            public string description = "Unknown Beverage";

            //Metodo para modificar la descripción en la superclase
            public abstract string getDescription();

            //Metodo de costo para que cada uno pueda implementarlo a su manera
            public abstract double cost();
        }

        //Funciona como decorador
        //Hereda de Beverage, era una variable de descripcion y un metodo de costo
        public abstract class CondimentDecorator : Beverage
        {
            public Beverage beverage;
        }

        //Hereda de Beverage, era una variable de descripcion y un metodo de costo
        public class Expresso : Beverage
        {
            //Constructor
            public Expresso()
            {
                //Modificación de lo que es el cafe
                description = "Çafé expreso";
            }

            //Metodo que retorna la descripción
            public override string getDescription()
            {
                return description;
            }

            //Metodo donde se retorna el valor de costo de la bebida
            public override double cost()
            {
                return 1.99;
            }
        }

        //Hereda de Beverage, era una variable de descripcion y un metodo de costo
        public class HouseBlend : Beverage
        {
            //Constructor
            public HouseBlend()
            {
                //Modificación de lo que es el cafe
                description = "Café de mezcla de la casa";
            }

            //Metodo que retorna la descripción
            public override string getDescription()
            {
                return description;
            }

            //Metodo donde se retorna el valor de costo de la bebida
            public override double cost()
            {
                return .89;
            }
        }

        //Hereda de Beverage, era una variable de descripcion y un metodo de costo
        public class DarkRoast : Beverage
        {
            //Constructor
            public DarkRoast()
            {
                //Modificación de lo que es el cafe
                description = "Café tostado oscuro";
            }

            //Metodo que retorna la descripción
            public override string getDescription()
            {
                return description;
            }

            //Metodo donde se retorna el valor de costo de la bebida
            public override double cost()
            {
                return .99;
            }
        }

        //Hereda de Beverage, era una variable de descripcion y un metodo de costo
        public class Decaf : Beverage
        {
            //Constructor
            public Decaf()
            {
                //Modificación de lo que es el cafe
                description = "Café descafeinado";
            }

            //Metodo que retorna la descripción
            public override string getDescription()
            {
                return description;
            }

            //Metodo donde se retorna el valor de costo de la bebida
            public override double cost()
            {
                return 1.05;
            }
        }

        //Hereda de CondimentDecorator
        public class Mocha : CondimentDecorator
        {
            //Constructor en el cual puede recibir objetos de tipo Beverage
            public Mocha(Beverage beverage)
            {
                //Aqui lo almacena
                this.beverage = beverage;
            }

            public override string getDescription()
            {
                //Retorna los valores que tiene el onjeto mas lo que se le agregue
                return beverage.getDescription() + ", moca";
            }

            public override double cost()
            {
                //Retorna el la suma del valor del objeto apuntado a el metodo costo mas la otra cantidad
                return beverage.cost() + .20;
            }
        }

        //Hereda de CondimentDecorator
        public class Milk : CondimentDecorator
        {
            //Constructor en el cual puede recibir objetos de tipo Beverage
            public Milk(Beverage beverage)
            {
                //Aqui lo almacena
                this.beverage = beverage;
            }

            public override string getDescription()
            {
                //Retorna los valores que tiene el onjeto mas lo que se le agregue
                return beverage.getDescription() + ", leche al vapor";
            }

            public override double cost()
            {
                //Retorna el la suma del valor del objeto apuntado a el metodo costo mas la otra cantidad
                return beverage.cost() + .10;
            }
        }

        //Hereda de CondimentDecorator
        public class Soy : CondimentDecorator
        {
            //Constructor en el cual puede recibir objetos de tipo Beverage
            public Soy(Beverage beverage)
            {
                //Aqui lo almacena
                this.beverage = beverage;
            }

            public override string getDescription()
            {
                //Retorna los valores que tiene el onjeto mas lo que se le agregue
                return beverage.getDescription() + ", soya";
            }

            public override double cost()
            {
                //Retorna el la suma del valor del objeto apuntado a el metodo costo mas la otra cantidad
                return beverage.cost() + .15;
            }
        }

        //Hereda de CondimentDecorator
        public class Whip : CondimentDecorator
        {
            //Constructor en el cual puede recibir objetos de tipo Beverage
            public Whip(Beverage beverage)
            {
                //Aqui lo almacena
                this.beverage = beverage;
            }

            public override string getDescription()
            {
                //Retorna los valores que tiene el onjeto mas lo que se le agregue
                return beverage.getDescription() + ", crema batida";
            }

            public override double cost()
            {
                //Retorna el la suma del valor del objeto apuntado a el metodo costo mas la otra cantidad
                return beverage.cost() + .10;
            }
        }
    }
}
