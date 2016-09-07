namespace Nanny.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class workers_serach : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerSearches",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Count = c.Int(nullable: false),
                        Page = c.Int(nullable: false),
                        AgeFrom = c.Int(),
                        AgeTo = c.Int(),
                        DistanceLat = c.Int(),
                        DistanceLng = c.Int(),
                        DistanceUntil = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.AddressDetails", "Lat", c => c.Double(nullable: false));
            AlterColumn("dbo.AddressDetails", "Lng", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AddressDetails", "Lng", c => c.String());
            AlterColumn("dbo.AddressDetails", "Lat", c => c.String());
            DropTable("dbo.CustomerSearches");
        }
    }
}
