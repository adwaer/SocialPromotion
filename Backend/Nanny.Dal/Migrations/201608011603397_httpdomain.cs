namespace Nanny.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class httpdomain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HttpDomains",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HttpDomainLangCultures",
                c => new
                    {
                        HttpDomain_Id = c.Int(nullable: false),
                        LangCulture_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.HttpDomain_Id, t.LangCulture_Id })
                .ForeignKey("dbo.HttpDomains", t => t.HttpDomain_Id, cascadeDelete: true)
                .ForeignKey("dbo.LangCultures", t => t.LangCulture_Id, cascadeDelete: true)
                .Index(t => t.HttpDomain_Id)
                .Index(t => t.LangCulture_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HttpDomainLangCultures", "LangCulture_Id", "dbo.LangCultures");
            DropForeignKey("dbo.HttpDomainLangCultures", "HttpDomain_Id", "dbo.HttpDomains");
            DropIndex("dbo.HttpDomainLangCultures", new[] { "LangCulture_Id" });
            DropIndex("dbo.HttpDomainLangCultures", new[] { "HttpDomain_Id" });
            DropTable("dbo.HttpDomainLangCultures");
            DropTable("dbo.HttpDomains");
        }
    }
}
