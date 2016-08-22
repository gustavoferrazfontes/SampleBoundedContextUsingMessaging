using Shipping.Core.ApplicationLayer.Queries;
using System.Collections.Generic;

namespace Shipping.Core.Domain.Interfaces.Repository
{
    public interface IShippingADORepository
    {
        IEnumerable<NewShipping> GetAll();
    }
}
