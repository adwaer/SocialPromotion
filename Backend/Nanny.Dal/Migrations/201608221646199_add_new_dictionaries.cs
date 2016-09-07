namespace Nanny.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_new_dictionaries : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AboutMes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Order = c.Int(nullable: false),
                        Disabled = c.Boolean(nullable: false),
                        OwnerCountry_Iso = c.String(maxLength: 128),
                        WorkerProfile_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WorkerProfiles", t => t.WorkerProfile_Id)
                .ForeignKey("dbo.Countries", t => t.OwnerCountry_Iso)
                .Index(t => t.OwnerCountry_Iso)
                .Index(t => t.WorkerProfile_Id);
            
            CreateTable(
                "dbo.WorkerProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        YearExperience = c.Int(nullable: false),
                        MinCharge = c.Int(nullable: false),
                        WorkStartDate = c.DateTime(nullable: false),
                        ChildrenCount_Id = c.Int(),
                        Employment_Id = c.Int(),
                        Residence_Id = c.Int(),
                        Worship_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ChildrenCounts", t => t.ChildrenCount_Id)
                .ForeignKey("dbo.Employments", t => t.Employment_Id)
                .ForeignKey("dbo.Residences", t => t.Residence_Id)
                .ForeignKey("dbo.Worships", t => t.Worship_Id)
                .Index(t => t.ChildrenCount_Id)
                .Index(t => t.Employment_Id)
                .Index(t => t.Residence_Id)
                .Index(t => t.Worship_Id);
            
            CreateTable(
                "dbo.ChildrenCounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Order = c.Int(nullable: false),
                        Disabled = c.Boolean(nullable: false),
                        OwnerCountry_Iso = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.OwnerCountry_Iso)
                .Index(t => t.OwnerCountry_Iso);
            
            CreateTable(
                "dbo.Choices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Order = c.Int(nullable: false),
                        Disabled = c.Boolean(nullable: false),
                        OwnerCountry_Iso = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.OwnerCountry_Iso)
                .Index(t => t.OwnerCountry_Iso);
            
            CreateTable(
                "dbo.Employments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Order = c.Int(nullable: false),
                        Disabled = c.Boolean(nullable: false),
                        OwnerCountry_Iso = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.OwnerCountry_Iso)
                .Index(t => t.OwnerCountry_Iso);
            
            CreateTable(
                "dbo.Residences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Order = c.Int(nullable: false),
                        Disabled = c.Boolean(nullable: false),
                        OwnerCountry_Iso = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.OwnerCountry_Iso)
                .Index(t => t.OwnerCountry_Iso);
            
            CreateTable(
                "dbo.Worships",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Order = c.Int(nullable: false),
                        Disabled = c.Boolean(nullable: false),
                        OwnerCountry_Iso = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.OwnerCountry_Iso)
                .Index(t => t.OwnerCountry_Iso);
            
            CreateTable(
                "dbo.ChoiceWorkerProfiles",
                c => new
                    {
                        Choice_Id = c.Int(nullable: false),
                        WorkerProfile_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Choice_Id, t.WorkerProfile_Id })
                .ForeignKey("dbo.Choices", t => t.Choice_Id, cascadeDelete: true)
                .ForeignKey("dbo.WorkerProfiles", t => t.WorkerProfile_Id, cascadeDelete: true)
                .Index(t => t.Choice_Id)
                .Index(t => t.WorkerProfile_Id);
            
            CreateTable(
                "dbo.EducationWorkerProfiles",
                c => new
                    {
                        Education_Id = c.Int(nullable: false),
                        WorkerProfile_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Education_Id, t.WorkerProfile_Id })
                .ForeignKey("dbo.Educations", t => t.Education_Id, cascadeDelete: true)
                .ForeignKey("dbo.WorkerProfiles", t => t.WorkerProfile_Id, cascadeDelete: true)
                .Index(t => t.Education_Id)
                .Index(t => t.WorkerProfile_Id);
            
            CreateTable(
                "dbo.WorkerProfileLanguages",
                c => new
                    {
                        WorkerProfile_Id = c.Int(nullable: false),
                        Language_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.WorkerProfile_Id, t.Language_Id })
                .ForeignKey("dbo.WorkerProfiles", t => t.WorkerProfile_Id, cascadeDelete: true)
                .ForeignKey("dbo.Languages", t => t.Language_Id, cascadeDelete: true)
                .Index(t => t.WorkerProfile_Id)
                .Index(t => t.Language_Id);
            
            CreateTable(
                "dbo.WorkingConditionWorkerProfiles",
                c => new
                    {
                        WorkingCondition_Id = c.Int(nullable: false),
                        WorkerProfile_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.WorkingCondition_Id, t.WorkerProfile_Id })
                .ForeignKey("dbo.WorkingConditions", t => t.WorkingCondition_Id, cascadeDelete: true)
                .ForeignKey("dbo.WorkerProfiles", t => t.WorkerProfile_Id, cascadeDelete: true)
                .Index(t => t.WorkingCondition_Id)
                .Index(t => t.WorkerProfile_Id);
            
            CreateTable(
                "dbo.WorkingExperienceAgeWorkerProfiles",
                c => new
                    {
                        WorkingExperienceAge_Id = c.Int(nullable: false),
                        WorkerProfile_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.WorkingExperienceAge_Id, t.WorkerProfile_Id })
                .ForeignKey("dbo.WorkingExperienceAges", t => t.WorkingExperienceAge_Id, cascadeDelete: true)
                .ForeignKey("dbo.WorkerProfiles", t => t.WorkerProfile_Id, cascadeDelete: true)
                .Index(t => t.WorkingExperienceAge_Id)
                .Index(t => t.WorkerProfile_Id);
            
            CreateTable(
                "dbo.WorkingSkillWorkerProfiles",
                c => new
                    {
                        WorkingSkill_Id = c.Int(nullable: false),
                        WorkerProfile_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.WorkingSkill_Id, t.WorkerProfile_Id })
                .ForeignKey("dbo.WorkingSkills", t => t.WorkingSkill_Id, cascadeDelete: true)
                .ForeignKey("dbo.WorkerProfiles", t => t.WorkerProfile_Id, cascadeDelete: true)
                .Index(t => t.WorkingSkill_Id)
                .Index(t => t.WorkerProfile_Id);
            
            CreateTable(
                "dbo.WorkingTermWorkerProfiles",
                c => new
                    {
                        WorkingTerm_Id = c.Int(nullable: false),
                        WorkerProfile_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.WorkingTerm_Id, t.WorkerProfile_Id })
                .ForeignKey("dbo.WorkingTerms", t => t.WorkingTerm_Id, cascadeDelete: true)
                .ForeignKey("dbo.WorkerProfiles", t => t.WorkerProfile_Id, cascadeDelete: true)
                .Index(t => t.WorkingTerm_Id)
                .Index(t => t.WorkerProfile_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AboutMes", "OwnerCountry_Iso", "dbo.Countries");
            DropForeignKey("dbo.WorkerProfiles", "Worship_Id", "dbo.Worships");
            DropForeignKey("dbo.Worships", "OwnerCountry_Iso", "dbo.Countries");
            DropForeignKey("dbo.WorkingTermWorkerProfiles", "WorkerProfile_Id", "dbo.WorkerProfiles");
            DropForeignKey("dbo.WorkingTermWorkerProfiles", "WorkingTerm_Id", "dbo.WorkingTerms");
            DropForeignKey("dbo.WorkingSkillWorkerProfiles", "WorkerProfile_Id", "dbo.WorkerProfiles");
            DropForeignKey("dbo.WorkingSkillWorkerProfiles", "WorkingSkill_Id", "dbo.WorkingSkills");
            DropForeignKey("dbo.WorkingExperienceAgeWorkerProfiles", "WorkerProfile_Id", "dbo.WorkerProfiles");
            DropForeignKey("dbo.WorkingExperienceAgeWorkerProfiles", "WorkingExperienceAge_Id", "dbo.WorkingExperienceAges");
            DropForeignKey("dbo.WorkingConditionWorkerProfiles", "WorkerProfile_Id", "dbo.WorkerProfiles");
            DropForeignKey("dbo.WorkingConditionWorkerProfiles", "WorkingCondition_Id", "dbo.WorkingConditions");
            DropForeignKey("dbo.WorkerProfiles", "Residence_Id", "dbo.Residences");
            DropForeignKey("dbo.Residences", "OwnerCountry_Iso", "dbo.Countries");
            DropForeignKey("dbo.WorkerProfileLanguages", "Language_Id", "dbo.Languages");
            DropForeignKey("dbo.WorkerProfileLanguages", "WorkerProfile_Id", "dbo.WorkerProfiles");
            DropForeignKey("dbo.WorkerProfiles", "Employment_Id", "dbo.Employments");
            DropForeignKey("dbo.Employments", "OwnerCountry_Iso", "dbo.Countries");
            DropForeignKey("dbo.EducationWorkerProfiles", "WorkerProfile_Id", "dbo.WorkerProfiles");
            DropForeignKey("dbo.EducationWorkerProfiles", "Education_Id", "dbo.Educations");
            DropForeignKey("dbo.ChoiceWorkerProfiles", "WorkerProfile_Id", "dbo.WorkerProfiles");
            DropForeignKey("dbo.ChoiceWorkerProfiles", "Choice_Id", "dbo.Choices");
            DropForeignKey("dbo.Choices", "OwnerCountry_Iso", "dbo.Countries");
            DropForeignKey("dbo.WorkerProfiles", "ChildrenCount_Id", "dbo.ChildrenCounts");
            DropForeignKey("dbo.ChildrenCounts", "OwnerCountry_Iso", "dbo.Countries");
            DropForeignKey("dbo.AboutMes", "WorkerProfile_Id", "dbo.WorkerProfiles");
            DropIndex("dbo.WorkingTermWorkerProfiles", new[] { "WorkerProfile_Id" });
            DropIndex("dbo.WorkingTermWorkerProfiles", new[] { "WorkingTerm_Id" });
            DropIndex("dbo.WorkingSkillWorkerProfiles", new[] { "WorkerProfile_Id" });
            DropIndex("dbo.WorkingSkillWorkerProfiles", new[] { "WorkingSkill_Id" });
            DropIndex("dbo.WorkingExperienceAgeWorkerProfiles", new[] { "WorkerProfile_Id" });
            DropIndex("dbo.WorkingExperienceAgeWorkerProfiles", new[] { "WorkingExperienceAge_Id" });
            DropIndex("dbo.WorkingConditionWorkerProfiles", new[] { "WorkerProfile_Id" });
            DropIndex("dbo.WorkingConditionWorkerProfiles", new[] { "WorkingCondition_Id" });
            DropIndex("dbo.WorkerProfileLanguages", new[] { "Language_Id" });
            DropIndex("dbo.WorkerProfileLanguages", new[] { "WorkerProfile_Id" });
            DropIndex("dbo.EducationWorkerProfiles", new[] { "WorkerProfile_Id" });
            DropIndex("dbo.EducationWorkerProfiles", new[] { "Education_Id" });
            DropIndex("dbo.ChoiceWorkerProfiles", new[] { "WorkerProfile_Id" });
            DropIndex("dbo.ChoiceWorkerProfiles", new[] { "Choice_Id" });
            DropIndex("dbo.Worships", new[] { "OwnerCountry_Iso" });
            DropIndex("dbo.Residences", new[] { "OwnerCountry_Iso" });
            DropIndex("dbo.Employments", new[] { "OwnerCountry_Iso" });
            DropIndex("dbo.Choices", new[] { "OwnerCountry_Iso" });
            DropIndex("dbo.ChildrenCounts", new[] { "OwnerCountry_Iso" });
            DropIndex("dbo.WorkerProfiles", new[] { "Worship_Id" });
            DropIndex("dbo.WorkerProfiles", new[] { "Residence_Id" });
            DropIndex("dbo.WorkerProfiles", new[] { "Employment_Id" });
            DropIndex("dbo.WorkerProfiles", new[] { "ChildrenCount_Id" });
            DropIndex("dbo.AboutMes", new[] { "WorkerProfile_Id" });
            DropIndex("dbo.AboutMes", new[] { "OwnerCountry_Iso" });
            DropTable("dbo.WorkingTermWorkerProfiles");
            DropTable("dbo.WorkingSkillWorkerProfiles");
            DropTable("dbo.WorkingExperienceAgeWorkerProfiles");
            DropTable("dbo.WorkingConditionWorkerProfiles");
            DropTable("dbo.WorkerProfileLanguages");
            DropTable("dbo.EducationWorkerProfiles");
            DropTable("dbo.ChoiceWorkerProfiles");
            DropTable("dbo.Worships");
            DropTable("dbo.Residences");
            DropTable("dbo.Employments");
            DropTable("dbo.Choices");
            DropTable("dbo.ChildrenCounts");
            DropTable("dbo.WorkerProfiles");
            DropTable("dbo.AboutMes");
        }
    }
}
