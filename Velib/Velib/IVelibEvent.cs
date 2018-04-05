using System.ServiceModel;

namespace Velib
{
    [ServiceContract]
    public interface IVelibEvent
    {
        [OperationContract(IsOneWay = true)]
        void StationChanged(Station station);
    }
}