﻿using System;

namespace SpeedCoding2
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i == 0)
                    Console.WriteLine(i.ToString());
                else if (i % 15 == 0)
                    Console.WriteLine("fizzbuzz");
                else if (i % 5 == 0)
                    Console.WriteLine("buzz");
                else if (i % 3 == 0)
                    Console.WriteLine("fizz");
                else
                    Console.WriteLine(i.ToString());
            }
        }
    }
}
