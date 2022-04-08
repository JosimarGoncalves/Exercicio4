using System;
using System.Threading;
using System.Diagnostics;

class Program
{
    public const int l = 10;
    public const int c = 10;
    public static int[,] mat = new int[l, c];
    public static int somaA = 0;
    public static int somaB = 0;
    public static int somaTotal = 0;

    static void Main()
    {
        Random rnd = new Random();

        var stopWatch = new Stopwatch();

        stopWatch.Start();

        Console.WriteLine("Dimensão da Matriz: " + l + "x" + c + "\n");

        int numeroDaColuna = 0;

        for (int i = 0; i < l; i++)
        {
            numeroDaColuna++;
            
            Console.Write("Coluna:" + numeroDaColuna);
            
            for (int j = 0; j < c; j++)
            {
                
                mat[i, j] = rnd.Next(10, 99);
                
                Console.Write("\t" + mat[i, j]);
                Console.Write(" |");

            }
            Console.WriteLine(" ");
        }

        Thread t1 = new Thread(SomarA);
        Thread t2 = new Thread(SomarB);

        t1.Start();
        t2.Start();

        t1.Join();
        t2.Join();

        somaTotal = somaA + somaB;

       // Console.WriteLine("Valor somado da Thread A: " + somaA);
       // Console.WriteLine("Valor somado da Thread B: " + somaB);
        Console.WriteLine("Soma total das threads: " + somaTotal);
       
        stopWatch.Stop();
        Console.WriteLine($"\nO Tempo de processamento total é de {stopWatch.ElapsedMilliseconds}ms");

    }
    private static void SomarA()
    {
        for (int i = 0; i < l/2; i++)
        {
            for (int j = 0; j < c; j++)
            {
              somaA += mat[i, j];
               
            }
            Console.WriteLine(" ");
        }
        Console.WriteLine("Soma metade da thread 1: " + somaA);
        
    }

    private static void SomarB()
    {
        for (int i = l/ 2; i < l; i++)
        {
            for (int j = 0 ; j < c; j++)
            {
                somaB += mat[i, j];
                
            }
            Console.WriteLine(" ");
        }
        Console.WriteLine("Soma metade da thread 2: " + somaB);

    }

}