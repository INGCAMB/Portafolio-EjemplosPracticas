using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListasEnlazadas
{
    //Clase que define el nodo de la lista
    class Nodo
    {
        public int valor;
        public Nodo sig;
        public Nodo(int v, Nodo s)
        {
            valor = v;
            sig = s;
        }
    }
    //Clase que imprime todos los nodos de la lista
    class ListaEnlazada
    {
        Nodo primero;
        Nodo actual;
        public ListaEnlazada()
        {
        }
        public void Insertar(int v)
        {
            Nodo anterior;
            if (ListaVacia() || primero.valor > v)
            {
                primero = new Nodo(v, primero);
            }
            else
            {
                anterior = primero;
                while (anterior.sig != null && anterior.sig.valor <= v)
                    anterior = anterior.sig;
                anterior.sig = new Nodo(v, anterior.sig);
            }
        }
        public void Mostrar()
        {
            Nodo aux;
            aux = primero;
            while (aux != null)
            {
                Console.Write(aux.valor + "->");
                aux = aux.sig;
            }
            Console.Write("  null ");
            Console.WriteLine();
        }
        public void Siguiente()
        {
            if (actual != null)
                actual = actual.sig;
        }
        public void Primero()
        {
            actual = primero;
        }
        public void Borrar(int v)
        {

            Nodo anterior, nodo;
            nodo = primero;
            anterior = null;
            while (nodo != null && nodo.valor < v)
            {
                anterior = nodo;
                nodo = nodo.sig;
            }

            if (nodo == null || nodo.valor != v)
                return;
            else
            {
                if (anterior == null)
                    primero = nodo.sig;
                else
                    anterior.sig = nodo.sig;
            }

        }
        public bool ListaVacia()
        {
            if (primero == null)
                return true;
            return false;
        }
        public void Ultimo()
        {
            Primero();
            if (!ListaVacia())
                while (actual.sig != null)
                    Siguiente();
        }
        public bool Actual()
        {
            if (actual != null)
                return true;
            return false;
        }
        public int ValorActual()
        {
            return actual.valor;
        }
    }//FIN CLASE NODO 

    class Program
    {
        static void Main(string[] args)
        {
            ListaEnlazada lista = new ListaEnlazada();
            lista.Insertar(10);
            lista.Insertar(12);
            lista.Insertar(1);
            lista.Insertar(5);
            lista.Mostrar();
            lista.Borrar(5);
            lista.Borrar(10);
            lista.Mostrar();

            Console.ReadKey();
        }
    }
}
