using System;

namespace Shipping.Core.ApplicationLayer.Queries
{
    public sealed class NewShipping
    {
        public string Id { get; set; }
        public string OrderId { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
