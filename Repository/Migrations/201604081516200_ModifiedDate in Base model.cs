namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedDateinBasemodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Deleted", c => c.Boolean(nullable: false));
            DropColumn("dbo.User", "Disabled");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "Disabled", c => c.Boolean(nullable: false));
            DropColumn("dbo.User", "Deleted");
        }
    }
}
