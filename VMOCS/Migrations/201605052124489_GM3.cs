namespace VMOCS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GM3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Company", "Account", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Company", "Account", c => c.String(nullable: false));
        }
    }
}
