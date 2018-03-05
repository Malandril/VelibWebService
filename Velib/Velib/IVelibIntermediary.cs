using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using VelibClient;

namespace Velib
{
    [ServiceContract]
    public interface IVelibIntermediary
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        Task<List<Station>> GetStations(string city);

        [OperationContract]
        Task<List<Contract>> GetContracts();
    }
}