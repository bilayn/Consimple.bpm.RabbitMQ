using Microsoft.EntityFrameworkCore;
using TaskWithRabbitMQ.Framework.Infrastructure;
using TaskWithRabbitMQ.Model.Dictionary;

namespace TaskWithRabbitMQ.Model
{
    public class DataContext : DbContext
    {
        // private string _conectionString = @"Data Source=WIN-BEAA7MI3J3O\MSSQLSERVER2016;Initial Catalog = Yuri_study; User ID = Supervisor; Password=Supervisor";
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<InventoryTypeDictionary> InventoryType { get; set; }
        public DbSet<ServiceTypeDictionary> ServiceTypes { get; set; }
        public DbSet<ContactDictionary> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>

                                                       optionsBuilder.UseSqlServer($@"{Resources.ConnectionString};");

        //public DataContext(DbContextOptions<DataContext> options)
        //    : base(options)
        //{ }
    }
}
