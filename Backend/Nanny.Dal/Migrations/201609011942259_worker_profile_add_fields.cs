namespace Nanny.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class worker_profile_add_fields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkerProfiles", "CreateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.WorkerProfiles", "UpdateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.WorkerProfiles", "Disabled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorkerProfiles", "Disabled");
            DropColumn("dbo.WorkerProfiles", "UpdateTime");
            DropColumn("dbo.WorkerProfiles", "CreateTime");
        }
    }
}
