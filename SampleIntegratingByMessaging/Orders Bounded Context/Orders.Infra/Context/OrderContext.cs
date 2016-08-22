using Orders.Infra.config;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Orders.Infra.Context
{
    public class OrderContext : DbContext
    {

        public OrderContext():base("OrderContext")
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;

        }
        public DbSet<Core.Domain.OrderAggregate.Order> Order { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ForeignKeyIndexConvention>();
            modelBuilder.Configurations.Add(new OrderConfig());

        }
    }
}
