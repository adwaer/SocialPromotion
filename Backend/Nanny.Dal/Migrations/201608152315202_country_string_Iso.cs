namespace Nanny.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class country_string_Iso : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Languages", "OwnerCountryId");
            DropColumn("dbo.Educations", "OwnerCountryId");
            DropColumn("dbo.HttpDomains", "CountryId");
            DropColumn("dbo.Metroes", "OwnerCountryId");
            DropColumn("dbo.WorkingConditions", "OwnerCountryId");
            DropColumn("dbo.WorkingExperienceAges", "OwnerCountryId");
            DropColumn("dbo.WorkingSkills", "OwnerCountryId");
            DropColumn("dbo.WorkingTerms", "OwnerCountryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WorkingTerms", "OwnerCountryId", c => c.String());
            AddColumn("dbo.WorkingSkills", "OwnerCountryId", c => c.String());
            AddColumn("dbo.WorkingExperienceAges", "OwnerCountryId", c => c.String());
            AddColumn("dbo.WorkingConditions", "OwnerCountryId", c => c.String());
            AddColumn("dbo.Metroes", "OwnerCountryId", c => c.String());
            AddColumn("dbo.HttpDomains", "CountryId", c => c.String());
            AddColumn("dbo.Educations", "OwnerCountryId", c => c.String());
            AddColumn("dbo.Languages", "OwnerCountryId", c => c.String());
        }
    }
}
