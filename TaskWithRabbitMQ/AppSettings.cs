namespace TaskWithRabbitMQ
{
    public class AppSettings
    {
        private static AppSettings _instance;
        private AppSettings()
        {
        }
        public static AppSettings Instance { get => _instance == null ? _instance = new AppSettings() : _instance; }

        public string DataSource { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConnectionString { get; set; }

        public string RabbitName { get; set; }
        public string RabbitPassword { get; set; }
        public string RabbitHost { get; set; }
        public string RabbitExchangeName { get; set; }
        public string RabbitQueueName { get; set; }
        public string RabbitRoutingKey { get; set; }
    }
}
