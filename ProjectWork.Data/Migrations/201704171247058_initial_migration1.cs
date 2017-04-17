namespace ProjectWork.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial_migration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "EmailVerificationCode", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "EmailVerificationCode");
        }
    }
}
