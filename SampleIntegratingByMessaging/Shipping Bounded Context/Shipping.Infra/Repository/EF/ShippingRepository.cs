using Shipping.Core.Domain.Interfaces.Repository;
using Shipping.Infra.Context;

namespace Shipping.Infra.Repository.EF
{
    public class ShippingRepository : IShippingRepository
    {
        private readonly ShippingContext _context;

        public ShippingRepository(ShippingContext context)
        {
            _context = context;
        }
        public void Create(Core.Domain.ShippingAggregate.Shipping newShipping)
        {
            _context.Shipping.Add(newShipping);
        }
    }
}
