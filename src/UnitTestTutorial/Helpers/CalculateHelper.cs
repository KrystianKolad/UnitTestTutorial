using System;
using UnitTestTutorial.Helpers.Interfaces;

namespace UnitTestTutorial.Helpers
{
    public class CalculateHelper : ICalculateHelper
    {
        public double Add(double x, double y)
        {
            return x+y;
        }

        public double Divide(double x, double y)
        {
            if(y==0)
            {
                throw new ArgumentException();
            }
            return x/y;
        }

        public double Multiply(double x, double y)
        {
            return x*y;
        }

        public double Subtract(double x, double y)
        {
            return x-y;
        }
    }
}