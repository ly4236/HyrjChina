namespace HyrjChina.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOrder : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Order", "OrderTotal", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Order", "OrderTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
