using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EventsClient
{
    class Program
    {
        static void Main(string[] args)
        {
            CalcServiceCallbackSink objsink = new CalcServiceCallbackSink();
            InstanceContext iCntxt = new InstanceContext(objsink);

            ServiceReferenceCalc.CalcServiceClient objClient = new ServiceReferenceCalc.CalcServiceClient(iCntxt);
            objClient.SubscribeCalculatedEvent();
            objClient.SubscribeCalculationFinishedEvent();

            double dblNum1 = 1000, dblNum2 = 2000;
            objClient.Calculate(0, dblNum1, dblNum2);

            dblNum1 = 2000; dblNum2 = 4000;
            objClient.Calculate(1, dblNum1, dblNum2);

            dblNum1 = 2000; dblNum2 = 4000;
            objClient.Calculate(2, dblNum1, dblNum2);

            dblNum1 = 2000; dblNum2 = 400;
            objClient.Calculate(3, dblNum1, dblNum2);

            Console.WriteLine("Press any key to close ...");
            Console.ReadKey();
        }
    }
}
