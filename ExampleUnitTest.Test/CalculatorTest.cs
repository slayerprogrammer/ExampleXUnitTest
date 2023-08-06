using ExampleUnitTest.APP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ExampleUnitTest.Test
{
    public class CalculatorTest
    {
        public Calculator calculator { get; set; }
        public CalculatorTest()
        {
            this.calculator = new Calculator();
        }


        [Theory]
        [InlineData(2,5,7)]
        [InlineData(2,3,5)]
        public void Add_SimpleValues_ReturnTotalValue(int a, int b, int expectedTotal)
        {
            var actualTotal = calculator.add(a, b);
            Assert.Equal(expectedTotal, actualTotal);
        }

        [Theory]
        [InlineData(2, 0, 0)]
        [InlineData(0, 6, 0)]
        public void Add_ZeroValues_ReturnTotalValue(int a, int b, int expectedTotal)
        {
            var actualTotal = calculator.add(a, b);
            Assert.Equal(expectedTotal, actualTotal);
        }

    }
}
