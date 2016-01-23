namespace HyrjChina.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRegionModel : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Region", new[] { "ParentRegionId" });
            AlterColumn("dbo.Region", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Region", "LevelName", c => c.String(maxLength: 10));
            AlterColumn("dbo.Region", "ParentRegionId", c => c.Int());
            CreateIndex("dbo.Region", "ParentRegionId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Region", new[] { "ParentRegionId" });
            AlterColumn("dbo.Region", "ParentRegionId", c => c.Int(nullable: false));
            AlterColumn("dbo.Region", "LevelName", c => c.String());
            AlterColumn("dbo.Region", "Name", c => c.String());
            CreateIndex("dbo.Region", "ParentRegionId");
        }
    }
}
