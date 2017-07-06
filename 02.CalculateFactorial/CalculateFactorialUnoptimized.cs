﻿using System;
using System.Diagnostics;

namespace _02.CalculateFactorial
{
    class CalculateFactorialUnoptimized
    {
        public static int operationsCount = 1000000;

        static void Main()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            int factorial = 1;
            Random rand = new Random();
            int num;
            
            for (int i = 0; i < operationsCount; i++)
            {
                num = rand.Next(1, 11);
                for (int k = 1; k <= num; k++)
                {
                    factorial *= k;
                    
                }
                factorial = 1;
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }
    }
}