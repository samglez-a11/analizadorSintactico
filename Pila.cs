using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace analizadorSintactico
{
    internal class Elemento
    {
        public const int ERROR = -1;
        public const int IDENTIFICADOR = 0;
        public const int SIMBOLO = 1;
        public const int SIGNOPESO = 2;
        public const int E = 3;
        public const int INICIAL = 5;

        public int tipo;
        public String simbolo;

        public Elemento()
        {
            tipo = 5;
        }

        public String ToString()
        {
            return simbolo;
        }
    }

    class Terminal : Elemento
    {
        public Terminal(int id)
        {
            tipo = id;
            if (id == SIGNOPESO)
            {
                simbolo = "$";
            }
        }

        public Terminal(int id, String sim)
        {
            tipo = id;
            simbolo = sim;
        }
    }

    class NoTerminal : Elemento
    {
        public NoTerminal(int id, String sim)
        {
            tipo = id;
            simbolo = sim;
        }
    }

    class Estado : Elemento
    {
        public Estado(int id, String estado)
        {
            tipo = id;
            simbolo = estado;
        }
    }


    class Pila
    {
        public LinkedList<Elemento> listaPila = new LinkedList<Elemento>();

        public Pila()
        {

        }

        public void push(Elemento x)
        {
            listaPila.AddLast(x);
        }

        public Elemento top()
        {
            return listaPila.First.Value;
        }

        public Elemento pop()
        {
            Elemento x = listaPila.First.Value;
            listaPila.Remove(x);

            return x;
        }

        public void vaciarPila()
        {
            listaPila.Clear();
        }

        public void mostrarPila()
        {
            foreach (Elemento dato in listaPila)
            {
                Console.Write(dato.simbolo + dato.tipo);
            }
            Console.WriteLine("\n");
        }
    }
}
