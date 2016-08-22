namespace Shipping.Core.Domain.Interfaces.Repository
{
    public interface IShippingRepository
    {
        void Create(ShippingAggregate.Shipping newShipping);
    }
}
