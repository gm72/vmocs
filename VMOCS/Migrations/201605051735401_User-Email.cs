namespace VMOCS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserEmail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "Email");
        }
    }
}
