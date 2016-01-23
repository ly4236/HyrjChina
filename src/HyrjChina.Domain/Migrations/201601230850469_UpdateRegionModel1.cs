namespace HyrjChina.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRegionModel1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Region", "Code", c => c.String(maxLength: 15));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Region", "Code");
        }
    }
}
