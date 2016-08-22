namespace Orders.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderItem",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProductId = c.Guid(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Order_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Order", t => t.Order_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItem", "Order_Id", "dbo.Order");
            DropTable("dbo.OrderItem");
            DropTable("dbo.Order");
        }
    }
}
