using System;
using System.Collections.Generic;

namespace DesarrolloPatronFactoryMethod
{
    //Medina Beltran Carlos Alberto
    //Desarrollo Patrón Factory Method- Pizzas Franquicias

    //Clase abtracta de PizzaStore
    public abstract class PizzaStore
    {
        static void Main(string[] args)
        {
            //De donde vamos a querer la pizza y creamos los objetos
            PizzaStore nyStore = new NYPizzaStore();
            PizzaStore chicagoStore = new ChicagoPizzaStore();

            Pizza pizza;
            
            //Manda la orden pizza y va a mandar la de cheese
            pizza = nyStore.orderPizza("cheese");

            //Imprimimos el nombre del que ordena y que nombre de pizza pidio
            Console.WriteLine("Ethan ordered a " + pizza.getName() + "\n");
            Console.Write("\n");

            pizza = chicagoStore.orderPizza("cheese");
            Console.WriteLine("Joel ordered a " + pizza.getName() + "\n");
            Console.Write("\n");

            Console.ReadKey();
        }

        //Metodo que ordena la pizza y no cambia
        public Pizza orderPizza(string type)
        {
            //Instancia de pizza
            Pizza pizza;

            pizza = createPizza(type);

            pizza.prepare();
            pizza.bake();
            pizza.cut();
            pizza.box();

            return pizza;
        }

        //Nuestro Factory Method
        public abstract Pizza createPizza(string type);

        //Hereda miembros de PizzaStore
        public class NYPizzaStore : PizzaStore
        {
            //Sobreescribe
            public override Pizza createPizza(string item)
            {
                //Condiciones para saber que tipo de pizza sera
                if (item == "cheese")
                {
                    return new NYStyleCheesePizza();
                }
                else if (item == "greek")
                {
                    return new NYStyleGreekPizza();
                }
                else if (item == "clam")
                {
                    return new NYStyleClamPizza();
                }
                else if (item == "pepperoni")
                {
                    return new NYStylePepperoniPizza();
                }
                else if (item == "veggie")
                {
                    return new NYStyleVeggiePizza();
                }
                else
                {
                    return null;
                }
            }
        }

        //Hereda miembros de PizzaStore
        public class ChicagoPizzaStore : PizzaStore
        {
            //Sobreescribe
            public override Pizza createPizza(string item)
            {
                //Condiciones para saber que tipo de pizza sera
                if (item == "cheese")
                {
                    return new ChicagoStyleCheesePizza();
                }
                else if (item == "greek")
                {
                    return new ChicagoStyleGreekPizza();
                }
                else if (item == "clam")
                {
                    return new ChicagoStyleClamPizza();
                }
                else if (item == "pepperoni")
                {
                    return new ChicagoStylePepperoniPizza();
                }
                else if (item == "veggie")
                {
                    return new ChicagoStyleVeggiePizza();
                }
                else
                {
                    return null;
                }
            }
        }

        //Clase de pizza lo que es igual lo declaramos aqui
        public abstract class Pizza
        {
            //Variables y lista
            public string name;
            public string dough;
            public string sauce;
            public List<string> toppings = new List<string>();

            //Metodo de preparar
            public void prepare()
            {
                Console.WriteLine("Preparando " + name);
                Console.WriteLine("Lanzando masa...");
                Console.WriteLine("Agragando salsa...");
                Console.WriteLine("Agregando cubiertas: ");
                foreach (string topping in toppings)
                {
                    Console.WriteLine("    " + topping);
                }
            }

            //Metodo para hornear
            public void bake()
            {
                Console.WriteLine("Hornear durante 25 minutos a 350");
            }

            //Metodo de corte
            public void cut()
            {
                Console.WriteLine("Cortar la pizza en rodajas diagonales");
            }

            //Metodo para la caja
            public void box()
            {
                Console.WriteLine("Coloque la pizza en la caja oficial de PizzaStore");
            }

            //Retorna el nombre
            public string getName()
            {
                return name;
            }
        }

        //Hereda los miembros de la clase Pizza donde se agrega el estilo
        public class NYStyleCheesePizza : Pizza
        {
            public NYStyleCheesePizza()
            {
                name = "Pizza estilo NY salsa y queso";
                dough = "Masa de corteza fina";
                sauce = "Salsa marinara";

                //Añadimos a la lista 
                toppings.Add("Queso reggiano rallado");
            }
        }

        //Hereda los miembros de la clase Pizza donde se agrega el estilo
        public class NYStyleGreekPizza : Pizza
        {
            public NYStyleGreekPizza()
            {
                name = "Pizza estilo NY champiñones, frijol, salsa, tocino";
                dough = "Masa de corteza fina";
                sauce = "Salsa marinara";

                //Añadimos a la lista 
                toppings.Add("Queso reggiano rallado");
            }
        }

        //Hereda los miembros de la clase Pizza donde se agrega el estilo
        public class NYStyleClamPizza : Pizza
        {
            public NYStyleClamPizza()
            {
                name = "Pizza estilo NY almeja y salsa";
                dough = "Masa de corteza fina";
                sauce = "Salsa marinara";

                //Añadimos a la lista 
                toppings.Add("Queso reggiano rallado");
            }
        }

        //Hereda los miembros de la clase Pizza donde se agrega el estilo
        public class NYStylePepperoniPizza : Pizza
        {
            public NYStylePepperoniPizza()
            {
                name = "Pizza estilo NY salsa y peperoni";
                dough = "Masa de corteza fina";
                sauce = "Salsa marinara";

                //Añadimos a la lista 
                toppings.Add("Queso reggiano rallado");
            }
        }

        //Hereda los miembros de la clase Pizza donde se agrega el estilo
        public class NYStyleVeggiePizza : Pizza
        {
            public NYStyleVeggiePizza()
            {
                name = "Pizza estilo NY champiñones, aceitunas, pimiento y salsa";
                dough = "Masa de corteza fina";
                sauce = "Salsa marinara";

                //Añadimos a la lista 
                toppings.Add("Queso reggiano rallado");
            }
        }

        //Hereda los miembros de la clase Pizza donde se agrega el estilo
        public class ChicagoStyleCheesePizza : Pizza
        {
            public ChicagoStyleCheesePizza()
            {
                name = "Pizza estilo Chicago de queso de plato hondo";
                dough = "Masa de corteza extra espesa";
                sauce = "Salsa de tomate ciruela";

                //Añadimos a la lista 
                toppings.Add("Queso mozzarella rallado");
            }

            public void cut()
            {
                Console.WriteLine("Cortar la pizza en rodajas cuadradas");
            }
        }

        //Hereda los miembros de la clase Pizza donde se agrega el estilo
        public class ChicagoStyleGreekPizza : Pizza
        {
            public ChicagoStyleGreekPizza()
            {
                name = "Pizza estilo Chicago de queso de plato hondo, champiñones";
                dough = "Masa de corteza extra espesa";
                sauce = "Salsa de tomate ciruela";

                //Añadimos a la lista 
                toppings.Add("Queso mozzarella rallado");
            }

            public void cut()
            {
                Console.WriteLine("Cortar la pizza en rodajas cuadradas");
            }
        }

        //Hereda los miembros de la clase Pizza donde se agrega el estilo
        public class ChicagoStyleClamPizza : Pizza
        {
            public ChicagoStyleClamPizza()
            {
                name = "Pizza estilo Chicago de queso de plato hondo, almeja";
                dough = "Masa de corteza extra espesa";
                sauce = "Salsa de tomate ciruela";

                //Añadimos a la lista 
                toppings.Add("Queso mozzarella rallado");
            }

            public void cut()
            {
                Console.WriteLine("Cortar la pizza en rodajas cuadradas");
            }
        }

        //Hereda los miembros de la clase Pizza donde se agrega el estilo
        public class ChicagoStylePepperoniPizza : Pizza
        {
            public ChicagoStylePepperoniPizza()
            {
                name = "Pizza estilo Chicago de queso de plato hondo, peperoni";
                dough = "Masa de corteza extra espesa";
                sauce = "Salsa de tomate ciruela";

                //Añadimos a la lista 
                toppings.Add("Queso mozzarella rallado");
            }

            public void cut()
            {
                Console.WriteLine("Cortar la pizza en rodajas cuadradas");
            }
        }

        //Hereda los miembros de la clase Pizza donde se agrega el estilo
        public class ChicagoStyleVeggiePizza : Pizza
        {
            public ChicagoStyleVeggiePizza()
            {
                name = "Pizza estilo Chicago de queso de plato hondo, pimiento, aceitunas";
                dough = "Masa de corteza extra espesa";
                sauce = "Salsa de tomate ciruela";

                //Añadimos a la lista 
                toppings.Add("Queso mozzarella rallado");
            }

            public void cut()
            {
                Console.WriteLine("Cortar la pizza en rodajas cuadradas");
            }
        }
    }
}
