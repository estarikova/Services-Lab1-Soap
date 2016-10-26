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

        public string AddData(string mark, int age, int price, int motorValue)
        {

            Order order = new Order();

            order.mark = mark;
            order.age = age;
            order.price = price;
            order.motorValue = motorValue;
            order.customPrice = CalculateCustomPrice(order);
            order.fullPrice = CalculateFullPrice(order);
            order.receiptTime = CalculateReceiptTime();
            order.returnTime = CalculateReturnTime();
            order.id = CountId();


            string result = client.Add(order);
            return result;
        }

        public string PrintOrder(int id)
        {
            string result = client.PrintOrder(id);
            return result;
        }

        public string PrintAllOrders()
        {
            string result = client.PrintAllOrders();
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
            id = new DirectoryInfo(path).GetFiles().Length+1;
            return id;
        }

    }
}
