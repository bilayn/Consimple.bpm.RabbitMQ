using TaskWithRabbitMQ.Model;
using TaskWithRabbitMQ.Model.Dictionary;

namespace TaskWithRabbitMQ.Interface
{
    public interface IDataSource
    {
        Inventory FindInventory(string invNumber);

        string CreateNewInventory(Inventory model);
    }
}
