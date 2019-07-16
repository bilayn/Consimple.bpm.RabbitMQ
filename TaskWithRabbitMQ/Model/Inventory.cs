using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskWithRabbitMQ.Model
{
    [Table("UsrInventory")]
    public class Inventory
    {
        public Inventory()
        { }

        public Inventory(string name, string number, string type, string responsible, string notes = null)
        {

            Name = name;
            Number = number;
            Type = type;
            Responsible = responsible;
            Notes = notes;
        }

        [Column("Id")]
        public Guid? Id { get; set; }
        [Column("UsrName")]
        public string Name { get; set; }
        [Column("UsrInventoryNumber")]
        public string Number { get; set; }
        [Column("UsrInventoryTypeId")]
        public Guid TypeID { get; set; }
        [Column("UsrResponsibleId")]
        public Guid ResponsibleID { get; set; }
        [Column("UsrNotes")]
        public string Notes { get; set; }

        [NotMapped]
        public string Type { get; set; }
        [NotMapped]
        public string Responsible { get; set; }
    }
}
