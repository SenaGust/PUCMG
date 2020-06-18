using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Crie um programa para gerar a sequência (números) de Fibonacci. Esta sequência é constituída recursivamente
da seguinte forma:
                    Fn+2 = Fn+1 + Fn, n > 0, F0 = 1 e F1 = 1
Um exemplo da série de Fibonacci pode ser visto abaixo:
                    F = 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, ...
Em seu programa você deve criar um função, usando closure, que a cada chamada gere o próximo 
número na sequencia de Fibonacci.
*/

namespace Closures
{

    class Program
    {
        static Action StartFibonacci()
        {
            int n1 = 1, n2 = 1, nfib;

            Action fib = () => {
                nfib = n1 + n2;
                Console.WriteLine(nfib);
                n1 = n2;
                n2 = nfib;
            };

            return fib;
        }


        static void Main(string[] args)
        {
            Action seqFibonacci = StartFibonacci();

            for(int i=0; i<10;i++)
            seqFibonacci();
            

            Console.ReadKey();
        }
    }
}
