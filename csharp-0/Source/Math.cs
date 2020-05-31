using System;
using System.Collections.Generic;
using System.Linq;

namespace Codenation.Challenge
{
    public class Math
    {
        public List<int> Fibonacci()
        {
            List<int> fibonacciSequence = new List<int>() { 0, 1 };

            for(int i=2; i < 350; i++)
            {
                int number = fibonacciSequence.ElementAt(i - 2) + fibonacciSequence.ElementAt(i - 1);

                if (number > 350)
                {
                    break;
                }

                fibonacciSequence.Add(number);
            }


            return fibonacciSequence;        
        }

        public bool IsFibonacci(int numberToTest)
        {
            List<int> fibonacciSequence = Fibonacci();

            return Fibonacci().Contains(numberToTest);

        }
    }
}
