using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Velib
{
    [ServiceContract]
    public interface IVelibIntermediary
    {
        [OperationContract]
        Task<List<Station>> GetStations(string city);

        [OperationContract]
        Task<List<Contract>> GetContracts();
    }
}