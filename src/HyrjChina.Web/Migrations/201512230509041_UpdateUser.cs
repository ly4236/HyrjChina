namespace HyrjChina.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUser : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Customer");
            AddColumn("dbo.Customer", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Customer", "LastLoginTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customer", "Name", c => c.String(maxLength: 50));
            AddPrimaryKey("dbo.Customer", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Customer");
            AlterColumn("dbo.Customer", "Name", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Customer", "LastLoginTime");
            DropColumn("dbo.Customer", "Id");
            AddPrimaryKey("dbo.Customer", "Name");
        }
    }
}
