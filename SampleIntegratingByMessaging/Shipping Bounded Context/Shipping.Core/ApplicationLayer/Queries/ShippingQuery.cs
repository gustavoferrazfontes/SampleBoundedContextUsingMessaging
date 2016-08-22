using System.Collections.Generic;
using Shipping.Core.ApplicationLayer.Interfaces;
using Shipping.Core.Domain.Interfaces.Repository;

namespace Shipping.Core.ApplicationLayer.Queries
{
    public class ShippingQuery : IShippingQuery
    {
        private readonly IShippingADORepository _shippingADORepository;
        public ShippingQuery(IShippingADORepository shippingADORepository)
        {
            _shippingADORepository = shippingADORepository;
        }
        public IEnumerable<NewShipping> GetAll()
        {
            return _shippingADORepository.GetAll();
        }
    }
}
