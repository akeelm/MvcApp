namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "ModifiedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "ModifiedDate");
        }
    }
}
