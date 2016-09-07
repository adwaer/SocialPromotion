namespace Nanny.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emailindex : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.SimpleCustomerAccounts", "IX_Unique_UserName");
            AlterColumn("dbo.SimpleCustomerAccounts", "UserName", c => c.String());
            AlterColumn("dbo.SimpleCustomerAccounts", "Email", c => c.String(maxLength: 255));
            CreateIndex("dbo.SimpleCustomerAccounts", "Email", unique: true, name: "IX_Unique_Email");
        }
        
        public override void Down()
        {
            DropIndex("dbo.SimpleCustomerAccounts", "IX_Unique_Email");
            AlterColumn("dbo.SimpleCustomerAccounts", "Email", c => c.String());
            AlterColumn("dbo.SimpleCustomerAccounts", "UserName", c => c.String(maxLength: 255));
            CreateIndex("dbo.SimpleCustomerAccounts", "UserName", unique: true, name: "IX_Unique_UserName");
        }
    }
}
