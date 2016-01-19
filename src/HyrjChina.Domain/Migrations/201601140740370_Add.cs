namespace HyrjChina.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MenuItem",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ActionName = c.String(),
                        ControllerName = c.String(),
                        Url = c.String(),
                        Order = c.Int(nullable: false),
                        Disable = c.Boolean(nullable: false),
                        HasAccess = c.Boolean(nullable: false),
                        ParentMenuID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MenuItem", t => t.ParentMenuID)
                .Index(t => t.ParentMenuID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MenuItem", "ParentMenuID", "dbo.MenuItem");
            DropIndex("dbo.MenuItem", new[] { "ParentMenuID" });
            DropTable("dbo.MenuItem");
        }
    }
}
