using System;
using System.Collections.Generic;

namespace Orders.Core.ApplicationLayer.Commands
{
    public sealed class PlaceAnOrderCommand
    {
        public List<CreateOrderItemCommand> Itens { get;  set; }
        public Guid UserId { get;  set; }

        public PlaceAnOrderCommand(string userId,List<CreateOrderItemCommand> itens)
        {
            UserId = Guid.Parse(userId);
            Itens = itens;

        }
    }
}
