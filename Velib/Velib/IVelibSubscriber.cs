using System.ServiceModel;

namespace Velib
{
    [ServiceContract(CallbackContract = typeof(IVelibEvent))]
    public interface IVelibSubscriber
    {
        [OperationContract]
        void SubscribeStationChanged(string stationName, string cityName, int timeInSeconds);
    }
}