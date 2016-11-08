using System;
using WebClient.CarDelivery;

namespace WebClient
{

    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            using (var client = new CarDeliveryClient())
            {
                Order[] orders = client.PrintAllOrders();
                int i = 0;
                string result = "";

                foreach (var n in orders) {
                    result += stringFormat(orders[i]);
                    result += "<br/>";
                    i++;
                 }

                Label1.Text = result;

            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            using (var client = new CarDeliveryClient())
            {
                Order newOrder = new Order();
                newOrder.mark = (_Mark.Text);
                newOrder.age = int.Parse(_Age.Text);
                newOrder.price = int.Parse(_Price.Text);
                newOrder.motorValue = int.Parse(_MotorValue.Text);
                newOrder = client.AddData(newOrder);
                string result = "Your order was added! <br/><br/>";
                result += stringFormat(newOrder);
                Label3.Text = result;
            }
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            using (var client = new CarDeliveryClient())
            {
                int id = int.Parse(_ID.Text);
                Order order = client.PrintOrder(id);
                string result = stringFormat(order);

                Label2.Text = result;



            }
        }
        private string stringFormat(Order order) {
            string result = "<div id='order" + order.id + "' class='order'>";
            result += string.Format("Id:{0} <br/>", order.id);
            result += string.Format("Mark:{0} <br/>", order.mark);
            result += string.Format("Age:{0} <br/>", order.age);
            result += string.Format("Price:{0} <br/>", order.price);
            result += string.Format("Motor Value:{0} <br/>", order.motorValue);
            result += string.Format("Custom Price:{0} <br/>", order.customPrice);
            result += string.Format("Full Price:{0} <br/>", order.fullPrice);
            result += string.Format("Receipt Time:{0} <br/>", order.receiptTime);
            result += string.Format("Return Time:{0} <br/>", order.returnTime);
            result += "</div>";
            return result;
        }
    }
}