using System.ServiceModel;

namespace CarService
{
    [ServiceContract]
    public interface ICarDelivery
    {

        [OperationContract]
        string TestConnection();

        [OperationContract]
        string AddData(string mark, int age, int price, int motor_value);

        [OperationContract]
        string PrintOutput(string id);
    }
}

