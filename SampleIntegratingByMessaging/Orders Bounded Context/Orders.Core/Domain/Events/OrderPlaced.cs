using System;
using SharedKernel.Events.Interfaces;
using System.Linq;
using Orders.Core.Domain.OrderAggregate;

namespace Orders.Core.Domain.Events
{
    public sealed class OrderPlaced : IDomainEvent
    {
        private DateTime _dateOccured;
        public DateTime DateOccurred
        {
            get
            {
                return _dateOccured;
            }
        }

        public Guid OrderId { get; private set; }
        public Guid UserId { get; private set; }
        public int ItemsQuantity { get; private set; }

        public OrderPlaced(Order newOrder)
        {
            _dateOccured = DateTime.Now;
            OrderId = newOrder.Id;
            UserId = newOrder.UserId;
            ItemsQuantity = newOrder.Itens.Count();

        }
    }
}
