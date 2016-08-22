using Orders.Core.ApplicationLayer.Interfaces;
using Orders.Core.ApplicationLayer.Commands;
using System.Collections.Generic;
using SharedKernel.Events;
using SharedKernel.Interfaces;
using Orders.Core.Domain.OrderAggregate;
using Orders.Core.Domain.Events;
using Orders.Core.Domain.Interfaces.Repository;

namespace Orders.Core.ApplicationLayer.UseCases
{
    public sealed class OrdersManagement : UseCase, IOrdersManagement
    {
        private readonly IOrderRepository _orderRepository;
        public OrdersManagement(INotifiable<DomainNotification> domainNotification, IEnumerable<IUnitOfWork> uow, IOrderRepository orderRepository)
            : base(domainNotification, uow)
        {
            _orderRepository = orderRepository;
        }

        public void PlaceAnOrder(PlaceAnOrderCommand command)
        {
            var itens = new List<OrderItem>();
            foreach (var item in command.Itens)
            {
                var newItem = new OrderItem(item.ProductId, item.Quantity);
                itens.Add(newItem);
            }
            var newOrder = new Order(itens, command.UserId);
            if (newOrder.IsValid())
            {
                _orderRepository.Create(newOrder);
                DomainEvent.Raise(new OrderPlaced(newOrder));
            }

            Commit();
        }

    }
}
