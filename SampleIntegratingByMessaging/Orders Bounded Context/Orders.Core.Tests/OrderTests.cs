using FluentAssertions;
using Orders.Core.Domain.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Orders.Core.Tests
{
    public class GivenPlaceAnOrder
    {

        Order newOrder;
        List<OrderItem> orderItems;
        public GivenPlaceAnOrder()
        {
            orderItems = new List<OrderItem>();
            orderItems.Add(new OrderItem(Guid.NewGuid(), 1));
            newOrder = new Order(orderItems, Guid.NewGuid());
        }

        [Fact]
        public void ThenOrderIsCreated()
        {
            Assert.NotNull(newOrder);
        }

        [Fact]
        public void ThenOrderMustHaveAnId()
        {
            newOrder.Id.Should().NotBe(new Guid());
        }

        [Fact]
        public void ThenOrderMustHaveAnUserId()
        {
            newOrder.UserId.Should().NotBe(new Guid());
        }

        [Fact]
        public void ThenOrderMustHaveAtLeastOneOrderItem()
        {
            newOrder.Itens.Count().Should().BeGreaterThan(0);
        }

        [Fact]
        public void ThenOrderItemMustHaveProductId()
        {
            newOrder.Itens.First().ProductId.Should().NotBe(new Guid());
        }

        [Fact]
        public void ThenQuantityOfOrderItemMustBeGreaterThanZero()
        {
            newOrder.Itens.First().Quantity.Should().BeGreaterThan(0);
        }
    }
}
