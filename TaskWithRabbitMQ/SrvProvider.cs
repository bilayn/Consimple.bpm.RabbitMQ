using TaskWithRabbitMQ.Framework;
using TaskWithRabbitMQ.Interface;

namespace TaskWithRabbitMQ
{
    public class SrvProvider
    {
        private SrvProvider() { }
        private static SrvProvider _instance;
        public static SrvProvider Instance { get => _instance == null ? _instance = new SrvProvider() : _instance; }

        public IDataSource Source
        {
            get
            {
                switch (AppSettings.DataSource)
                {
                    default: return new EntityDataSource();
                }
            }
        }
    }
}
