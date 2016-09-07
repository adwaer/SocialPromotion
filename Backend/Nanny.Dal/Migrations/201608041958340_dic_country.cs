namespace Nanny.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dic_country : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AddressAddressUnits", newName: "AddressUnitAddresses");
            DropForeignKey("dbo.Educations", "Country_Id", "dbo.AddressUnits");
            DropForeignKey("dbo.Metroes", "Country_Id", "dbo.AddressUnits");
            DropIndex("dbo.Educations", new[] { "Country_Id" });
            DropIndex("dbo.Metroes", new[] { "Country_Id" });
            DropPrimaryKey("dbo.AddressUnitAddresses");
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Iso = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Addresses", "Country_Id", c => c.Int());
            AddColumn("dbo.HttpDomains", "Country_Id", c => c.Int());
            AddColumn("dbo.Educations", "OwnerCountry_Id", c => c.Int());
            AddColumn("dbo.Metroes", "OwnerCountry_Id", c => c.Int());
            AddPrimaryKey("dbo.AddressUnitAddresses", new[] { "AddressUnit_Id", "Address_Id" });
            CreateIndex("dbo.Addresses", "Country_Id");
            CreateIndex("dbo.HttpDomains", "Country_Id");
            CreateIndex("dbo.Educations", "OwnerCountry_Id");
            CreateIndex("dbo.Metroes", "OwnerCountry_Id");
            AddForeignKey("dbo.Addresses", "Country_Id", "dbo.Countries", "Id");
            AddForeignKey("dbo.HttpDomains", "Country_Id", "dbo.Countries", "Id");
            AddForeignKey("dbo.Educations", "OwnerCountry_Id", "dbo.Countries", "Id");
            AddForeignKey("dbo.Metroes", "OwnerCountry_Id", "dbo.Countries", "Id");
            DropColumn("dbo.Educations", "Country_Id");
            DropColumn("dbo.Metroes", "Country_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Metroes", "Country_Id", c => c.Int());
            AddColumn("dbo.Educations", "Country_Id", c => c.Int());
            DropForeignKey("dbo.Metroes", "OwnerCountry_Id", "dbo.Countries");
            DropForeignKey("dbo.Educations", "OwnerCountry_Id", "dbo.Countries");
            DropForeignKey("dbo.HttpDomains", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.Addresses", "Country_Id", "dbo.Countries");
            DropIndex("dbo.Metroes", new[] { "OwnerCountry_Id" });
            DropIndex("dbo.Educations", new[] { "OwnerCountry_Id" });
            DropIndex("dbo.HttpDomains", new[] { "Country_Id" });
            DropIndex("dbo.Addresses", new[] { "Country_Id" });
            DropPrimaryKey("dbo.AddressUnitAddresses");
            DropColumn("dbo.Metroes", "OwnerCountry_Id");
            DropColumn("dbo.Educations", "OwnerCountry_Id");
            DropColumn("dbo.HttpDomains", "Country_Id");
            DropColumn("dbo.Addresses", "Country_Id");
            DropTable("dbo.Countries");
            AddPrimaryKey("dbo.AddressUnitAddresses", new[] { "Address_Id", "AddressUnit_Id" });
            CreateIndex("dbo.Metroes", "Country_Id");
            CreateIndex("dbo.Educations", "Country_Id");
            AddForeignKey("dbo.Metroes", "Country_Id", "dbo.AddressUnits", "Id");
            AddForeignKey("dbo.Educations", "Country_Id", "dbo.AddressUnits", "Id");
            RenameTable(name: "dbo.AddressUnitAddresses", newName: "AddressAddressUnits");
        }
    }
}
