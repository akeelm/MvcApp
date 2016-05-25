namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Notnullconstraints : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserForgotPassword", "Code", c => c.String(nullable: false));
            AlterColumn("dbo.User", "Username", c => c.String(nullable: false));
            AlterColumn("dbo.User", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.User", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "Password", c => c.String());
            AlterColumn("dbo.User", "Email", c => c.String());
            AlterColumn("dbo.User", "Username", c => c.String());
            AlterColumn("dbo.UserForgotPassword", "Code", c => c.String());
        }
    }
}
