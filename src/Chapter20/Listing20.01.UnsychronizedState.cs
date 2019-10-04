﻿namespace AddisonWesley.Michaelis.EssentialCSharp.Chapter20.Listing20_01
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

#pragma warning disable CA1806

    public class Program
    {
        static int _Total = int.MaxValue;
        static int _Count = 0;

        public static int Main(string[] args)
        {
            if (args?.Length > 0) { int.TryParse(args[0], out _Total); }

            Console.WriteLine($"Increment and decrementing {_Total} times...");

            // Use Task.Factory.StartNew for .NET 4.0
            Task task = Task.Run(() => Decrement());

            // Increment
            for(int i = 0; (i < _Total); i++)
            {
                _Count++;
            }

            task.Wait();
            Console.WriteLine($"Count = {_Count}");

            return _Count;
        }

        static void Decrement()
        {
            // Decrement
            for(int i = 0; i < _Total; i++)
            {
                _Count--;
            }
        }
    }

#pragma warning restore CA1806
}
