namespace HyrjChina.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMenuItemAddLevel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MenuItem", "Level", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MenuItem", "Level");
        }
    }
}
