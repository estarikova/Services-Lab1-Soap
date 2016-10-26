using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace CarService
{
    [ServiceContract]
    public interface ICarDelivery
    {

        [OperationContract]
        [WebInvoke(Method="GET", UriTemplate="TC")]
        string TestConnection();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "AddData?mark={mark}&age={age}&price={price}&motorValue={motorValue}")]
        string AddData(string mark, int age, int price, int motorValue);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "PrintOrder?id={id}")]
        string PrintOrder(int id);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "PrintAllOrders")]
        string PrintAllOrders();

        
    }
    [DataContract]
    [Serializable]
    public class Order
    {
        [DataMember]
        public int id;

        [DataMember]
        public string mark;

        [DataMember]
        public int age;

        [DataMember]
        public int price;

        [DataMember]
        public int motorValue;

        [DataMember]
        public int customPrice;

        [DataMember]
        public int fullPrice;

        [DataMember]
        public string receiptTime;

        [DataMember]
        public string returnTime;
    }


}

