using System;
using UnitTestTutorial.Helpers.Interfaces;

namespace UnitTestTutorial.Helpers
{
    public class CalculateHelper : ICalculateHelper
    {
        public double Add(int x, int y)
        {
            return x+y;
        }

        public double Divide(int x, int y)
        {
            if(y==0)
            {
                throw new ArgumentException();
            }
            return x/y;
        }

        public double Multiply(int x, int y)
        {
            return x*y;
        }

        public double Subtract(int x, int y)
        {
            return x-y;
        }
    }
}