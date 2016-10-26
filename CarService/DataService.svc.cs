using System;
using System.Xml.Serialization;
using System.IO;
using System.Web.Script.Serialization;

namespace CarService
{
    public class DataService : IDataService
    {

        string startOfPath = AppDomain.CurrentDomain.BaseDirectory + "\\App_Data\\Order";
        string endOfPath = ".xml";
        public string Add(Order order)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Order));

            using (FileStream fileStream = new FileStream(startOfPath+order.id+endOfPath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fileStream, order);
            }
            string result = "Your order was added<br><br>";
            result += PrintOrder(order.id)+"<br>";
            return result;

        }

        public string PrintOrder(int id)
        {
            Order order = Find(id);
            string result = new JavaScriptSerializer().Serialize(order);
            return result;
        }

        public string PrintAllOrders()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\App_Data\\";
            int j = new DirectoryInfo(path).GetFiles().Length;
            string result="";
            if (j >= 1)
            {
                for (int i = 1; i <= j; i++)
                {
                    result += PrintOrder(i) + "";
                }
            }
            result = "[" + result + "]";
            return result;
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
