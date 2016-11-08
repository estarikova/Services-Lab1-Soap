using System;
using System.Xml.Serialization;
using System.IO;

namespace CarService
{
    public class DataService : IDataService
    {

        string startOfPath = AppDomain.CurrentDomain.BaseDirectory + "\\App_Data\\Order";
        string endOfPath = ".xml";
        public Order Add(Order order)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Order));

            using (FileStream fileStream = new FileStream(startOfPath + order.id + endOfPath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fileStream, order);
            }
            Order savedOrder = PrintOrder(order.id);
            return savedOrder;

        }

        public Order PrintOrder(int id)
        {
            Order order = Find(id);
            return order;
        }

        public Order[] PrintAllOrders()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\App_Data\\";
            int j = new DirectoryInfo(path).GetFiles().Length;
            Order[] orders = new Order[j];
            for (int i = 0; i < j; i++) {
                if (j >= 1)
                {
                    orders[i] = Find(i+1);
                }
            }
            return orders;
        }


        private Order Find(int id)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Order));
            Order newOrder = new Order();
            using (FileStream fileStream = new FileStream(startOfPath + id + endOfPath, FileMode.OpenOrCreate))
            {
                newOrder = (Order)formatter.Deserialize(fileStream);
            }
            return newOrder;

        }

    }
}