namespace HyrjChina.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnumTest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "OrderStatusId", c => c.Int(nullable: false));
            AddColumn("dbo.Order", "PaymentStatusId", c => c.Int(nullable: false));
            AddColumn("dbo.Order", "ShippingStatusId", c => c.Int(nullable: false));
            AddColumn("dbo.Order", "OrderStatus", c => c.Int(nullable: false));
            AddColumn("dbo.Order", "OrderDiscount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Order", "PaymentStatus", c => c.Int(nullable: false));
            AddColumn("dbo.Order", "OrderTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Order", "ShippingStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Order", "ShippingStatus");
            DropColumn("dbo.Order", "OrderTotal");
            DropColumn("dbo.Order", "PaymentStatus");
            DropColumn("dbo.Order", "OrderDiscount");
            DropColumn("dbo.Order", "OrderStatus");
            DropColumn("dbo.Order", "ShippingStatusId");
            DropColumn("dbo.Order", "PaymentStatusId");
            DropColumn("dbo.Order", "OrderStatusId");
        }
    }
}
