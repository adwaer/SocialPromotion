namespace Nanny.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class culture : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LangCultures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Key = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LangResources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Culture_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LangCultures", t => t.Culture_Id, cascadeDelete: true)
                .Index(t => t.Culture_Id);
            
            CreateTable(
                "dbo.LangResourceValues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Key = c.String(),
                        Value = c.String(),
                        LangResource_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LangResources", t => t.LangResource_Id, cascadeDelete: true)
                .Index(t => t.LangResource_Id);
            
            AddColumn("dbo.Customers", "Culture_Id", c => c.Int());
            Sql("insert into dbo.LangCultures values('ru-ru', 'Russian')");
            Sql("update dbo.Customers set Culture_Id = @@identity");
            AlterColumn("dbo.Customers", "Culture_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "Culture_Id");
            AddForeignKey("dbo.Customers", "Culture_Id", "dbo.LangCultures", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LangResourceValues", "LangResource_Id", "dbo.LangResources");
            DropForeignKey("dbo.LangResources", "Culture_Id", "dbo.LangCultures");
            DropForeignKey("dbo.Customers", "Culture_Id", "dbo.LangCultures");
            DropIndex("dbo.LangResourceValues", new[] { "LangResource_Id" });
            DropIndex("dbo.LangResources", new[] { "Culture_Id" });
            DropIndex("dbo.Customers", new[] { "Culture_Id" });
            DropColumn("dbo.Customers", "Culture_Id");
            DropTable("dbo.LangResourceValues");
            DropTable("dbo.LangResources");
            DropTable("dbo.LangCultures");
        }
    }
}
