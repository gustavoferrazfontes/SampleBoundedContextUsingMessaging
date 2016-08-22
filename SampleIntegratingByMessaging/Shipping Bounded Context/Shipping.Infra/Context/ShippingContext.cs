using Shipping.Infra.config;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Shipping.Infra.Context
{
    public class ShippingContext : DbContext
    {
        public DbSet<Core.Domain.ShippingAggregate.Shipping> Shipping { get; set; }
        public ShippingContext() : base("shippingContext")
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ForeignKeyIndexConvention>();
            modelBuilder.Configurations.Add(new ShippingConfig());

        }
    }
}
