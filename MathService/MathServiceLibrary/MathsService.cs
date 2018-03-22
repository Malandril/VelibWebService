using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MathServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MathsService" in both code and config file together.
    public class MathsService : IMathsService
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public double Div(int a, int b)
        {
            if (b == 0)
            {
                var fault = new DivideFault();
                throw new FaultException<DivideFault>(fault);
            }

            return (double) a / b;
        }
    }
}