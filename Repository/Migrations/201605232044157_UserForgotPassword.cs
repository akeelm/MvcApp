namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserForgotPassword : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserForgotPassword",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        Code = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserForgotPassword", "UserID", "dbo.User");
            DropIndex("dbo.UserForgotPassword", new[] { "UserID" });
            DropTable("dbo.UserForgotPassword");
        }
    }
}
