using SharedKernel.Interfaces;
using RabbitMQ.Client;
using Orders.Core.Domain.Events;
using Newtonsoft.Json;
using System.Text;
using SharedKernel.Events;
using SharedKernel.Messaging;
using System;

namespace Orders.Infra.Publishers
{
    public class OrderPlacedPublisher : IMessagePublisher<OrderPlaced>
    {

        public void Publish(OrderPlaced domainEvent)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare(exchange: "OrderPlaced", type: "fanout");
                    var message = JsonConvert.SerializeObject(domainEvent, Formatting.None);
                    var content = new Message { Key = "OrderPlaced", Value = message, DateOccurred = DateTime.Now };
                    var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(content, Formatting.None));
                    var properties = channel.CreateBasicProperties();


                    properties.Persistent = true;
                    channel.BasicPublish
                        (
                            exchange: "OrderPlaced",
                            routingKey: string.Empty,
                            basicProperties: properties,
                            body: body
                        );
                }
            }
        }
    }
}
