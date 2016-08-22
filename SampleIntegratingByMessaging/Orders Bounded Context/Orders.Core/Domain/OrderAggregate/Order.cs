using Orders.Core.Domain.OrderAggregate.Scopes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Orders.Core.Domain.OrderAggregate
{
    public sealed class Order
    {
        private IList<OrderItem> _orderItems;

        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public DateTime CreationDate { get; private set; }
        public ICollection<OrderItem> Itens { get { return _orderItems; } private set { _orderItems = new List<OrderItem>(value); } }

        public Order(IList<OrderItem> orderItems, Guid userId)
        {

            Id = Guid.NewGuid();
            UserId = userId;
            _orderItems = new List<OrderItem>();
            orderItems.ToList().ForEach(item => AddItem(item));
            CreationDate = DateTime.Now;
        }

        public bool IsValid()
        {
            return this.PlaceAnOrderScope();
        }

        private void AddItem(OrderItem item)
        {
            _orderItems.Add(item);
        }

        protected Order()
        {

        }
    }
}
