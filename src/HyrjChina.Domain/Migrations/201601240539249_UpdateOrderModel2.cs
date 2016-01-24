namespace HyrjChina.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOrderModel2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "OrderStatus", c => c.Int(nullable: false));
            AddColumn("dbo.Order", "PaymentStatus", c => c.Int(nullable: false));
            AddColumn("dbo.Order", "ShippingStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Order", "ShippingStatus");
            DropColumn("dbo.Order", "PaymentStatus");
            DropColumn("dbo.Order", "OrderStatus");
        }
    }
}
