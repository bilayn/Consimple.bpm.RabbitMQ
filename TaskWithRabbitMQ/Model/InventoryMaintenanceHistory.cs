using Microsoft.CodeAnalysis.CSharp;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using TaskWithRabbitMQ.Model.Dictionary;

namespace TaskWithRabbitMQ.Model
{
    public class InventoryMaintenanceHistory
    {
        private string _date;
        public string Date
        {
            get => _date;
            set
            {
                if (DateTime.TryParse(value, out DateTime resault))
                {
                    _date = value;
                }
            }
        }
        public string Cause { get; set; }
        public string Note { get; set; }
        public string Type { get; set; }
        public string Inventory { get; set; }
    }
}
