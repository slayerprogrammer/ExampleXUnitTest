using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleUnitTest.APP
{
    public class Calculator
    {
        private ICalculatorService _calculatorService { get; set; }
        public Calculator(ICalculatorService calculatorService)
        {
            this._calculatorService = calculatorService;
        }
        public int add(int a, int b)
        {
           return _calculatorService.add(a, b);
        }
    }
}
