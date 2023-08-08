using ExampleUnitTest.APP;
using Moq;
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
        public Mock<ICalculatorService> calculatorMock { get; set; }
        public CalculatorTest()
        {
            //IcalculatorService implement ettiği CalculatorService i taklit edecek.
            calculatorMock = new Mock<ICalculatorService>();
            calculator = new Calculator(calculatorMock.Object);
            //calculator = new Calculator(new CalculatorService());
        }


        [Theory]
        [InlineData(2,5,7)]
        [InlineData(2,3,5)]
        public void Add_SimpleValues_ReturnTotalValue(int a, int b, int expectedTotal)
        {

            //eğer add metodu çağırılırsa return olarak expectedTotal dön diyoruz
            calculatorMock.Setup(x=>x.add(a,b)).Returns(expectedTotal);

            var actualTotal = calculator.add(a, b);
            Assert.Equal(expectedTotal, actualTotal);

            //Times.one 1 kere çalışmış olsun diyoruz
            //times.never hiç çalışmazsa demek
            //times atleast kaç kere çağrıldığını sorar
            calculatorMock.Verify(x => x.add(a, b), Times.AtLeast(1));
        }

        [Theory]
        [InlineData(2, 0, 0)]
        [InlineData(0, 6, 0)]
        public void Add_ZeroValues_ReturnTotalValue(int a, int b, int expectedTotal)
        {
            var actualTotal = calculator.add(a, b);
            Assert.Equal(expectedTotal, actualTotal);
        }


        [Theory]
        [InlineData(2, 6, 8)]
        public void Add_CustomValues_ReturnTotalValue(int a, int b, int expectedTotal)
        {
            int actualTotal = 0;
            calculatorMock.Setup(x => x.add(It.IsAny<int>(), It.IsAny<int>())).Callback<int,int>((x,y) => actualTotal = x + y);

            calculator.add(a, b);
            Assert.Equal(expectedTotal, actualTotal);

            calculator.add(5, 20);
            Assert.Equal(25, actualTotal);

        }

    }
}
