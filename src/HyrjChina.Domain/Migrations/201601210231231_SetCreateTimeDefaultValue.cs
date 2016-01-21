namespace HyrjChina.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetCreateTimeDefaultValue : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Order", "CreateTime", c => c.DateTime(nullable: false, defaultValueSql:"GetDate()"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Order", "CreateTime", c => c.DateTime(nullable: false));
        }
    }
}
