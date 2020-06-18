using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramacaoDinamica
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
            itens.Add(new Item(3, 4));
            itens.Add(new Item(4, 5));
            itens.Add(new Item(5, 8));
            itens.Add(new Item(7, 10));
            int Mochila = 10;

            //ProgramacaoDinamicaSemRepeticao(itens, Mochila);

           // Console.WriteLine();

            ProgramacaoDinamicaComRepeticao(itens, Mochila);

            Console.ReadKey();


        }

        static void ProgramacaoDinamicaSemRepeticao(List<Item> itens, int Mochila)
        {
            int[,] Tabela = new int[itens.Count, Mochila + 1];

            //PREENCHIMENTO DA PRIMEIRA LINHA
            for (int j=0; j<Tabela.GetLength(1); j++)
                if (j < itens[0].Peso)
                    Tabela[0, j] = 0;
                else
                    Tabela[0, j] = itens[0].Valor;            

            //PREENCHENDO AS PROXIMAS LINHAS DA TABELA
            for (int i = 1; i < Tabela.GetLength(0); i++)            
                for (int j = 0; j < Tabela.GetLength(1); j++)                
                    if (j < itens[i].Peso)
                        Tabela[i, j] = Tabela[i - 1, j];
                    else
                        Tabela[i, j] = Math.Max(Tabela[i-1, j], Tabela[i-1, j - itens[i].Peso] + itens[i].Valor);
            printTable(Tabela);
        }

        static void ProgramacaoDinamicaComRepeticao(List<Item> itens, int Mochila)
        {
            int[,] Tabela = new int[itens.Count, Mochila + 1];

            //PREENCHIMENTO DA PRIMEIRA LINHA
            for (int j = 0; j < Tabela.GetLength(1); j++)
                if (j < itens[0].Peso)
                    Tabela[0, j] = 0;
                else
                    Tabela[0, j] = Tabela[0, j - itens[0].Peso] + itens[0].Valor;

            //PREENCHENDO AS PROXIMAS LINHAS DA TABELA
            for (int i = 1; i < Tabela.GetLength(0); i++)
                for (int j = 0; j < Tabela.GetLength(1); j++)
                    if (j < itens[i].Peso)
                        Tabela[i, j] = Tabela[i - 1, j];
                    else
                        Tabela[i, j] = Math.Max(Tabela[i - 1, j], Tabela[i, j - itens[i].Peso] + itens[i].Valor);


            printTable(Tabela);
        }

        static void printTable(int[,] Tabela)
        {

            for (int i = 0; i < Tabela.GetLength(1); i++)
                Console.Write(i + "\t");
            Console.WriteLine();

            for (int i=0; i<Tabela.GetLength(0); i++)
            {

                for (int j = 0; j < Tabela.GetLength(1); j++)
                {

                    Console.Write(Tabela[i, j] + "\t");


                }

                Console.WriteLine();
            }

        }
    }
}
