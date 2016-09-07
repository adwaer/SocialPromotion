namespace Nanny.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BirthDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "BirthDate", c => c.DateTime(nullable: false));
            Sql("update dbo.Customers set BirthDate = case BirthYear when 0 then DATEFROMPARTS(1980, 1, 1) else DATEFROMPARTS(BirthYear, 1, 1) end");
            DropColumn("dbo.Customers", "BirthYear");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "BirthYear", c => c.Int(nullable: false));
            DropColumn("dbo.Customers", "BirthDate");
        }
    }
}
