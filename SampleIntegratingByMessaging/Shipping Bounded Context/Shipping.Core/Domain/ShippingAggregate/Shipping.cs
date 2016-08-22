using System;

namespace Shipping.Core.Domain.ShippingAggregate
{
    public sealed class Shipping
    {
        public Guid Id { get; private set; }
        public Guid OrderId { get; private set; }
        public Guid UserId { get; set; }
        public DateTime CreationDate { get; private set; }
        public int ItemsQuantity { get; private set; }

        public Shipping(Guid orderId, Guid userId, int itemsQuantity)
        {
            Id = Guid.NewGuid();
            OrderId = orderId;
            UserId = userId;
            ItemsQuantity = itemsQuantity;
            CreationDate = DateTime.Now;
        }

        protected Shipping()
        {

        }

    }
}
