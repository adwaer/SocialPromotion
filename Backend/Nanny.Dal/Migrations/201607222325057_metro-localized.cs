namespace Nanny.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class metrolocalized : DbMigration
    {
        public override void Up()
        {
            Sql("delete Metroes");
        }
        
        public override void Down()
        {
        }
    }
}
