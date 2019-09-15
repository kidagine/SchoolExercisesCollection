using System;
using Xunit;

namespace Calculator.Tests
{
    public class CalculatorTest
    {
        //Reset
        [Theory]
        [InlineData(5, 0)]
        [InlineData(0, 0)]
        [InlineData(int.MaxValue, 0)]
        [InlineData(int.MinValue, 0)]
        [InlineData(1, 0)]
        [InlineData(-1, 0)]
        public void ResetValidInput(int initial, int expected)
        {
            ICalculator calculator = new Calculator();
            calculator.Add(initial);
            calculator.Reset();
            Assert.Equal(expected, calculator.Result);
        }

        //Addition
        [Theory]
        [InlineData(5, 0, 5)]
        [InlineData(0, int.MaxValue, int.MaxValue)]
        [InlineData(0, int.MinValue, int.MinValue)]
        [InlineData(1, int.MaxValue - 1, int.MaxValue)]
        [InlineData(-1, int.MinValue + 1, int.MinValue)]
        public void AddValidInput(int initial, int x, int expected)
        {
            ICalculator calculator = new Calculator();
            calculator.Add(initial);
            calculator.Add(x);
            Assert.Equal(expected, calculator.Result);
        }

        [Fact]
        public void AddOverflowExpectOverflowException()
        {
            ICalculator calculator = new Calculator();
            calculator.Add(1);
            var e = Assert.Throws<OverflowException>(() =>
            {
                calculator.Add(int.MaxValue);
            });

            Assert.True(e.Message == "Overflow by addition");
        }

        [Fact]
        public void AddUnderflowExpectOverflowException()
        {
            ICalculator calculator = new Calculator();
            calculator.Add(-1);
            var e = Assert.Throws<OverflowException>(() =>
            {
                calculator.Add(int.MinValue);
            });

            Assert.True(e.Message == "Underflow by addition");
        }

        //Subtraction
        [Theory]
        [InlineData(5, 0, 5)]
        [InlineData(0, int.MaxValue, int.MinValue + 1)]
        [InlineData(0, int.MinValue, int.MinValue)]
        [InlineData(-1, int.MaxValue - 1, int.MinValue + 1)]
        [InlineData(1, int.MinValue + 1, int.MinValue)]
        public void SubtractValidInput(int initial, int x, int expected)
        {
            ICalculator calculator = new Calculator();
            calculator.Add(initial);
            calculator.Subtract(x);
            Assert.Equal(expected, calculator.Result);
        }

        [Fact]
        public void SubtractOverflowExpectOverflowException()
        {
            ICalculator calculator = new Calculator();
            calculator.Subtract(-1);
            var e = Assert.Throws<OverflowException>(() =>
            {
                calculator.Subtract(int.MaxValue);
            });

            Assert.True(e.Message == "Overflow by subtraction");
        }

        [Fact]
        public void SubtractUnderflowExpectOverflowException()
        {
            ICalculator calculator = new Calculator();
            calculator.Subtract(1);
            var e = Assert.Throws<OverflowException>(() =>
            {
                calculator.Subtract(int.MinValue);
            });

            Assert.True(e.Message == "Underflow by subtraction");
        }

        //Multiply
        [Theory]
        [InlineData(5, 1, 5)]
        [InlineData(0, int.MaxValue, 0)]
        [InlineData(0, int.MinValue, 0)]
        [InlineData(1, int.MaxValue, int.MaxValue)]
        [InlineData(1, int.MinValue, int.MinValue)]
        public void MultiplyValidInput(int initial, int x, int expected)
        {
            ICalculator calculator = new Calculator();
            calculator.Add(initial);
            calculator.Multiply(x);
            Assert.Equal(expected, calculator.Result);
        }

        [Fact]
        public void MultiplyOverflowException()
        {
            ICalculator calculator = new Calculator();
            calculator.Add(5);
            var e = Assert.Throws<OverflowException>(() =>
            {
                calculator.Multiply(int.MaxValue);
            });
            Assert.True(e.Message == "Overflow by multiplication");
        }

        //Division
        [Theory]
        [InlineData(5, 1, 5)]
        [InlineData(0, int.MaxValue, 0)]
        [InlineData(0, int.MinValue, 0)]
        [InlineData(1, int.MaxValue, 0)]
        [InlineData(1, int.MinValue, 0)]
        public void DivideValidInput(int initial, int x, int expected)
        {
            ICalculator calculator = new Calculator();
            calculator.Add(initial);
            calculator.Divide(x);
            Assert.Equal(expected, calculator.Result);
        }

        [Fact]
        public void DivideDivideByZeroException()
        {
            ICalculator calculator = new Calculator();
            calculator.Add(5);
            var e = Assert.Throws<DivideByZeroException>(() =>
            {
                calculator.Divide(0);
            });
            Assert.True(e.Message == "Zero division by division.");
        }

        //Modulus
        [Theory]
        [InlineData(5, 1, 0)]
        [InlineData(0, int.MaxValue, 0)]
        [InlineData(0, int.MinValue, 0)]
        [InlineData(1, int.MaxValue, 1)]
        [InlineData(1, int.MinValue, 1)]
        public void ModulusValidInput(int initial, int x, int expected)
        {
            ICalculator calculator = new Calculator();
            calculator.Add(initial);
            calculator.Modulus(x);
            Assert.Equal(expected, calculator.Result);
        }

        [Fact]
        public void ModulusDivideByZeroException()
        {
            ICalculator calculator = new Calculator();
            calculator.Add(5);
            var e = Assert.Throws<DivideByZeroException>(() =>
            {
                calculator.Modulus(0);
            });
            Assert.True(e.Message == "Zero division by modulus.");
        }
    }
}
