using Shipping.Core.ApplicationLayer.Queries;
using System.Collections.Generic;

namespace Shipping.Core.ApplicationLayer.Interfaces
{
    public interface IShippingQuery
    {
        IEnumerable<NewShipping> GetAll();
    }
}
