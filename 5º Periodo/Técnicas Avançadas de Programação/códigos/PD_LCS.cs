using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PD_LCS
{
    class Program
    {
        static void Main(string[] args)
        {
            string X = "XACGTGTCA";
            string Y = "YACTGTGCA";

            int[,] Tabela = new int[X.Length, Y.Length];

            PD(Tabela, X, Y);
            print(Tabela, X, Y);
            Console.WriteLine();
            printResultado(Tabela, X, Y, X.Length-1, Y.Length-1);

            Console.ReadKey();
        }

        static void PD(int[,] Tabela, string X, string Y)
        {
            for (int i = 1; i < Tabela.GetLength(0); i++)
            {                
                for (int j = 1; j < Tabela.GetLength(1); j++)
                {
                    if(X[i] == Y[j])
                    {
                        Tabela[i, j] = Tabela[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        Tabela[i, j] = Math.Max(Tabela[i - 1, j], Tabela[i, j - 1]);
                    }
                    
                }

            }
        }

        static void printResultado(int[,] Tabela, string X, string Y, int i, int j)
        {
            if (i == 0 || j == 0) return;

            if(X[i] == Y[j])
            {
                Console.Write(X[i]);
                printResultado(Tabela, X, Y, i-1, j-1);
            }
            else
            {
                if(Tabela[i-1, j] < Tabela[i, j-1])
                    printResultado(Tabela, X, Y, i, j - 1);
                else
                    printResultado(Tabela, X, Y, i - 1, j);
            }
        }

        static void print(int[,] Tabela, string X, string Y)
        {
            Console.Write("  ");
            for (int j = 0; j < Tabela.GetLength(1); j++)
                Console.Write(Y[j]+ " ");
            Console.WriteLine();

            for (int i=0; i< Tabela.GetLength(0); i++)
            {
                Console.Write(X[i] + " ");
                for (int j = 0; j < Tabela.GetLength(1); j++)
                {
                    Console.Write(Tabela[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
