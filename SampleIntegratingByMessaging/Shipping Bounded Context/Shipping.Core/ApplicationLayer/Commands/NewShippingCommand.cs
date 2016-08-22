using SharedKernel.Commands.Interfaces;
using System;

namespace Shipping.Core.ApplicationLayer.Commands
{
    public sealed class NewShippingCommand : ICommand
    {
        public Guid OrderId { get; set; }
        public Guid UserId { get; set; }
        public int ItemsQuantity { get; set; }

        public bool IsValid()
        {
            if (OrderId == new Guid()) return false;
            if (UserId == new Guid()) return false;
            if (ItemsQuantity == 0) return false;

            return true;

        }

        public NewShippingCommand(string orderId, string userId, int quantityItems)
        {
            OrderId = Guid.Parse(orderId);
            UserId = Guid.Parse(userId);
            ItemsQuantity = quantityItems;

        }
    }
}
