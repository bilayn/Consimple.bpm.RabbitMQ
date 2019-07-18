using TaskWithRabbitMQ.Model;

namespace TaskWithRabbitMQ.Interface
{
    public interface IDataSource
    {
        Inventory FindInventory(string invNumber);

        string CreateNewInventory(Inventory model);
        string AddNewInventoryMaintenanceHistory(InventoryMaintenanceHistory imh);
    }
}
