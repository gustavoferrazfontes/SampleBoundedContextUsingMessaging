using Orders.Core.Domain.Interfaces.Repository;
using Orders.Core.Domain.OrderAggregate;
using Orders.Infra.Context;

namespace Orders.Infra.Repository.EF
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _context;
        public OrderRepository(OrderContext context)
        {
            _context = context;
        }
        public void Create(Order newOrder)
        {
            _context.Order.Add(newOrder);
        }
    }
}
