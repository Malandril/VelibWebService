using System;
using System.ServiceModel;

namespace EventsLib
{
    public interface ICalcServiceEvents
    {
        [OperationContract(IsOneWay = true)]
        void Calculated(int nOp, double dblNum1, double dblNum2, double dblResult);

        [OperationContract(IsOneWay = true)]
        void CalculationFinished();
    }
}
