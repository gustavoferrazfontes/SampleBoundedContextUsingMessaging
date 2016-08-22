using Orders.Core.Domain.Events;
using SharedKernel.Interfaces;
using System;

namespace Orders.Core.ApplicationLayer.Handlers
{
    public class OrderPlacedHandler : IEventHandler<OrderPlaced>
    {
        private readonly IMessagePublisher<OrderPlaced> _messagePublisher;
        public OrderPlacedHandler(IMessagePublisher<OrderPlaced> messagePublisher)
        {
            _messagePublisher = messagePublisher;
    
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Handle(OrderPlaced args)
        {
            _messagePublisher.Publish(args);

        }
    }
}
