using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsClient
{
    class CalcServiceCallbackSink : ServiceReferenceCalc.ICalcServiceCallback
    {
        public void Calculated(int nOp, double dblNum1, double dblNum2, double dblResult)
        {
            switch (nOp)
            {
                case 0: Console.WriteLine("\nOperation : Addition"); break;
                case 1: Console.WriteLine("\nOperation : Subtraction"); break;
                case 2: Console.WriteLine("\nOperation : Multiplication"); break;
                case 3: Console.WriteLine("\nOperation : Division"); break;
            }
            Console.WriteLine("Operand 1 ...: {0}", dblNum1);
            Console.WriteLine("Operand 2 ...: {0}", dblNum2);
            Console.WriteLine("Result ......: {0}", dblResult);
        }

        public void CalculationFinished()
        {
            Console.WriteLine("Calculation completed");
        }
    }
}
