using FluentAssertions;
using System;
using Xunit;

namespace Shipping.Core.Tests
{
    public class GivenAShipping
    {
        public Domain.ShippingAggregate.Shipping Shipping { get; set; }
    }

    public class WhenCreateAShipping:IClassFixture<GivenAShipping>
    {
        private readonly GivenAShipping _fixture;

        public WhenCreateAShipping(GivenAShipping fixture)
        {
            _fixture = fixture;

            _fixture.Shipping = new Domain.ShippingAggregate.Shipping(Guid.NewGuid(), Guid.NewGuid(),1);
        }

        [Fact]
        public void ThenShippingMustHaveId()
        {
            _fixture.Shipping.Id.Should().NotBe(new Guid());       

        }

        [Fact]
        public void ThenShippingMustHaveUserId()
        {
            _fixture.Shipping.UserId.Should().NotBe(new Guid());
        }

        [Fact]
        public void ThenShippingMustHaveOrderId()
        {
            _fixture.Shipping.OrderId.Should().NotBe(new Guid());

        }

        [Fact]
        public void ThenShippingMustHaveCreationDate()
        {
            _fixture.Shipping.CreationDate.Should().NotBe(new DateTime());
        }

        [Fact]
        public void ThenShippingMustHaveItemsQuantity()
        {
            _fixture.Shipping.ItemsQuantity.Should().NotBe(0);
        }

    }
}
