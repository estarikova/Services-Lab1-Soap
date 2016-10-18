using CarService.DataReference;

namespace CarService
{

    public class CarDelivery : ICarDelivery
    {
        public string TestConnection()
        {
            return "Test Connection Status: Ok\r\n";
        }

        public string AddData(string mark, int age, int price, int motor_value)
        {
            string result = "Your data is saved Successfully\r\n\r\n";

            int customPrice = CalcCP(age, price, motor_value);
            int fullPrice = CalcFP(customPrice);
            using (var client = new DataManagerClient())
            {

                string id = client.Save(mark, age, price, motor_value, customPrice, fullPrice);
                result += client.PrintOutput(id);
            }
            return result;
        }

        public string PrintOutput(string id)
        {

            string result = "";
            using (var client = new DataManagerClient())
            {
                result += client.PrintOutput(id);
            }
            return result;
        }

        private int CalcCP(int age, int price, int motor_value)
        {
            int result = (price + motor_value) / age;
            return result;
        }
        private int CalcFP(int cp)
        {
            int result = cp + 5000;
            return result;
        }

    }
}
