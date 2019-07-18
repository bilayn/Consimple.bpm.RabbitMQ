namespace TaskWithRabbitMQ
{
    public static class AppSettings
    {
        public static string DataSource { get => "Entity"; }
        public static string UserName { get => "Supervisor"; }
        public static string Password { get => "Supervisor"; }
        public static string ConnectionString { get => "Data Source=WIN-BEAA7MI3J3O\\MSSQLSERVER2016;Initial Catalog=Yuri_study;User ID=Supervisor;Password=Supervisor;"; }

        public static string RabbitName { get => "guest"; }
        public static string RabbitPassword { get => "guest"; }
        public static string RabbitHost { get => "localhost"; }
        public static string RabbitExchangeName { get => "test"; }
        public static string RabbitQueueName { get => "test"; }
        public static string RabbitRoutingKey { get => "test"; }
    }
}
