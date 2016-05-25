namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        LoginDate = c.DateTime(nullable: false),
                        Disabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.User");
        }
    }
}
