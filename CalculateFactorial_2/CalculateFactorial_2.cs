using System;
using System.Collections.Generic;
using System.Diagnostics;
namespace CalculateFactorial_2
{
    class CalculateFactorial_2
    {
        private static int[] temp = new int[11];
        private static readonly int operationsCount = 1000000;

        static void Main()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            int factorial = 1;
            Random rand = new Random();
            int num;
            
            for (int i = 0; i < operationsCount; i++)
            {
                num = rand.Next(1, 10);
                factorial = Fact(num);  
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }

        private static int Fact(int num)
        {
            if (num == 1)
            {
                return 1;
            }
            if (temp[num] != 0)
            {
                return temp[num];
            }
            int result = 1;
            for (int i = 1; i < num; i++)
            {
                result *= num;
            }
            return temp[num] = result;               //temp[num] = num * Fact(num -1); With recursion
        }
    }
}