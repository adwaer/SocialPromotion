namespace Nanny.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class address_required : DbMigration
    {
        public override void Up()
        {
            Sql(@"delete
from Addresses
where Details_Id is null");

            DropForeignKey("dbo.Addresses", "Details_Id", "dbo.AddressDetails");
            DropForeignKey("dbo.Customers", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.Addresses", new[] { "Details_Id" });
            DropIndex("dbo.Customers", new[] { "Address_Id" });
            AlterColumn("dbo.Addresses", "Details_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "Address_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Addresses", "Details_Id");
            CreateIndex("dbo.Customers", "Address_Id");
            AddForeignKey("dbo.Addresses", "Details_Id", "dbo.AddressDetails", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Customers", "Address_Id", "dbo.Addresses", "Id", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Customers", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.Addresses", "Details_Id", "dbo.AddressDetails");
            DropIndex("dbo.Customers", new[] { "Address_Id" });
            DropIndex("dbo.Addresses", new[] { "Details_Id" });
            AlterColumn("dbo.Customers", "Address_Id", c => c.Int());
            AlterColumn("dbo.Addresses", "Details_Id", c => c.Int());
            CreateIndex("dbo.Customers", "Address_Id");
            CreateIndex("dbo.Addresses", "Details_Id");
            AddForeignKey("dbo.Customers", "Address_Id", "dbo.Addresses", "Id");
            AddForeignKey("dbo.Addresses", "Details_Id", "dbo.AddressDetails", "Id");
        }
    }
}
