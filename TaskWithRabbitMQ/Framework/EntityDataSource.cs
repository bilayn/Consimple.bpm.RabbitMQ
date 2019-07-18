using System;
using System.Linq;
using Newtonsoft.Json;
using TaskWithRabbitMQ.Interface;
using TaskWithRabbitMQ.Model;
using TaskWithRabbitMQ.Model.Dictionary;

namespace TaskWithRabbitMQ.Framework
{
    public class EntityDataSource : IDataSource
    {
        public InventoryTypeDictionary FindProductType(string type)
        {
            using (DataContext db = new DataContext())
            {
                var inv = db.InventoryType;
                return db.InventoryType.Where(it => it.Name.Equals(type)).FirstOrDefault();
            }
        }

        public ContactDictionary FindContact(string name)
        {
            using (DataContext db = new DataContext())
            {
                return db.Contacts.Where(responsible => responsible.Name.Equals(name)).FirstOrDefault();
            }
        }

        public Inventory FindInventory(string inventoryNumber)
        {
            using (var db = new DataContext())
            {
                return db.Inventory.Where(i => i.Number.Equals(inventoryNumber)).FirstOrDefault();
            }
        }

        public string CreateNewInventory(Inventory newInventory)
        {
            if (string.IsNullOrEmpty(newInventory.Name) || string.IsNullOrEmpty(newInventory.Responsible) || string.IsNullOrEmpty(newInventory.Type) || string.IsNullOrEmpty(newInventory.Number))
                throw new Exception("Incorrectly entered fields!");
            else
            {
                ContactDictionary responsible = FindContact(newInventory.Responsible);
                InventoryTypeDictionary type = FindProductType(newInventory.Type);
                Inventory inventory = FindInventory(newInventory.Number);
                if (type == null || responsible == null || inventory != null)
                    throw new Exception("Incorrectly Type or Responsible is not exist's or Inventory exist!");
                else
                {
                    var element = new
                    {
                        UsrName = newInventory.Name,
                        UsrNotes = newInventory.Notes,
                        UsrInventoryNumber = newInventory.Number,
                        UsrInventoryTypeId = type.ID,
                        UsrResponsibleId = responsible.ID
                    };
                    return JsonConvert.SerializeObject(element);
                }
            }
        }
    }
}
