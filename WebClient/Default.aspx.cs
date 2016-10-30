using System;
using System.Net.Http;

namespace WebClient
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage wcfResponse = client.GetAsync("http://localhost:80/CarService/CarDelivery.svc/json/printAllOrders").Result;
            HttpContent stream = wcfResponse.Content;
            var data = stream.ReadAsStringAsync().Result.ToString();
            
            Label1.Text = data;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            var mark = (_Mark.Text);
            var age = int.Parse(_Age.Text);
            var price = int.Parse(_Price.Text);
            var motorValue = int.Parse(_MotorValue.Text);
            HttpResponseMessage wcfResponse = client.GetAsync("http://localhost:80/CarService/CarDelivery.svc/json/AddData?mark=" + mark + "&age=" + age + "&price=" + price + "&motorValue=" + motorValue).Result;
            HttpContent stream = wcfResponse.Content;
            var data = stream.ReadAsStringAsync().Result.ToString();
            
            Label3.Text = data;
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            var id = (_ID.Text);
            HttpResponseMessage wcfResponse = client.GetAsync("http://localhost:80/CarService/CarDelivery.svc/json/PrintOrder?id=" + id).Result;
            HttpContent stream = wcfResponse.Content;
            var data = stream.ReadAsStringAsync().Result.ToString();
            
            Label2.Text = data;
        }
    }
}