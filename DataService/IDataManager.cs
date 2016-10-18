using System.ServiceModel;

namespace DataService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface IDataManager
    {
            [OperationContract]
            string Save(string mark, int age, int price, int motor_value, int custom_price, int full_price);

            [OperationContract]
            string PrintOutput(string id);


        }
    }
