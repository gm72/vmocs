namespace VMOCS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "Name", c => c.String());
            AlterColumn("dbo.User", "Number", c => c.String());
            AlterColumn("dbo.User", "Email", c => c.String());
            DropColumn("dbo.Company", "AccountNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Company", "AccountNumber", c => c.String(nullable: false));
            AlterColumn("dbo.User", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.User", "Number", c => c.String(nullable: false));
            AlterColumn("dbo.User", "Name", c => c.String(nullable: false));
        }
    }
}
