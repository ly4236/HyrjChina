namespace HyrjChina.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Address", "CompanyName", c => c.String());
            AddColumn("dbo.User", "Delete", c => c.Boolean(nullable: false));
            AddColumn("dbo.User", "Active", c => c.Boolean(nullable: false));
            AddColumn("dbo.User", "UserRoleId", c => c.Int(nullable: false));
            AddColumn("dbo.User", "CreateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.User", "UpdateTime", c => c.DateTime());
            AlterColumn("dbo.User", "Gender", c => c.String(maxLength: 200));
            AlterColumn("dbo.User", "Birthday", c => c.DateTime());
            AlterColumn("dbo.User", "Email", c => c.String(maxLength: 200));
            AlterColumn("dbo.User", "PhoneNumber", c => c.String(maxLength: 20));
            DropColumn("dbo.User", "IDCard");
            DropColumn("dbo.User", "Nation");
            DropColumn("dbo.User", "Degree");
            DropColumn("dbo.User", "Major");
            DropColumn("dbo.User", "NativePlace");
            DropColumn("dbo.User", "EmergencyCall");
            DropColumn("dbo.User", "IsDelete");
            DropColumn("dbo.User", "IsActive");
            DropColumn("dbo.User", "UserRole");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "UserRole", c => c.String());
            AddColumn("dbo.User", "IsActive", c => c.String());
            AddColumn("dbo.User", "IsDelete", c => c.String());
            AddColumn("dbo.User", "EmergencyCall", c => c.String());
            AddColumn("dbo.User", "NativePlace", c => c.String());
            AddColumn("dbo.User", "Major", c => c.String());
            AddColumn("dbo.User", "Degree", c => c.String());
            AddColumn("dbo.User", "Nation", c => c.String());
            AddColumn("dbo.User", "IDCard", c => c.String());
            AlterColumn("dbo.User", "PhoneNumber", c => c.String());
            AlterColumn("dbo.User", "Email", c => c.String());
            AlterColumn("dbo.User", "Birthday", c => c.String());
            AlterColumn("dbo.User", "Gender", c => c.String());
            DropColumn("dbo.User", "UpdateTime");
            DropColumn("dbo.User", "CreateTime");
            DropColumn("dbo.User", "UserRoleId");
            DropColumn("dbo.User", "Active");
            DropColumn("dbo.User", "Delete");
            DropColumn("dbo.Address", "CompanyName");
        }
    }
}
