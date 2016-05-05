namespace VMOCS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rollback1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Company", "CompanyName", c => c.String());
            AlterColumn("dbo.Company", "Username", c => c.String());
            AlterColumn("dbo.Company", "Password", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Company", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Company", "Username", c => c.String(nullable: false));
            AlterColumn("dbo.Company", "CompanyName", c => c.String(nullable: false));
        }
    }
}
