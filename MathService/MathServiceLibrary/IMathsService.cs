using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MathServiceLibrary
{
    [ServiceContract]
    public interface IMathsService
    {
        [OperationContract]
        int Add(int a, int b);

        [OperationContract]
        [FaultContract(typeof(DivideFault))]
        double Div(int a, int b);
    }
}