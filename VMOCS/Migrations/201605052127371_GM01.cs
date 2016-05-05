namespace VMOCS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GM01 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Company", "CompanyName", c => c.String());
            AlterColumn("dbo.Company", "Username", c => c.String());
            AlterColumn("dbo.Company", "Password", c => c.String());
            DropColumn("dbo.Company", "Account");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Company", "Account", c => c.String());
            AlterColumn("dbo.Company", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Company", "Username", c => c.String(nullable: false));
            AlterColumn("dbo.Company", "CompanyName", c => c.String(nullable: false));
        }
    }
}
