using System.ServiceModel;

namespace CarService
{

    [ServiceContract]
    public interface IDataService
    {
        [OperationContract]
        string Add(Order order);

        [OperationContract]
        string PrintOrder(int id);

        [OperationContract]
        string PrintAllOrders();
    }
    
}
