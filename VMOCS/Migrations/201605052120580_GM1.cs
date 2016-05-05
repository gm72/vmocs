namespace VMOCS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GM1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Company", "Username", c => c.String());
            AlterColumn("dbo.Company", "Password", c => c.String());
            AlterColumn("dbo.User", "Name", c => c.String());
            AlterColumn("dbo.User", "Number", c => c.String());
            AlterColumn("dbo.User", "Email", c => c.String());
            DropColumn("dbo.Company", "Account");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Company", "Account", c => c.String(nullable: false));
            AlterColumn("dbo.User", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.User", "Number", c => c.String(nullable: false));
            AlterColumn("dbo.User", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Company", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Company", "Username", c => c.String(nullable: false));
        }
    }
}
