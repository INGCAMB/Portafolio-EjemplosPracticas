using System;

namespace DesarrolloPatronSimpleFactory
{
    //Desarrollo Patron Simple Factory - Pizzas
    //Medina Beltran Carlos Alberto

    //Nuestro cliente que puede a ver mas clientes que PizzaStore
    public class PizzaStore
    {
        //Damos referencia a simple pizza factory
        //Damos una objeto de la fabrica
        SimplePizzaFactory factory;

        //Constructor
        public PizzaStore(SimplePizzaFactory factory)
        {
            this.factory = factory;
        }

        static void Main(string[] args)
        {
            SimplePizzaFactory factory = new SimplePizzaFactory();
            PizzaStore store = new PizzaStore(factory);

            Pizza pizza = store.orderPizza("cheese");
            Console.Write("\n");
            pizza = store.orderPizza("veggie");
            Console.Write("\n");
            pizza = store.orderPizza("clam");
            Console.ReadKey();
        }

        //Metodo de ordenar pizza 
        //El cual regresa una pizza y recibe un tipo de pizza
        public Pizza orderPizza(string type)
        {
            Pizza pizza;

            //Delegar la instancia a la fabrica
            //Se la voy a ordernar a la fabrica pero la que lo va a crear es la fabrica
            pizza = factory.createPizza(type);

            pizza.prepare();
            pizza.bake();
            pizza.cut();
            pizza.box();

            return pizza;
        }

        //Clase donde creamos ya la pizza pero dependiendo del tipo
        //Nuestra fabrica simple
        public class SimplePizzaFactory
        {
            public Pizza createPizza(string type)
            {
                Pizza pizza = null;

                //Condiciones para ver que tipo de pizza se pide
                //Y se retorna una nueva instancia
                if (type == "cheese")
                {
                    return new CheesePizza();
                }
                else if (type == "greek")
                {
                    return new GreekPizza();
                }
                else if (type == "clam")
                {
                    return new ClamPizza();
                }
                else if (type == "pepperoni")
                {
                    return new PepperoniPizza();
                }
                else if (type == "veggie")
                {
                    return new VeggiePizza();
                }

                return pizza;
            }
        }

        //Clasa abtracta de pizza
        //Tendra los metodos abstractos de preparar, hornear, corte y de caja para las Pizzas
        public abstract class Pizza
        {
            public abstract void prepare();
            public abstract void bake();
            public abstract void cut();
            public abstract void box();
        }

        //Hereda de la clase abstracta Pizza los metodos de preparar, hornear, corte y caja
        public class CheesePizza : Pizza
        {
            public override void prepare()
            {
                Console.WriteLine("Queso");
            }

            public override void bake()
            {
                Console.WriteLine("8 minutos");
            }

            public override void cut()
            {
                Console.WriteLine("8 piezas");
            }

            public override void box()
            {
                Console.WriteLine("Grande");
            }
        }

        //Hereda de la clase abstracta Pizza los metodos de preparar, hornear, corte y caja
        public class GreekPizza : Pizza
        {
            public override void prepare()
            {
                Console.WriteLine("Tocino,Jamon,Queso,Frijol");
            }

            public override void bake()
            {
                Console.WriteLine("8 minutos");
            }

            public override void cut()
            {
                Console.WriteLine("8 piezas");
            }

            public override void box()
            {
                Console.WriteLine("Grande");
            }
        }

        //Hereda de la clase abstracta Pizza los metodos de preparar, hornear, corte y caja
        public class ClamPizza : Pizza
        {
            public override void prepare()
            {
                Console.WriteLine("Queso,Almeja,Champiñones");
            }

            public override void bake()
            {
                Console.WriteLine("8 minutos");
            }

            public override void cut()
            {
                Console.WriteLine("8 piezas");
            }

            public override void box()
            {
                Console.WriteLine("Grande");
            }
        }

        //Hereda de la clase abstracta Pizza los metodos de preparar, hornear, corte y caja
        public class PepperoniPizza : Pizza
        {
            public override void prepare()
            {
                Console.WriteLine("Queso,Pepperoni");
            }

            public override void bake()
            {
                Console.WriteLine("8 minutos");
            }

            public override void cut()
            {
                Console.WriteLine("8 piezas");
            }

            public override void box()
            {
                Console.WriteLine("Grande");
            }
        }

        //Hereda de la clase abstracta Pizza los metodos de preparar, hornear, corte y caja
        public class VeggiePizza : Pizza
        {
            public override void prepare()
            {
                Console.WriteLine("Champiñones,Oregano,Aceitunas,Cebolla,Pimiento");
            }

            public override void bake()
            {
                Console.WriteLine("8 minutos");
            }

            public override void cut()
            {
                Console.WriteLine("8 piezas");
            }

            public override void box()
            {
                Console.WriteLine("Grande");
            }
        }
    }
}
