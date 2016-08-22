using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SharedKernel.Messaging;
using Shipping.Core.ApplicationLayer.Commands;
using System;
using System.Diagnostics;
using System.Text;

namespace WebApi.Helpers
{
    public class MessageListener
    {
        private static IConnection _connection;
        private static IModel _channel;

     

        public static void Start()
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                AutomaticRecoveryEnabled = true,
                NetworkRecoveryInterval = TimeSpan.FromSeconds(15
                )
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare("OrderPlaced", "fanout");

            var queueName = _channel.QueueDeclare().QueueName;
            _channel.QueueBind(queue: queueName, exchange: "OrderPlaced", routingKey: "");
            _channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

            var consumer = new EventingBasicConsumer(_channel);
            var message = string.Empty;
            consumer.Received += ConsumerOnReceived;
            _channel.BasicConsume(queue: queueName, noAck: false, consumer: consumer);
            Debug.WriteLine("listening...");

        }



        private static void ConsumerOnReceived(object sender, BasicDeliverEventArgs ea)
        {
            Debug.WriteLine("publish maked");
            var body = ea.Body;
            var message = Encoding.UTF8.GetString(body);
            var notification = JsonConvert.DeserializeObject<Message>(message);
            ProcessMessageContent<NewShippingCommand>.Process(notification);
            _channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);

        }

        public static void Stop()
        {
            _channel.Close(200, "Goodbye");
            _connection.Close();
        }
    }
}