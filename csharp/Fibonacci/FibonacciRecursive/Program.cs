


using System;
using System.Linq;
using System.Collections.Generic;

namespace Fib
{
    class Fibber
    {
        private int _numberOfRecursions;
        private int _maxNumberOfRecursions;

        public Fibber(int numberOfRecursions)
        {
            this._maxNumberOfRecursions = numberOfRecursions - 2; // because we add 0, 1 manually.
        }

        public static void Main(string[] args)
        {
            int th = 5;

            // var fibber = new Fibber(th);
            // int result = fibber.Go();

            // Console.WriteLine($"The {th}th Fibonacci number is {result}.");

            int result = fibonacci(th);

            // 5th. 0 1 1 2 3. 5th number is 3.
            Console.WriteLine($"The {th}th Fibonacci number is {result}.");

        }


        static int fibonacci(int i)
        {
            if (i == 0)
                return 0;
            if (i == 1)
                return 1;

            return fibonacci(i - 1) + fibonacci(i - 2);
        }
    }
}