namespace HyrjChina.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserAddressMap : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserAddress",
                c => new
                    {
                        AddressId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AddressId, t.UserId })
                .ForeignKey("dbo.Address", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.AddressId)
                .Index(t => t.UserId);
            
            AddColumn("dbo.Order", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserAddress", "UserId", "dbo.User");
            DropForeignKey("dbo.UserAddress", "AddressId", "dbo.Address");
            DropIndex("dbo.UserAddress", new[] { "UserId" });
            DropIndex("dbo.UserAddress", new[] { "AddressId" });
            DropColumn("dbo.Order", "Name");
            DropTable("dbo.UserAddress");
        }
    }
}
