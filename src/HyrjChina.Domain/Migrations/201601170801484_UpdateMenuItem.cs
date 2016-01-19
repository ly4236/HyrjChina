namespace HyrjChina.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMenuItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MenuItem", "Icon", c => c.String(maxLength: 50));
            AlterColumn("dbo.MenuItem", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.MenuItem", "ActionName", c => c.String(maxLength: 50));
            AlterColumn("dbo.MenuItem", "ControllerName", c => c.String(maxLength: 50));
            AlterColumn("dbo.MenuItem", "Url", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MenuItem", "Url", c => c.String());
            AlterColumn("dbo.MenuItem", "ControllerName", c => c.String());
            AlterColumn("dbo.MenuItem", "ActionName", c => c.String());
            AlterColumn("dbo.MenuItem", "Name", c => c.String());
            DropColumn("dbo.MenuItem", "Icon");
        }
    }
}
