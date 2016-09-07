namespace Nanny.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class search_fix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CustomerSearches", "DistanceLat", c => c.Double());
            AlterColumn("dbo.CustomerSearches", "DistanceLng", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CustomerSearches", "DistanceLng", c => c.Int());
            AlterColumn("dbo.CustomerSearches", "DistanceLat", c => c.Int());
        }
    }
}
