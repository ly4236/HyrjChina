namespace HyrjChina.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOrderModel1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Order", "OrderStatus");
            DropColumn("dbo.Order", "PaymentStatus");
            DropColumn("dbo.Order", "ShippingStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Order", "ShippingStatus", c => c.Int(nullable: false));
            AddColumn("dbo.Order", "PaymentStatus", c => c.Int(nullable: false));
            AddColumn("dbo.Order", "OrderStatus", c => c.Int(nullable: false));
        }
    }
}
