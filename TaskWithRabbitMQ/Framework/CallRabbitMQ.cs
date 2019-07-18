using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;
using TaskWithRabbitMQ.Model;

namespace TaskWithRabbitMQ.Framework
{
    public class CallRabbitMQ
    {
        private IConnection GetRabbitConnection()
        {
            ConnectionFactory factory = new ConnectionFactory
            {
                UserName = AppSettings.RabbitName,
                Password = AppSettings.RabbitPassword,
                VirtualHost = "/",
                HostName = AppSettings.RabbitHost,
            };

            return factory.CreateConnection();
        }

        private IModel GetRabbitChannel()
        {
            Dictionary<string, object> features = new Dictionary<string, object>();
            features.Add(key: "x-queue-type", value: "classic");
            IModel model = GetRabbitConnection().CreateModel();
            model.ExchangeDeclare(AppSettings.RabbitExchangeName, ExchangeType.Direct, true);
            model.QueueDeclare(AppSettings.RabbitQueueName, true, false, false, features);
            model.QueueBind(AppSettings.RabbitQueueName, AppSettings.RabbitExchangeName,
                                AppSettings.RabbitRoutingKey, null);
            return model;
        }

        private void SendMessage(string message)
        {
            IModel channel = GetRabbitChannel();
            byte[] messageBody = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(AppSettings.RabbitExchangeName, AppSettings.RabbitRoutingKey,
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

        public string SendNewRecordMaintenanceHistory(InventoryMaintenanceHistory imh)
        {
            try
            {
                var message = SrvProvider.Instance.Source.AddNewInventoryMaintenanceHistory(imh);
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
