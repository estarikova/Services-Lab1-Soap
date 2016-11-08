using System;
using System.IO;

namespace CarService
{

    public class CarDelivery : ICarDelivery
    {
        DataService client = new DataService();
        public string TestConnection()
        {
            return "Test Connection Status: Ok";
        }

        public Order AddData(Order order)
        {
            order.customPrice = CalculateCustomPrice(order);
            order.fullPrice = CalculateFullPrice(order);
            order.receiptTime = CalculateReceiptTime();
            order.returnTime = CalculateReturnTime();
            order.id = CountId();


            Order result = client.Add(order);
            return result;
        }

        public Order PrintOrder(int id)
        {
            Order result = client.PrintOrder(id);

            return result;
        }

        public Order[] PrintAllOrders()
        {
            Order[] result = client.PrintAllOrders();
            return result;
        }

        private int CalculateCustomPrice(Order order)
        {
            int result = 0;
            if (order.age != 0)
            {
                result = (order.price + order.motorValue) / order.age;
            }

            return result;
        }
        private int CalculateFullPrice(Order order)
        {
            int result = order.customPrice + 5000;
            return result;
        }

        private string CalculateReceiptTime()
        {
            DateTime time = DateTime.Now;
            string receiptTime = time.ToString("dd/MM/yyyy");
            return receiptTime;
        }
        private string CalculateReturnTime()
        {
            DateTime time = DateTime.Now.AddDays(14);
            string returnTime = time.ToString("dd/MM/yyyy");
            return returnTime;
        }

        private int CountId()
        {
            int id;
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\App_Data\\";
            id = new DirectoryInfo(path).GetFiles().Length + 1;
            return id;
        }

    }
}