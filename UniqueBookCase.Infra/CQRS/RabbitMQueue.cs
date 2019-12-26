using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using UniqueBookCase.DomainModel.CQRS;
using UniqueBookCase.DomainModel.Interfaces.CQRS;

namespace UniqueBookCase.Infra.CQRS
{
    public class RabbitMQueue : IQueue
    {

        public void Enqueue(QueueMessage message)
        {
            var factory = new ConnectionFactory()
            {
                HostName = Properties.Resources.ResourceManager.GetString("HostnameRabbitMQ"),
                Port = Convert.ToInt16(Properties.Resources.ResourceManager.GetString("PortRabbitMQ")),
                UserName = Properties.Resources.ResourceManager.GetString("UsernameRabbitMQ"),
                Password = Properties.Resources.ResourceManager.GetString("PasswordRabbitMQ"),
                
            };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: message.QueueName,
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);

                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

                channel.BasicPublish(exchange: "",
                                    routingKey: message.QueueName,
                                    basicProperties: null,
                                    body: body);

            }
        }

        public string Dequeue(string queueName)
        {
            string message = String.Empty;
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: queueName,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    message = Encoding.UTF8.GetString(body);
                };
                channel.BasicConsume(queue: queueName,
                                     autoAck: true,
                                     consumer: consumer);
                return message;
            }
        }
    }
}
