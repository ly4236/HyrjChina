namespace HyrjChina.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUpdateTimeForOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "UpdateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Order", "UpdateTime");
        }
    }
}
