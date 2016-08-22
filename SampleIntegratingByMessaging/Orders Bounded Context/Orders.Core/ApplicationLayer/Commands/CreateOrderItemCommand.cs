using System;

namespace Orders.Core.ApplicationLayer.Commands
{
    public sealed class CreateOrderItemCommand
    {

        public int Quantity { get; private set; }
        public Guid ProductId { get; private set; }

        public CreateOrderItemCommand(int quantity, string productId)
        {
            Quantity = quantity;
            ProductId = Guid.Parse(productId);
        }
    }
}
