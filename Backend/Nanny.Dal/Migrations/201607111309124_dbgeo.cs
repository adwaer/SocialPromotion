namespace Nanny.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Spatial;
    
    public partial class dbgeo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AddressDetails", "Location", c => c.Geography());
            Sql("update dbo.AddressDetails set Location = geography::Point(Lat, Lng, 4326)");
        }
        
        public override void Down()
        {
            DropColumn("dbo.AddressDetails", "Location");
        }
    }
}
