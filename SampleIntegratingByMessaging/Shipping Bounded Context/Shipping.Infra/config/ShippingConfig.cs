using System.Data.Entity.ModelConfiguration;

namespace Shipping.Infra.config
{
    public class ShippingConfig : EntityTypeConfiguration<Core.Domain.ShippingAggregate.Shipping>
    {

        public ShippingConfig()
        {
            HasKey(_ => _.Id);
            Property(_ => _.Id)
                .IsRequired();

            Property(_ => _.OrderId)
                .IsRequired();

            Property(_ => _.UserId)
                .IsRequired();

            Property(_ => _.ItemsQuantity)
                .IsRequired();

            Property(_ => _.CreationDate)
                .IsRequired();

            ToTable("Shipping");

        }
    }
}
