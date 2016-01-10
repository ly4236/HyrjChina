namespace HyrjChina.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(maxLength: 50),
                        Password = c.String(maxLength: 200),
                        Name = c.String(maxLength: 200),
                        IDCard = c.String(),
                        Nation = c.String(),
                        Gender = c.String(),
                        Birthday = c.String(),
                        Degree = c.String(),
                        Major = c.String(),
                        NativePlace = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        EmergencyCall = c.String(),
                        IsDelete = c.String(),
                        IsActive = c.String(),
                        UserRole = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.User");
        }
    }
}
