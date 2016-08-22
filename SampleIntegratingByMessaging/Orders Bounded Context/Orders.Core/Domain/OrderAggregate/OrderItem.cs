using System;

namespace Orders.Core.Domain.OrderAggregate
{
    public sealed class OrderItem
    {
        public Guid Id { get; private set; }
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }

        public OrderItem(Guid productId, int quantity)
        {
            Id = Guid.NewGuid();
            ProductId = productId;
            Quantity = quantity;
        }

        protected OrderItem()
        {

        }

    }
}
