namespace Nanny.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class search_worker_type : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerSearches", "WorkerType", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerSearches", "WorkerType");
        }
    }
}
