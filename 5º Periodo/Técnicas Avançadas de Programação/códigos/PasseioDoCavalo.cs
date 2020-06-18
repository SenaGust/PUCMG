using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tentativa_e_Erro
{
    class PasseioDoCavalo
    {
        // COORDENADAS DOS MOVIMENTOS POSSÍVEIS
        int[] dx = {2, 1, -1, -2, -2, -1,  1,  2 };
        int[] dy = {1, 2,  2,  1, -1, -2, -2, -1 };

        // NÚMERO DE POSIÇÕES DO TABULEIRO
        int n;

        // NÚMERO TOTAL DE CASA
        int numCasas;

        // Tabuleiro
        int[,] tabuleiro;

        public PasseioDoCavalo(int _n)
        {
            n = _n;
            numCasas = n * n;
            tabuleiro = new int[n, n];
        }

        private bool aceitavel(int x, int y)
        {
            bool resultado = (x >= 0 && x <= n - 1);
            resultado = resultado && (y >= 0 && y <= n - 1);
            resultado = resultado && (tabuleiro[x,y] == 0);
            return resultado;
        }

        bool tenta(int passo, int x, int y)
        {
            bool achou = (passo > numCasas);
            int k = 0, u, v;
            while (!achou && k < 8)
            {
                u = x + dx[k];
                v = y + dy[k];

                if (aceitavel(u, v))
                {
                    tabuleiro[u, v] = passo; // REGISTRO
                    achou = tenta(passo + 1, u, v); // RETROCESSO
                    if (!achou)
                        tabuleiro[u, v] = 0; // SEM SUCESSO!!
                }
                k++;
            }
            return achou;
        }

        public void ImprimePasseio(int x, int y)
        {
            tabuleiro[x, y] = 1;

            bool achou = tenta(2, x, y);

            if (achou)
            {
                for(int i=0; i < tabuleiro.GetLength(0); i++)
                {
                    for (int j = 0; j < tabuleiro.GetLength(1); j++)
                    {
                        Console.Write(tabuleiro[i, j] + "\t");
                    }
                    Console.WriteLine();
                }

            }
            else
            {
                Console.WriteLine("Não achou um passeio do cavalo!!");
            }

        }

    }





    class Program
    {
        static void Main(string[] args)
        {
            PasseioDoCavalo teste = new PasseioDoCavalo(3);

            teste.ImprimePasseio(0, 0);

            Console.ReadKey();
        }
    }
}
