namespace Nanny.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class educations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Order = c.Int(nullable: false),
                        Disabled = c.Boolean(nullable: false),
                        Country_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AddressUnits", t => t.Country_Id)
                .Index(t => t.Country_Id);
            
            AddColumn("dbo.Metroes", "Order", c => c.Int(nullable: false));
            AddColumn("dbo.Metroes", "Disabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Metroes", "Country_Id", c => c.Int());
            CreateIndex("dbo.Metroes", "Country_Id");
            AddForeignKey("dbo.Metroes", "Country_Id", "dbo.AddressUnits", "Id");

            Sql("delete Metroes delete LangResources");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Metroes", "Country_Id", "dbo.AddressUnits");
            DropForeignKey("dbo.Educations", "Country_Id", "dbo.AddressUnits");
            DropIndex("dbo.Metroes", new[] { "Country_Id" });
            DropIndex("dbo.Educations", new[] { "Country_Id" });
            DropColumn("dbo.Metroes", "Country_Id");
            DropColumn("dbo.Metroes", "Disabled");
            DropColumn("dbo.Metroes", "Order");
            DropTable("dbo.Educations");
        }
    }
}
