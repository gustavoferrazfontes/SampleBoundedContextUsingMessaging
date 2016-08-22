using Orders.Core.ApplicationLayer.Commands;

namespace Orders.Core.ApplicationLayer.Interfaces
{
    public interface IOrdersManagement
    {
        void PlaceAnOrder(PlaceAnOrderCommand command);
    }
}
