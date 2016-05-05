namespace VMOCS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update5 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Company", "AccountNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Company", "AccountNumber", c => c.String(nullable: false));
        }
    }
}
