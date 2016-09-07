namespace Nanny.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userrefactor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmailPublishes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Subject = c.String(),
                        Body = c.String(),
                        BccList = c.String(),
                        CcList = c.String(),
                        Socceed = c.Boolean(nullable: false),
                        Error = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.SimpleCustomerAccounts", "SearchType", c => c.Int(nullable: false));
            AddColumn("dbo.SimpleCustomerAccounts", "BirthYear", c => c.Int(nullable: false));
            AddColumn("dbo.SimpleCustomerAccounts", "Address", c => c.String());
            DropTable("dbo.Bets");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Bets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Game = c.String(),
                        Tournament = c.String(),
                        Forecast = c.String(),
                        Content = c.String(),
                        Coefficient = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GameStartDate = c.DateTime(nullable: false),
                        ShowDate = c.DateTime(nullable: false),
                        MakeDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.SimpleCustomerAccounts", "Address");
            DropColumn("dbo.SimpleCustomerAccounts", "BirthYear");
            DropColumn("dbo.SimpleCustomerAccounts", "SearchType");
            DropTable("dbo.EmailPublishes");
        }
    }
}
