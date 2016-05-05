namespace VMOCS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Company", "Account", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Company", "Account");
        }
    }
}
