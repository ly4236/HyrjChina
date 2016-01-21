namespace HyrjChina.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnumTest1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Order", "OrderStatusId");
            DropColumn("dbo.Order", "PaymentStatusId");
            DropColumn("dbo.Order", "ShippingStatusId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Order", "ShippingStatusId", c => c.Int(nullable: false));
            AddColumn("dbo.Order", "PaymentStatusId", c => c.Int(nullable: false));
            AddColumn("dbo.Order", "OrderStatusId", c => c.Int(nullable: false));
        }
    }
}
