using System;
using System.Web.Hosting;
using System.Xml;

namespace DataService
{
    public class DataManager : IDataManager
    {
        public string Save(string mark, int age, int price, int motor_value, int custom_price, int full_price)
        {
            
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\App_Data\\Data.xml";
            string id=CountId(path);
            // разбить на функции

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);

            XmlElement xRoot = xDoc.DocumentElement;

            // создаем новый элемент
            XmlElement carElem = carInit(xDoc,id);
            XmlElement markElem = add_mark(xDoc, mark);
            XmlElement ageElem = add_age(xDoc, age);
            XmlElement valuElem = add_value(xDoc, motor_value);
            XmlElement priceElem = add_price(xDoc, price);
            XmlElement customPriceElem = add_custom_price(xDoc, custom_price);
            XmlElement fullPriceElem = add_full_price(xDoc, full_price);
            XmlElement receiptTime = add_receipt_time(xDoc);
            XmlElement returnTime = add_return_time(xDoc);
           
            // добавляем все элементы в главный элемент
            carElem.AppendChild(markElem);
            carElem.AppendChild(ageElem);
            carElem.AppendChild(valuElem);
            carElem.AppendChild(priceElem);
            carElem.AppendChild(customPriceElem);
            carElem.AppendChild(fullPriceElem);
            carElem.AppendChild(receiptTime);
            carElem.AppendChild(returnTime);

            // добавляем элемент в тело
            xRoot.AppendChild(carElem);

            // сохраняем
            xDoc.Save(path);

            return id;

        }
        private XmlElement carInit(XmlDocument xDoc,string id)
        {

            XmlElement carElem = xDoc.CreateElement("car");
            XmlAttribute idAttr = xDoc.CreateAttribute("id");
            XmlText idText = xDoc.CreateTextNode(id);
            idAttr.AppendChild(idText);
            carElem.Attributes.Append(idAttr);
            return carElem;

        }

        private XmlElement add_mark(XmlDocument xDoc, string mark)
        {
            XmlElement markElem = xDoc.CreateElement("mark");
            XmlText markText = xDoc.CreateTextNode(mark);
            markElem.AppendChild(markText);
            return markElem;
        }

        private XmlElement add_age(XmlDocument xDoc, int age)
        {
            XmlElement ageElem = xDoc.CreateElement("age");
            XmlText ageText = xDoc.CreateTextNode(age + "");
            ageElem.AppendChild(ageText);
            return ageElem;
        }

        private XmlElement add_value(XmlDocument xDoc, int motor_value)
        {

            XmlElement valueElem = xDoc.CreateElement("motor_value");
            XmlText valueText = xDoc.CreateTextNode("" + motor_value + "");
            valueElem.AppendChild(valueText);
            return valueElem;
        }

        private XmlElement add_price(XmlDocument xDoc, int price)
        {
            XmlElement priceElem = xDoc.CreateElement("price");
            XmlText priceText = xDoc.CreateTextNode("" + price + "");
            priceElem.AppendChild(priceText);
            return priceElem;
        }

        private XmlElement add_custom_price(XmlDocument xDoc, int custom_price)
        {
            XmlElement cpElem = xDoc.CreateElement("custom_price");
            XmlText cpText = xDoc.CreateTextNode(custom_price + "");
            cpElem.AppendChild(cpText);
            return cpElem;
        }

        private XmlElement add_full_price(XmlDocument xDoc, int full_price)
        {

            XmlElement fpElem = xDoc.CreateElement("full_price");
            XmlText fpText = xDoc.CreateTextNode(full_price + "");
            fpElem.AppendChild(fpText);
            return fpElem;
        }

        private XmlElement add_receipt_time(XmlDocument xDoc)
        {
            DateTime time = DateTime.Now;
            string now = time.ToString("dd/MM/yyyy");
            XmlElement receiptTime = xDoc.CreateElement("receipt_time");
            XmlText receiptText = xDoc.CreateTextNode(now);
            receiptTime.AppendChild(receiptText);
            return receiptTime;
        }

        private XmlElement add_return_time(XmlDocument xDoc)
        {
            DateTime time = DateTime.Now.AddDays(14);
            string calcTime = time.ToString("dd/MM/yyyy");
            XmlElement returnTime = xDoc.CreateElement("return_time");
            XmlText returnText = xDoc.CreateTextNode(calcTime);
            returnTime.AppendChild(returnText);
            return returnTime;
        }
        public string PrintOutput(string id)
        {

            string path = HostingEnvironment.ApplicationPhysicalPath + "App_Data//Data.xml";

            string output = "Your order: \r\n";

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            XmlElement xRoot = xDoc.DocumentElement;
            foreach (XmlElement xnode in xRoot)
            {
                if (xnode.Attributes.Count > 0)
                {
                    XmlNode attr = xnode.Attributes.GetNamedItem("id");
                    if (attr.Value == id)
                    {
                        output += "id : " + attr.Value + "\r\n";
                        foreach (XmlElement child in xnode.ChildNodes)
                        {
                            string name = child.Name;
                            string value = child.InnerText;

                            string result = "" + name + " : " + value;
                            output = output + "" + result + "\r\n";
                        }
                        output = output + "\r\n";
                    }

                }

            }

            return output;
        }
        private string CountId(string path) {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            XmlElement xRoot = xDoc.DocumentElement;
            XmlNodeList cars = xRoot.SelectNodes("car");
            int k = 0;
            foreach (XmlNode node in cars) {
                k++;
            }
            k++;
            return k + "";
        }
    }
}
