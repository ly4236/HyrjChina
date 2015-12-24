namespace HyrjChina.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 32),
                        Nick = c.String(nullable: false, maxLength: 50),
                        Active = c.Boolean(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Name);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Customer");
        }
    }
}
