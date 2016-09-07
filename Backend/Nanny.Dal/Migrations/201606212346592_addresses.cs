namespace Nanny.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addresses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddressUnits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ShortName = c.String(),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApiResult = c.String(),
                        Details_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AddressDetails", t => t.Details_Id)
                .Index(t => t.Details_Id);
            
            CreateTable(
                "dbo.AddressDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Components = c.String(),
                        Lat = c.String(),
                        Lng = c.String(),
                        Url = c.String(),
                        DetailsId = c.String(),
                        PlaceId = c.String(),
                        Reference = c.String(),
                        Scope = c.String(),
                        Types = c.String(),
                        UtcOffset = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AddressAddressUnits",
                c => new
                    {
                        Address_Id = c.Int(nullable: false),
                        AddressUnit_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Address_Id, t.AddressUnit_Id })
                .ForeignKey("dbo.Addresses", t => t.Address_Id, cascadeDelete: true)
                .ForeignKey("dbo.AddressUnits", t => t.AddressUnit_Id, cascadeDelete: true)
                .Index(t => t.Address_Id)
                .Index(t => t.AddressUnit_Id);
            
            AddColumn("dbo.Customers", "SearchType", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "BirthYear", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "Address_Id", c => c.Int());
            CreateIndex("dbo.Customers", "Address_Id");
            AddForeignKey("dbo.Customers", "Address_Id", "dbo.Addresses", "Id");
            DropColumn("dbo.SimpleCustomerAccounts", "SearchType");
            DropColumn("dbo.SimpleCustomerAccounts", "BirthYear");
            DropColumn("dbo.SimpleCustomerAccounts", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SimpleCustomerAccounts", "Address", c => c.String());
            AddColumn("dbo.SimpleCustomerAccounts", "BirthYear", c => c.Int(nullable: false));
            AddColumn("dbo.SimpleCustomerAccounts", "SearchType", c => c.Int(nullable: false));
            DropForeignKey("dbo.Customers", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.Addresses", "Details_Id", "dbo.AddressDetails");
            DropForeignKey("dbo.AddressAddressUnits", "AddressUnit_Id", "dbo.AddressUnits");
            DropForeignKey("dbo.AddressAddressUnits", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.AddressAddressUnits", new[] { "AddressUnit_Id" });
            DropIndex("dbo.AddressAddressUnits", new[] { "Address_Id" });
            DropIndex("dbo.Customers", new[] { "Address_Id" });
            DropIndex("dbo.Addresses", new[] { "Details_Id" });
            DropColumn("dbo.Customers", "Address_Id");
            DropColumn("dbo.Customers", "BirthYear");
            DropColumn("dbo.Customers", "SearchType");
            DropTable("dbo.AddressAddressUnits");
            DropTable("dbo.AddressDetails");
            DropTable("dbo.Addresses");
            DropTable("dbo.AddressUnits");
        }
    }
}
