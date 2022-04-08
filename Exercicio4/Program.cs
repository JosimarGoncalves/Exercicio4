using System;
using System.Threading;
using System.Diagnostics;

class Program
{
    public const int l = 2;
    public const int c = 2;
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

        for (int i = 0; i < l; i++)
        {
            for (int j = 0; j < c; j++)
            {
                mat[i, j] = rnd.Next(1, 10);
                Console.Write("\t" + mat[i, j]);
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

        Console.WriteLine("Soma Total : " + somaTotal);
       

    }
    private static void SomarA()
    {
        for (int i = 0; i < l/2; i++)
        {
            for (int j = 0; j < c; j++)
            {
                somaA += mat[i, j];
                //Console.Write(mat[i, j]);
            }
            Console.WriteLine(" ");
        }
        Console.WriteLine("\nSomaA total: " + somaA);
        
    }

    private static void SomarB()
    {
        for (int i = (l) / 2; i < l; i++)
        {
            for (int j = (c)/2 ; j < c; j++)
            {
                somaB += mat[i, j];
                //Console.Write("\t" + mat[i, j]);
            }
            Console.WriteLine(" ");
        }
        Console.WriteLine("\nSomaB total: " + somaB);

    }

}