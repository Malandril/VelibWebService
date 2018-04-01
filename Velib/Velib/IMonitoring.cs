using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Velib
{
    [ServiceContract]
    public interface IMonitoring
    {
        [OperationContract]
        int GetNbClientCalls(int n);

        [OperationContract]
        int GetNbDistantRequest(int n);

        [OperationContract]
        List<string> GetNamesOfCachedItems();
    }
}