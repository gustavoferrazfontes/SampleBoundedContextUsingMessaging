namespace Shipping.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShippingCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Shipping",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        OrderId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        ItemsQuantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Shipping");
        }
    }
}
