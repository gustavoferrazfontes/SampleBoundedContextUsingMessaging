using System.Data.Entity.ModelConfiguration;

namespace Orders.Infra.config
{
    public class OrderConfig : EntityTypeConfiguration<Core.Domain.OrderAggregate.Order>
    {
        public OrderConfig()
        {
            HasKey(_ => _.Id);
            Property(_ => _.Id)
                .IsRequired();

            Property(_ => _.UserId)
                .IsRequired();

            Property(_ => _.CreationDate)
                .IsRequired();

            HasMany(_ => _.Itens);

        }
    }
}
