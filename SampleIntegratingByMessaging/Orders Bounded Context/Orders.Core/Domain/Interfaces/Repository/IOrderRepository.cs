namespace Orders.Core.Domain.Interfaces.Repository
{
    public interface IOrderRepository
    {
        void Create(OrderAggregate.Order newOrder);
    }
}
