using System;

namespace Calculator
{
    public class Calculator : ICalculator
    {
        public int Result { get; private set; }

        public void Reset()
        {
            Result = 0;
        }

        public void Add(int x)
        {
            if (x > 0 && (Result + x) < Result)
                throw new OverflowException("Overflow by addition");
            if (x < 0 && (Result + x) > Result)
                throw new OverflowException("Underflow by addition");
            Result += x;
        }

        public void Subtract(int x)
        {
            if (x > 0 && (Result + x) < Result)
                throw new OverflowException("Overflow by subtraction");
            if (x < 0 && (Result + x) > Result)
                throw new OverflowException("Underflow by subtraction");
            Result -= x;
        }

        public void Multiply(int x)
        {
            int tempResult =  x * Result;
            if (tempResult != 0)
            {
                if (x != tempResult / Result)
                    throw new OverflowException("Overflow by multiplication");
            }
            Result = checked(Result * x);
        }

        public void Divide(int x)
        {
            if (x == 0)
                throw new DivideByZeroException("Zero division by division.");
            Result /= x;
        }

        public void Modulus(int x)
        {
            if (x == 0)
                throw new DivideByZeroException("Zero division by modulus.");
            Result %= x;
        }
    }
}
