namespace HyrjChina.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "Email", c => c.String(maxLength: 50));
            AddColumn("dbo.Customer", "Phone", c => c.String(maxLength: 20));
            AddColumn("dbo.Customer", "AdminComment", c => c.String());
            AlterColumn("dbo.Customer", "Password", c => c.String(maxLength: 32));
            AlterColumn("dbo.Customer", "Nick", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customer", "Nick", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Customer", "Password", c => c.String(nullable: false, maxLength: 32));
            DropColumn("dbo.Customer", "AdminComment");
            DropColumn("dbo.Customer", "Phone");
            DropColumn("dbo.Customer", "Email");
        }
    }
}
