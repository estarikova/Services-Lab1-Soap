using System;
using ConsoleCli.CarReference;

namespace ConsoleCli
{
    class Client
    {
        static void Main(string[] args)
        {
            using (var client = new CarDeliveryClient())
            {
                Console.WriteLine(client.TestConnection());
                Console.WriteLine(client.AddData("Renault", 2, 6500, 200));
                Console.WriteLine(client.AddData("Subaru", 1, 8000, 130));
                Console.WriteLine(client.PrintOutput("2"));
                Console.ReadKey();
            }
        }
    }
}
