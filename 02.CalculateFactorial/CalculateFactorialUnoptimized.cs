using System;
using System.Diagnostics;

namespace _02.CalculateFactorial
{
    class CalculateFactorialUnoptimized
    {
        public static int operationsCount = 1000000;

        static void Main()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            int factorial = 0;
            Random rand = new Random();
            int num;
            
            for (int i = 0; i < operationsCount; i++)
            {
                num = rand.Next(1, 11);
                factorial = CalculateFactorial(num);
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }

        private static int CalculateFactorial(int num)
        {
            int factorial = 1;
            for (int k = 1; k <= num; k++)
            {
                factorial *= k;
            }

            return factorial;
        }
    }
}
