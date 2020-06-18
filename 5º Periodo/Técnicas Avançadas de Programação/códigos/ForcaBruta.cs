using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForcaBruta
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
            itens.Add(new Item(12, 4));
            itens.Add(new Item(2, 2));
            itens.Add(new Item(1, 1));
            itens.Add(new Item(4, 10));
            itens.Add(new Item(1, 2));
            int Mochila = 15;

            ForcaBruta(itens, Mochila);

            Console.ReadKey();

        }

        static int ForcaBruta(List<Item> itens, int Mochila)
        {
            int totalItens = itens.Count;
            int combinacoes = (int)Math.Pow(2, itens.Count);

            string combinacaoResultado = "";
            int melhoValor = 0;
            int pesoOcupado = 0;

            for(int i=0; i < combinacoes; i++)
            {
                string binario = Convert.ToString(i, 2);
                binario = binario.PadLeft(totalItens, '0');

                int valorTotal = 0;
                int pesoTotal = 0;

                for (int j = 0; j < totalItens; j++)
                {
                    if(binario[j] != '0')
                    {
                        pesoTotal += itens[j].Peso;
                        valorTotal += itens[j].Valor;
                    }
                }

                Console.WriteLine(binario + " - Peso: " + pesoTotal + " Valor: " + valorTotal);

                if(pesoTotal <= Mochila && valorTotal > melhoValor)
                {
                    combinacaoResultado = binario;
                    melhoValor = valorTotal;
                    pesoOcupado = pesoTotal;
                }
            }

            Console.WriteLine("\n\nResposta: "+ combinacaoResultado + " - Peso: " + pesoOcupado + " Valor: " + melhoValor);
            
            return 0;
        }
    }
}
