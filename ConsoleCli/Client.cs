using System;
using ConsoleCli.CarReference;

namespace ConsoleCli
{
    class car {

    }
    class Client
    {
        static void Main(string[] args)
        {
            using (var client = new CarDeliveryClient())
            {
                Console.WriteLine(client.AddData("Subaru", 3, 7500, 1500));

                Console.WriteLine(client.AddData("Subaru", 3, 7500, 1500));

                Console.WriteLine(client.AddData("Subaru", 3, 7500, 1500));
                Console.WriteLine(client.PrintOrder(1));
                Console.WriteLine(client.PrintAllOrders());
                Console.ReadKey();
            }
        }
    }
}
