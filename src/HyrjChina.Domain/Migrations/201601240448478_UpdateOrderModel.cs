namespace HyrjChina.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOrderModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Order", "PaidTime", c => c.DateTime());
            AlterColumn("dbo.Order", "UpdateTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Order", "UpdateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Order", "PaidTime", c => c.DateTime(nullable: false));
        }
    }
}
