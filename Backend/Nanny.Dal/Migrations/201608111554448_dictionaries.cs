namespace Nanny.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dictionaries : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HttpDomainLangCultures", "HttpDomain_Id", "dbo.HttpDomains");
            DropForeignKey("dbo.HttpDomainLangCultures", "LangCulture_Id", "dbo.LangCultures");
            DropForeignKey("dbo.Customers", "Culture_Id", "dbo.LangCultures");
            DropIndex("dbo.Customers", new[] { "Culture_Id" });
            DropIndex("dbo.HttpDomainLangCultures", new[] { "HttpDomain_Id" });
            DropIndex("dbo.HttpDomainLangCultures", new[] { "LangCulture_Id" });
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Order = c.Int(nullable: false),
                        Disabled = c.Boolean(nullable: false),
                        OwnerCountry_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.OwnerCountry_Id)
                .Index(t => t.OwnerCountry_Id);
            
            CreateTable(
                "dbo.WorkingConditions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Order = c.Int(nullable: false),
                        Disabled = c.Boolean(nullable: false),
                        OwnerCountry_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.OwnerCountry_Id)
                .Index(t => t.OwnerCountry_Id);
            
            CreateTable(
                "dbo.WorkingExperienceAges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Order = c.Int(nullable: false),
                        Disabled = c.Boolean(nullable: false),
                        OwnerCountry_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.OwnerCountry_Id)
                .Index(t => t.OwnerCountry_Id);
            
            CreateTable(
                "dbo.WorkingSkills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Order = c.Int(nullable: false),
                        Disabled = c.Boolean(nullable: false),
                        OwnerCountry_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.OwnerCountry_Id)
                .Index(t => t.OwnerCountry_Id);
            
            CreateTable(
                "dbo.WorkingTerms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Order = c.Int(nullable: false),
                        Disabled = c.Boolean(nullable: false),
                        OwnerCountry_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.OwnerCountry_Id)
                .Index(t => t.OwnerCountry_Id);
            
            CreateTable(
                "dbo.LangCultureCountries",
                c => new
                    {
                        LangCulture_Id = c.Int(nullable: false),
                        Country_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LangCulture_Id, t.Country_Id })
                .ForeignKey("dbo.LangCultures", t => t.LangCulture_Id, cascadeDelete: true)
                .ForeignKey("dbo.Countries", t => t.Country_Id, cascadeDelete: true)
                .Index(t => t.LangCulture_Id)
                .Index(t => t.Country_Id);
            
            AddColumn("dbo.LangCultures", "Language_Id", c => c.Int());
            AlterColumn("dbo.Customers", "Culture_Id", c => c.Int());
            CreateIndex("dbo.LangCultures", "Language_Id");
            CreateIndex("dbo.Customers", "Culture_Id");
            AddForeignKey("dbo.LangCultures", "Language_Id", "dbo.Languages", "Id");
            AddForeignKey("dbo.Customers", "Culture_Id", "dbo.LangCultures", "Id");
            DropColumn("dbo.LangCultures", "Name");
            DropTable("dbo.HttpDomainLangCultures");

            Sql(@"update Customers set Culture_Id = null
delete LangCultures
update Addresses set Country_Id = null
delete HttpDomains
delete Metroes
delete Educations
delete Countries");
        }

        public override void Down()
        {
            CreateTable(
                "dbo.HttpDomainLangCultures",
                c => new
                    {
                        HttpDomain_Id = c.Int(nullable: false),
                        LangCulture_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.HttpDomain_Id, t.LangCulture_Id });
            
            AddColumn("dbo.LangCultures", "Name", c => c.String());
            DropForeignKey("dbo.Customers", "Culture_Id", "dbo.LangCultures");
            DropForeignKey("dbo.WorkingTerms", "OwnerCountry_Id", "dbo.Countries");
            DropForeignKey("dbo.WorkingSkills", "OwnerCountry_Id", "dbo.Countries");
            DropForeignKey("dbo.WorkingExperienceAges", "OwnerCountry_Id", "dbo.Countries");
            DropForeignKey("dbo.WorkingConditions", "OwnerCountry_Id", "dbo.Countries");
            DropForeignKey("dbo.LangCultures", "Language_Id", "dbo.Languages");
            DropForeignKey("dbo.Languages", "OwnerCountry_Id", "dbo.Countries");
            DropForeignKey("dbo.LangCultureCountries", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.LangCultureCountries", "LangCulture_Id", "dbo.LangCultures");
            DropIndex("dbo.LangCultureCountries", new[] { "Country_Id" });
            DropIndex("dbo.LangCultureCountries", new[] { "LangCulture_Id" });
            DropIndex("dbo.WorkingTerms", new[] { "OwnerCountry_Id" });
            DropIndex("dbo.WorkingSkills", new[] { "OwnerCountry_Id" });
            DropIndex("dbo.WorkingExperienceAges", new[] { "OwnerCountry_Id" });
            DropIndex("dbo.WorkingConditions", new[] { "OwnerCountry_Id" });
            DropIndex("dbo.Customers", new[] { "Culture_Id" });
            DropIndex("dbo.Languages", new[] { "OwnerCountry_Id" });
            DropIndex("dbo.LangCultures", new[] { "Language_Id" });
            AlterColumn("dbo.Customers", "Culture_Id", c => c.Int(nullable: false));
            DropColumn("dbo.LangCultures", "Language_Id");
            DropTable("dbo.LangCultureCountries");
            DropTable("dbo.WorkingTerms");
            DropTable("dbo.WorkingSkills");
            DropTable("dbo.WorkingExperienceAges");
            DropTable("dbo.WorkingConditions");
            DropTable("dbo.Languages");
            CreateIndex("dbo.HttpDomainLangCultures", "LangCulture_Id");
            CreateIndex("dbo.HttpDomainLangCultures", "HttpDomain_Id");
            CreateIndex("dbo.Customers", "Culture_Id");
            AddForeignKey("dbo.Customers", "Culture_Id", "dbo.LangCultures", "Id", cascadeDelete: true);
            AddForeignKey("dbo.HttpDomainLangCultures", "LangCulture_Id", "dbo.LangCultures", "Id", cascadeDelete: true);
            AddForeignKey("dbo.HttpDomainLangCultures", "HttpDomain_Id", "dbo.HttpDomains", "Id", cascadeDelete: true);
        }
    }
}
