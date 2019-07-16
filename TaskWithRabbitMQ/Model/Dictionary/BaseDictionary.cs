using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskWithRabbitMQ.Model.Dictionary
{
    public class BaseDictionary
    {
        [Key]
        [Column("Id")]
        public Guid? ID { get; set; }
        [Column("Name")]
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{ID} {Name}";
        }
    }
}
