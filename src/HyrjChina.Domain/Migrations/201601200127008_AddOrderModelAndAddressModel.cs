namespace HyrjChina.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderModelAndAddressModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ConsigneeName = c.String(maxLength: 50),
                        ProvinceId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                        TownId = c.Int(nullable: false),
                        CompleteAddress = c.String(),
                        Phone = c.String(),
                        Tel = c.String(),
                        AddressName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Region", t => t.CityId)
                .ForeignKey("dbo.Region", t => t.ProvinceId)
                .ForeignKey("dbo.Region", t => t.TownId)
                .Index(t => t.ProvinceId)
                .Index(t => t.CityId)
                .Index(t => t.TownId);
            
            CreateTable(
                "dbo.Region",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Level = c.Int(nullable: false),
                        LevelName = c.String(),
                        ParentRegionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Region", t => t.ParentRegionId)
                .Index(t => t.ParentRegionId);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderNumber = c.String(),
                        UserId = c.Int(nullable: false),
                        AddressId = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        PaidTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Address", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.OrderItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Order", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Address", "TownId", "dbo.Region");
            DropForeignKey("dbo.Address", "ProvinceId", "dbo.Region");
            DropForeignKey("dbo.Order", "UserId", "dbo.User");
            DropForeignKey("dbo.OrderItem", "ProductId", "dbo.Product");
            DropForeignKey("dbo.OrderItem", "OrderId", "dbo.Order");
            DropForeignKey("dbo.Order", "AddressId", "dbo.Address");
            DropForeignKey("dbo.Address", "CityId", "dbo.Region");
            DropForeignKey("dbo.Region", "ParentRegionId", "dbo.Region");
            DropIndex("dbo.OrderItem", new[] { "ProductId" });
            DropIndex("dbo.OrderItem", new[] { "OrderId" });
            DropIndex("dbo.Order", new[] { "AddressId" });
            DropIndex("dbo.Order", new[] { "UserId" });
            DropIndex("dbo.Region", new[] { "ParentRegionId" });
            DropIndex("dbo.Address", new[] { "TownId" });
            DropIndex("dbo.Address", new[] { "CityId" });
            DropIndex("dbo.Address", new[] { "ProvinceId" });
            DropTable("dbo.OrderItem");
            DropTable("dbo.Order");
            DropTable("dbo.Region");
            DropTable("dbo.Address");
        }
    }
}
