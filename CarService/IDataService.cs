using System.ServiceModel;

namespace CarService
{

    [ServiceContract]
    public interface IDataService
    {
        [OperationContract]
        Order Add(Order order);

        [OperationContract]
        Order PrintOrder(int id);

        [OperationContract]
        Order[] PrintAllOrders();
    }
    
}
