using System;
using System.Text;
using RabbitMQ.Client;
using TaskWithRabbitMQ.Model;

namespace TaskWithRabbitMQ.Framework
{
    public class CallRabbitMQ
    {
        private IConnection Connection
        {
            get
            {
                var factory = new ConnectionFactory()
                {
                    UserName = AppSettings.Instance.RabbitName,
                    Password = AppSettings.Instance.RabbitPassword,
                    VirtualHost = "/",
                    HostName = AppSettings.Instance.RabbitHost
                };
                return factory.CreateConnection();
            }
        }

        private IModel Channel
        {
            get
            {
                IModel model = Connection.CreateModel();
                model.ExchangeDeclare(AppSettings.Instance.RabbitExchangeName, ExchangeType.Direct);
                model.QueueDeclare(AppSettings.Instance.RabbitQueueName, false, false, false, null);
                model.QueueBind(AppSettings.Instance.RabbitQueueName, AppSettings.Instance.RabbitExchangeName,
                                    AppSettings.Instance.RabbitRoutingKey, null);
                return model;
            }
        }

        private void SendMessage(string message)
        {
            IModel channel = Channel;
            byte[] messageBody = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(AppSettings.Instance.RabbitExchangeName, AppSettings.Instance.RabbitRoutingKey,
                                    null, messageBody);
        }

        public string SendNewInventory(Inventory newInventory)
        {
            try
            {
                var message = SrvProvider.Instance.Source.CreateNewInventory(newInventory);
                if (!string.IsNullOrEmpty(message))
                {
                    SendMessage(message);
                }
                return message;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
