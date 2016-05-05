namespace VMOCS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GM2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Company", "Account", c => c.String(nullable: false));
            AlterColumn("dbo.Company", "CompanyName", c => c.String(nullable: false));
            AlterColumn("dbo.Company", "Username", c => c.String(nullable: false));
            AlterColumn("dbo.Company", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.User", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.User", "Number", c => c.String(nullable: false));
            AlterColumn("dbo.User", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "Email", c => c.String());
            AlterColumn("dbo.User", "Number", c => c.String());
            AlterColumn("dbo.User", "Name", c => c.String());
            AlterColumn("dbo.Company", "Password", c => c.String());
            AlterColumn("dbo.Company", "Username", c => c.String());
            AlterColumn("dbo.Company", "CompanyName", c => c.String());
            DropColumn("dbo.Company", "Account");
        }
    }
}
