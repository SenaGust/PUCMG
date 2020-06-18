using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmoGuloso
{
    class Item
    {
        public int Peso { get; set; }
        public int Valor { get; set; }

        public Item(int peso, int valor)
        {
            Peso = peso;
            Valor = valor;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Item> itens = new List<Item>();
            itens.Add(new Item(11, 4));
            itens.Add(new Item(2, 2));
            itens.Add(new Item(1, 1));
            itens.Add(new Item(4, 10));
            itens.Add(new Item(1, 2));
            int Mochila = 15;

            AlgoritmoGuloso(itens, Mochila);

            Console.ReadKey();
        }

        static void AlgoritmoGuloso(List<Item> itens, int Mochila)
        {
            var itensOrdenados = from i in itens
                                 orderby (i.Valor/i.Peso) descending
                                 select i;

            int pesoTotal = 0, valorTotal = 0;

            Console.WriteLine("Itens selecionados:");

            foreach (Item i in itensOrdenados)
            {
                if(i.Peso <= Mochila)
                {
                    pesoTotal += i.Peso;
                    valorTotal += i.Valor;
                    Mochila -= i.Peso;

                    Console.WriteLine("Peso: " + i.Peso + " - Valor: " + i.Valor);

                }                
            }

            Console.WriteLine("Peso Total: " + pesoTotal + " - Valor Total: " + valorTotal);
        }

        
    }
}
