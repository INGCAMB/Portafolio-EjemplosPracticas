using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrolloPatronAbstractFactory
{
    //Medina Beltran Carlos Alberto
    //Desarrollo Patrón Abstract Factory - Pizzas

    //Clase PizzaStore es una Abstract Factory
    public abstract class PizzaStore
    {
        static void Main(string[] args)
        {
            //Se crean las 2 tiendas
            //Se crea el objeto nyStore y se referencia a NYPizzaStore para poder haceer pizzas estilo NY
            //Se crea el objeto chicagoStore y se referencia a ChicagoPizzaStore para poder haceer pizzas estilo Chicago
            PizzaStore nyStore = new NYPizzaStore();
            PizzaStore chicagoStore = new ChicagoPizzaStore();

            //Se crea un objeto tipo Pizza
            //Se ordena una pizza de tipo cheese, pero de la tienda de NY
            //La preparación estilo NY y los ingredientes se guardan en la variable pizza y se despliegan con la persona que hace el pedido
            Pizza pizza;
            pizza = nyStore.orderPizza("clam");
            Console.WriteLine("Ethan ordered a " + pizza + "\n");

            //Se ordena una pizza de tipo clam, pero de la tienda de Chicago
            //La preparación estilo Chicago y los ingredientes se guardan en la variable pizza y se despliegan con la persona que hace el pedido
            pizza = chicagoStore.orderPizza("cheese");
            Console.WriteLine("Joel ordered a " + pizza + "\n");

            Console.ReadKey();
        }

        //Se crea el objeto Pizza con el metodo CreatePizza() en donde la variable type se refiere al tipo de pizza
        protected abstract Pizza createPizza(string type);

        //y se crea una orden con el  método OrderPizza() en donde la variable type se refiere al estilo de pizza
        //Se despliega que se esta haciendo la pizza y su respectiva información y se mandan llamar los metodos de
        //Preparar, Hoernear, Cortar, Caja. Se regresa el valor de la pizza
        public Pizza orderPizza(string type)
        {
            //Instancia de pizza
            Pizza pizza;
            pizza = createPizza(type);
            Console.WriteLine("--- Haciendo una " + pizza.name + " ---");
            pizza.prepare();
            pizza.bake();
            pizza.cut();
            pizza.box();

            return pizza;
        }


        //(Factorias concretas)
        //Clase NYPizzaStore, se hereda de la clase abstracta PizzaStore
        public class NYPizzaStore : PizzaStore
        {
            //Con el comando override se anula el método CreatePizza() anterior y se cambia por el siguiente
            //Aqui se crea una pizza, que recibira solo ingredientes correspondientes a NYPizzaIngredientFactory
            //correspondientes al tipo de pizza que se indique en la variable item, eligiendo en el if/else entre los 4
            //posibles tipos de pizzas estilo NY y guardandolo en la variable pizza. Se regresa el valor de pizza.
            protected override Pizza createPizza(string item)
            {
                Pizza pizza = null;
                PizzaIngredientFactory ingredientFactory =
                    new NYPizzaIngredientFactory();

                if (item == "cheese")
                {
                    //pizza = new CheesePizza(ingredientFactory);
                    //pizza.setName("New York Style Cheese Pizza");
                    pizza = new CheesePizza(ingredientFactory) { name = "New York Style Cheese Pizza" };
                }
                else if (item == "veggie")
                {
                    //pizza = new VeggiePizza(ingredientFactory);
                    //pizza.setName("New York Style Veggie Pizza");
                    pizza = new VeggiePizza(ingredientFactory) { name = "New York Style Veggie Pizza" };
                }
                else if (item == "clam")
                {
                    //pizza = new ClamPizza(ingredientFactory);
                    //pizza.setName("New York Style Clam Pizza");
                    pizza = new ClamPizza(ingredientFactory) { name = "New York Style Clam Pizza" };
                }
                else if (item == "pepperoni")
                {
                    //pizza = new PepperoniPizza(ingredientFactory);
                    //pizza.setName("New York Style Pepperoni Pizza");
                    pizza = new PepperoniPizza(ingredientFactory) { name = "New York Style Pepperoni Pizza" };
                }
                return pizza;
            }
        }

        //(Factorias concretas)
        //Clase ChicagoPizzaStore, se hereda de la clase abstracta PizzaStore
        public class ChicagoPizzaStore : PizzaStore
        {
            //Con el comando override se anula el método CreatePizza() anterior y se cambia por el siguiente
            //Aqui se crea una pizza, que recibira solo ingredientes correspondientes a ChicagoPizzaIngredientFactory
            //correspondientes al tipo de pizza que se indique en la variable item, eligiendo en el if/else entre los 4
            //posibles tipos de pizzas estilo Chicago y guardandolo en la variable pizza. Se regresa el valor de pizza.
            protected override Pizza createPizza(string item)
            {
                Pizza pizza = null;
                PizzaIngredientFactory ingredientFactory =
                    new ChicagoPizzaIngredientFactory();

                if (item == "cheese")
                {
                    //pizza = new CheesePizza(ingredientFactory);
                    //pizza.setName("Chicago Style Cheese Pizza");
                    pizza = new CheesePizza(ingredientFactory) { name = "Chicago Style Cheese Pizza" };
                }
                else if (item == "veggie")
                {
                    //pizza = new VeggiePizza(ingredientFactory);
                    //pizza.setName("Chicago Style Veggie Pizza");
                    pizza = new VeggiePizza(ingredientFactory) { name = "Chicago Style Veggie Pizza" };
                }
                else if (item == "clam")
                {
                    //pizza = new ClamPizza(ingredientFactory);
                    //pizza.setName("Chicago Style Clam Pizza");
                    pizza = new ClamPizza(ingredientFactory) { name = "Chicago Style Clam Pizza" };
                }
                else if (item == "pepperoni")
                {
                    //pizza = new PepperoniPizza(ingredientFactory);
                    //pizza.setName("Chicago Style Pepperoni Pizza");
                    pizza = new PepperoniPizza(ingredientFactory) { name = "Chicago Style Pepperoni Pizza" };
                }
                return pizza;
            }
        }

        //Clase pizza
        public abstract class Pizza
        {
            //Cada pizza tendrá como posibles componentes un nombre (Name), masa (Dough), salsa (Sauce), vegetales (Veggies)
            //que como pueden ser varios, se enlistan, queso (Cheese), pepperoni (Pepperoni), y almejas (Clams)
            public string name { get; set; }

            public Dough dough { get; protected set; }
            public Sauce sauce { get; protected set; }
            public Veggies[] veggies { get; protected set; }
            public Cheese cheese { get; protected set; }
            public Pepperoni pepperoni { get; protected set; }
            public Clam clam { get; protected set; }
        
            //Y se mandan llamar los métodos de Preparar, Hornear, Contar y Caja que despliegan
            //sus respectivos mensajes.
            public abstract void prepare();

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

            /*Retorna el nombre
            public void setName(string name)
            {
                this.name = name;
            }

            public string getName()
            {
                return name;
            }*/


            //Con el método ToString se crea la variable result donde se concatena para desplegar el
            //nombre de la pizza, tipo de masa, de salsa, de queso, la lista de vegetales (si se
            //requieren), almejas y pepperoni en los casos que aplique el tipo y estilo de pizza pedido.
            //Al final se regresa la variable result con todo la información de esa pizza.
            public override string ToString()
            {
                var result = new StringBuilder();
                result.AppendLine("---- " + name + " ----");
                if (dough != null)
                {
                    result.AppendLine(dough.ToString());
                }
                if (sauce != null)
                {
                    result.AppendLine(sauce.ToString());
                }
                if (cheese != null)
                {
                    result.AppendLine(cheese.ToString());
                }
                if (veggies != null)
                {
                    for (int i = 0; i < veggies.Length; i++)
                    {
                        result.Append(veggies[i].ToString());
                        if (i < veggies.Length - 1)
                        {
                            result.Append(", ");
                        }
                    }
                    result.Append("\n");
                }
                if (clam != null)
                {
                    result.AppendLine(clam.ToString());
                }
                if (pepperoni != null)
                {
                    result.AppendLine(pepperoni.ToString());
                }

                return result.ToString();
            }
        }

        //Interfaz PizzaIngredientFactory, aqui se crean los ingredientes para cada pizza dependiendo del
        //tipo y estilo que se ordene.
        public interface PizzaIngredientFactory
        {
            Dough createDought();
            Sauce createSauce();
            Cheese createCheese();
            Veggies[] createVeggies();
            Pepperoni createPepperoni();
            Clam createClam();
        }

        //Clase NYPizzaIngredientFactory, implementa de la interfaz PizzaIngredientFactory para los 
        //ingredientes y se especifica el tipo de ingrediente correspondiente a la pizza estilo NY ordenada.
        public class NYPizzaIngredientFactory : PizzaIngredientFactory
        {
            public Dough createDought()
            {
                return new ThinCrustDough();
            }

            public Sauce createSauce()
            {
                return new MarinaraSauce();
            }

            public Cheese createCheese()
            {
                return new ReggianoCheese();
            }

            public Veggies[] createVeggies()
            {
                Veggies[] veggies = { new Garlic(), new Onion(), new Mushroom(), new RedPepper() };
                return veggies;
            }

            public Pepperoni createPepperoni()
            {
                return new SlicedPepperoni();
            }

            public Clam createClam()
            {
                return new FreshClam();
            }
        }

        //Clase ChicagoPizzaIngredientFactory, implementa de la interfaz PizzaIngredientFactory para los 
        //ingredientes y se especifica el tipo de ingrediente correspondiente a la pizza estilo Chicago ordenada.
        public class ChicagoPizzaIngredientFactory : PizzaIngredientFactory
        {
            public Dough createDought()
            {
                return new ThickCrustDough();
            }

            public Sauce createSauce()
            {
                return new PlumTomatoSauce();
            }

            public Cheese createCheese()
            {
                return new MozzarellaCheese();
            }

            public Veggies[] createVeggies()
            {
                Veggies[] veggies = {new BlackOlives(), new Spinach(), new Eggplant()};
                return veggies;
            }

            public Pepperoni createPepperoni()
            {
                return new SlicedPepperoni();
            }

            public Clam createClam()
            {
                return new FrozenClam();
            }
        }

        //Clase CheesePizza, se extiende y hereda los componentes y métodos de la clase Pizza.
        //Aqui a través de la interfaz PizzaIngredientFactory se agregan los ingredientes necesarios
        //para la pizza tipo CheesePizza y se guarda en su variable de instancia.
        public class CheesePizza : Pizza
        {
            PizzaIngredientFactory ingredientFactory;

            public CheesePizza(PizzaIngredientFactory ingredientFactory)
            {
                this.ingredientFactory = ingredientFactory;
            }

            //Con el método Prepare() se manda desplegar su nombre, y los ingredientes correspondientes
            //de la interfaz PizzaIngradientFactory
            public override void prepare()
            {
                Console.WriteLine("Preparing " + name);
                sauce = ingredientFactory.createSauce();
                dough = ingredientFactory.createDought();
                cheese = ingredientFactory.createCheese();
                pepperoni = ingredientFactory.createPepperoni();
            }
        }

        //Clase VeggiePizza, se extiende y hereda los componentes y métodos de la clase Pizza.
        //Aqui a través de la interfaz PizzaIngredientFactory se agregan los ingredientes necesarios
        //para la pizza tipo VeggiePizza y se guarda en su variable de instancia.
        public class VeggiePizza : Pizza
        {
            PizzaIngredientFactory ingredientFactory;

            public VeggiePizza(PizzaIngredientFactory ingredientFactory)
            {
                this.ingredientFactory = ingredientFactory;
            }

            //Con el método Prepare() se manda desplegar su nombre, y los ingredientes correspondientes
            //de la interfaz PizzaIngradientFactory
            public override void prepare()
            {
                Console.WriteLine("Preparing " + name);
                dough = ingredientFactory.createDought();
                sauce = ingredientFactory.createSauce();
                cheese = ingredientFactory.createCheese();
                veggies = ingredientFactory.createVeggies();
            }
        }

        //Clase ClamPizza, se extiende y hereda los componentes y métodos de la clase Pizza.
        //Aqui a través de la interfaz PizzaIngredientFactory se agregan los ingredientes necesarios
        //para la pizza tipo ClamPizza y se guarda en su variable de instancia.
        public class ClamPizza : Pizza
        {
            PizzaIngredientFactory ingredientFactory;

            public ClamPizza(PizzaIngredientFactory ingredientFactory)
            {
                this.ingredientFactory = ingredientFactory;
            }

            //Con el método Prepare() se manda desplegar su nombre, y los ingredientes correspondientes
            //de la interfaz PizzaIngradientFactory
            public override void prepare()
            {
                Console.WriteLine("Preparing " + name);
                dough = ingredientFactory.createDought();
                sauce = ingredientFactory.createSauce();
                cheese = ingredientFactory.createCheese();
                clam = ingredientFactory.createClam();
            }
        }

        //Clase PepperoniPizza, se extiende y hereda los componentes y métodos de la clase Pizza.
        //Aqui a través de la interfaz PizzaIngredientFactory se agregan los ingredientes necesarios
        //para la pizza tipo PepperoniPizza y se guarda en su variable de instancia.
        public class PepperoniPizza : Pizza
        {
            PizzaIngredientFactory ingredientFactory;

            public PepperoniPizza(PizzaIngredientFactory ingredientFactory)
            {
                this.ingredientFactory = ingredientFactory;
            }

            //Con el método Prepare() se manda desplegar su nombre, y los ingredientes correspondientes
            //de la interfaz PizzaIngradientFactory
            public override void prepare()
            {
                Console.WriteLine("Preparing " + name);
                dough = ingredientFactory.createDought();
                sauce = ingredientFactory.createSauce();
                cheese = ingredientFactory.createCheese();
                veggies = ingredientFactory.createVeggies();
                pepperoni = ingredientFactory.createPepperoni();
            }
        }

        //Interfaz del ingrediente Dough
        public interface Dough
        {
            string ToString();
        }

        //Ingredientes, Aqui cada clase de ingrediente se extiende de su respectiva interfaz
        //de ingrediente y se regresa la descripción de los mismos.
        //Tipos de Masa (Dough)
        public class ThinCrustDough : Dough
        {
            string Dough.ToString()
            {
                //Masa delgada
                return "Thin Crust Dough";
            }
        }
        public class ThickCrustDough : Dough
        {
            string Dough.ToString()
            {
                //Masa gruesa
                return "ThickCrust style extra thick crust dough";
            }
        }

        //Interfaz del ingrediente Sauce
        public interface Sauce
        {
            string ToString();
        }

        //Ingredientes, Aqui cada clase de ingrediente se extiende de su respectiva interfaz
        //de ingrediente y se regresa la descripción de los mismos.
        //Tipos de Salsas (Sauce)
        public class MarinaraSauce : Sauce
        {
            string Sauce.ToString()
            {
                //Marinara
                return "Marinara Sauce";
            }
        }

        public class PlumTomatoSauce : Sauce
        {
            string Sauce.ToString()
            {
                //De tomate Roma
                return "Tomato Sauce with plum tomatoes";
            }
        }

        //Interfaz del ingrediente Cheese
        public interface Cheese
        {
            string ToString();
        }

        //Ingredientes, Aqui cada clase de ingrediente se extiende de su respectiva interfaz
        //de ingrediente y se regresa la descripción de los mismos.
        //Tipos de Quesos (Cheese)
        public class ReggianoCheese : Cheese
        {
            string Cheese.ToString()
            {
                //Reggiano
                return "Reggiano Cheese";
            }
        }

        public class MozzarellaCheese : Cheese
        {
            string Cheese.ToString()
            {
                //Mozzarella
                return "Mozzarella Cheese";
            }
        }

        public class ParmesanCheese : Cheese
        {
            string Cheese.ToString()
            {
                //Parmesano
                return "Shredded Parmesan";
            }
        }

        //Interfaz del ingrediente Veggies
        public interface Veggies
        {
            string ToString();
        }

        //Ingredientes, Aqui cada clase de ingrediente se extiende de su respectiva interfaz
        //de ingrediente y se regresa la descripción de los mismos.
        //Tipos de Vegetales (Veggies)
        public class Garlic : Veggies
        {
            string Veggies.ToString()
            {
                //Ajo
                return "Garlic";
            }
        }

        public class Onion : Veggies
        {
            string Veggies.ToString()
            {
                //Cebolla
                return "Onion";
            }
        }

        public class Mushroom : Veggies
        {
            string Veggies.ToString()
            {
                //Champiñones
                return "Mushrooms";
            }
        }

        public class RedPepper : Veggies
        {
            string Veggies.ToString()
            {
                //Pimiento rojo
                return "Red Pepper";
            }
        }

        public class BlackOlives : Veggies
        {
            string Veggies.ToString()
            {
                //Aceitunas negras
                return "Black Olives";
            }
        }

        public class Spinach : Veggies
        {
            string Veggies.ToString()
            {
                //Espinacas
                return "Spinach";
            }
        }

        public class Eggplant : Veggies
        {
            string Veggies.ToString()
            {
                //Berenjena
                return "Eggplant";
            }
        }

        //Interfaz del ingrediente Pepperoni
        public interface Pepperoni
        {
            string ToString();
        }

        //Ingredientes, Aqui cada clase de ingrediente se extiende de su respectiva interfaz
        //de ingrediente y se regresa la descripción de los mismos.
        //Tipos de Pepperoni (Pepperoni)
        public class SlicedPepperoni : Pepperoni
        {
            string Pepperoni.ToString()
            {
                //Pepperoni rebanado
                return "Sliced Pepperoni";
            }
        }

        //Interfaz del ingrediente Clam
        public interface Clam
        {
            string ToString();
        }

        //Ingredientes, Aqui cada clase de ingrediente se extiende de su respectiva interfaz
        //de ingrediente y se regresa la descripción de los mismos.
        //Tipos de Almejas (Clams)
        public class FreshClam : Clam
        {
            string Clam.ToString()
            {
                //Frescas
                return "Fresh Clams from Long Island Sound";
            }
        }

        public class FrozenClam : Clam
        {
            string Clam.ToString()
            {
                //Congeladas
                return "Frozen Clams from Chesapeake Bay";
            }
        }
    }
}
