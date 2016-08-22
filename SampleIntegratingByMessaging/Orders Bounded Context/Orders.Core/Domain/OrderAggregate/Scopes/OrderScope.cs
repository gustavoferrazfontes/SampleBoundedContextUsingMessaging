using SharedKernel.Validation;
using System;

namespace Orders.Core.Domain.OrderAggregate.Scopes
{
    public static class OrderScope
    {
        public static bool PlaceAnOrderScope(this Order order)
        {
            return AssertionConcern.IsSatisfiedBy
                (
                    AssertionConcern.AssertNotNull(order, "Order must be created"),
                    AssertionConcern.AssertAreNotEquals(new Guid().ToString(), order.Id.ToString(), "Order must have an Id"),
                    AssertionConcern.AssertAreNotEquals(new Guid().ToString(), order.UserId.ToString(), "Order must have an user id")
                );
        }
    }
}
