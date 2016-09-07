namespace Nanny.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customer_profile : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AboutMes", "WorkerProfile_Id", "dbo.WorkerProfiles");
            DropForeignKey("dbo.WorkerProfiles", "ChildrenCount_Id", "dbo.ChildrenCounts");
            DropForeignKey("dbo.Choices", "OwnerCountry_Iso", "dbo.Countries");
            DropForeignKey("dbo.ChoiceWorkerProfiles", "Choice_Id", "dbo.Choices");
            DropForeignKey("dbo.ChoiceWorkerProfiles", "WorkerProfile_Id", "dbo.WorkerProfiles");
            DropForeignKey("dbo.EducationWorkerProfiles", "Education_Id", "dbo.Educations");
            DropForeignKey("dbo.EducationWorkerProfiles", "WorkerProfile_Id", "dbo.WorkerProfiles");
            DropForeignKey("dbo.WorkerProfiles", "Employment_Id", "dbo.Employments");
            DropForeignKey("dbo.WorkingConditionWorkerProfiles", "WorkingCondition_Id", "dbo.WorkingConditions");
            DropForeignKey("dbo.WorkingConditionWorkerProfiles", "WorkerProfile_Id", "dbo.WorkerProfiles");
            DropForeignKey("dbo.WorkingExperienceAgeWorkerProfiles", "WorkingExperienceAge_Id", "dbo.WorkingExperienceAges");
            DropForeignKey("dbo.WorkingExperienceAgeWorkerProfiles", "WorkerProfile_Id", "dbo.WorkerProfiles");
            DropForeignKey("dbo.WorkingSkillWorkerProfiles", "WorkingSkill_Id", "dbo.WorkingSkills");
            DropForeignKey("dbo.WorkingSkillWorkerProfiles", "WorkerProfile_Id", "dbo.WorkerProfiles");
            DropForeignKey("dbo.WorkingTermWorkerProfiles", "WorkingTerm_Id", "dbo.WorkingTerms");
            DropForeignKey("dbo.WorkingTermWorkerProfiles", "WorkerProfile_Id", "dbo.WorkerProfiles");
            DropIndex("dbo.AboutMes", new[] { "WorkerProfile_Id" });
            DropIndex("dbo.WorkerProfiles", new[] { "ChildrenCount_Id" });
            DropIndex("dbo.WorkerProfiles", new[] { "Employment_Id" });
            DropIndex("dbo.Choices", new[] { "OwnerCountry_Iso" });
            DropIndex("dbo.ChoiceWorkerProfiles", new[] { "Choice_Id" });
            DropIndex("dbo.ChoiceWorkerProfiles", new[] { "WorkerProfile_Id" });
            DropIndex("dbo.EducationWorkerProfiles", new[] { "Education_Id" });
            DropIndex("dbo.EducationWorkerProfiles", new[] { "WorkerProfile_Id" });
            DropIndex("dbo.WorkingConditionWorkerProfiles", new[] { "WorkingCondition_Id" });
            DropIndex("dbo.WorkingConditionWorkerProfiles", new[] { "WorkerProfile_Id" });
            DropIndex("dbo.WorkingExperienceAgeWorkerProfiles", new[] { "WorkingExperienceAge_Id" });
            DropIndex("dbo.WorkingExperienceAgeWorkerProfiles", new[] { "WorkerProfile_Id" });
            DropIndex("dbo.WorkingSkillWorkerProfiles", new[] { "WorkingSkill_Id" });
            DropIndex("dbo.WorkingSkillWorkerProfiles", new[] { "WorkerProfile_Id" });
            DropIndex("dbo.WorkingTermWorkerProfiles", new[] { "WorkingTerm_Id" });
            DropIndex("dbo.WorkingTermWorkerProfiles", new[] { "WorkerProfile_Id" });
            CreateTable(
                "dbo.NannyProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ChildrenCount_Id = c.Int(),
                        Employment_Id = c.Int(),
                        HaveChildren = c.Boolean(nullable: false),
                        YearExperience = c.Int(nullable: false),
                        Salary = c.Int(nullable: false),
                        WorkStartDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WorkerProfiles", t => t.Id)
                .ForeignKey("dbo.ChildrenCounts", t => t.ChildrenCount_Id)
                .ForeignKey("dbo.Employments", t => t.Employment_Id)
                .Index(t => t.Id)
                .Index(t => t.ChildrenCount_Id)
                .Index(t => t.Employment_Id);
            
            AddColumn("dbo.AboutMes", "NannyProfile_Id", c => c.Int());
            AddColumn("dbo.Educations", "NannyProfile_Id", c => c.Int());
            AddColumn("dbo.WorkingConditions", "NannyProfile_Id", c => c.Int());
            AddColumn("dbo.WorkingExperienceAges", "NannyProfile_Id", c => c.Int());
            AddColumn("dbo.WorkingSkills", "NannyProfile_Id", c => c.Int());
            AddColumn("dbo.WorkingTerms", "NannyProfile_Id", c => c.Int());
            AddColumn("dbo.Customers", "Profile_Id", c => c.Int());
            AddColumn("dbo.WorkerProfiles", "Citizenship", c => c.Boolean(nullable: false));
            AddColumn("dbo.WorkerProfiles", "RightToWork", c => c.Boolean(nullable: false));
            AddColumn("dbo.WorkerProfiles", "NotSmoke", c => c.Boolean(nullable: false));
            AddColumn("dbo.WorkerProfiles", "HaveDriverLicense", c => c.Boolean(nullable: false));
            AddColumn("dbo.WorkerProfiles", "HaveCar", c => c.Boolean(nullable: false));
            AddColumn("dbo.WorkerProfiles", "Education_Id", c => c.Int());
            AddColumn("dbo.WorkerProfiles", "WorkingCondition_Id", c => c.Int());
            AddColumn("dbo.WorkerProfiles", "WorkingExperienceAge_Id", c => c.Int());
            AddColumn("dbo.WorkerProfiles", "WorkingSkill_Id", c => c.Int());
            AddColumn("dbo.WorkerProfiles", "WorkingTerm_Id", c => c.Int());
            CreateIndex("dbo.AboutMes", "NannyProfile_Id");
            CreateIndex("dbo.WorkerProfiles", "Education_Id");
            CreateIndex("dbo.WorkerProfiles", "WorkingCondition_Id");
            CreateIndex("dbo.WorkerProfiles", "WorkingExperienceAge_Id");
            CreateIndex("dbo.WorkerProfiles", "WorkingSkill_Id");
            CreateIndex("dbo.WorkerProfiles", "WorkingTerm_Id");
            CreateIndex("dbo.Educations", "NannyProfile_Id");
            CreateIndex("dbo.WorkingConditions", "NannyProfile_Id");
            CreateIndex("dbo.WorkingExperienceAges", "NannyProfile_Id");
            CreateIndex("dbo.WorkingSkills", "NannyProfile_Id");
            CreateIndex("dbo.WorkingTerms", "NannyProfile_Id");
            CreateIndex("dbo.Customers", "Profile_Id");
            AddForeignKey("dbo.AboutMes", "NannyProfile_Id", "dbo.NannyProfiles", "Id");
            AddForeignKey("dbo.WorkerProfiles", "Education_Id", "dbo.Educations", "Id");
            AddForeignKey("dbo.Educations", "NannyProfile_Id", "dbo.NannyProfiles", "Id");
            AddForeignKey("dbo.WorkerProfiles", "WorkingCondition_Id", "dbo.WorkingConditions", "Id");
            AddForeignKey("dbo.WorkingConditions", "NannyProfile_Id", "dbo.NannyProfiles", "Id");
            AddForeignKey("dbo.WorkerProfiles", "WorkingExperienceAge_Id", "dbo.WorkingExperienceAges", "Id");
            AddForeignKey("dbo.WorkingExperienceAges", "NannyProfile_Id", "dbo.NannyProfiles", "Id");
            AddForeignKey("dbo.WorkerProfiles", "WorkingSkill_Id", "dbo.WorkingSkills", "Id");
            AddForeignKey("dbo.WorkingSkills", "NannyProfile_Id", "dbo.NannyProfiles", "Id");
            AddForeignKey("dbo.WorkerProfiles", "WorkingTerm_Id", "dbo.WorkingTerms", "Id");
            AddForeignKey("dbo.WorkingTerms", "NannyProfile_Id", "dbo.NannyProfiles", "Id");
            AddForeignKey("dbo.Customers", "Profile_Id", "dbo.WorkerProfiles", "Id");
            DropColumn("dbo.AboutMes", "WorkerProfile_Id");
            DropColumn("dbo.WorkerProfiles", "YearExperience");
            DropColumn("dbo.WorkerProfiles", "MinCharge");
            DropColumn("dbo.WorkerProfiles", "WorkStartDate");
            DropColumn("dbo.WorkerProfiles", "ChildrenCount_Id");
            DropColumn("dbo.WorkerProfiles", "Employment_Id");
            DropTable("dbo.Choices");
            DropTable("dbo.ChoiceWorkerProfiles");
            DropTable("dbo.EducationWorkerProfiles");
            DropTable("dbo.WorkingConditionWorkerProfiles");
            DropTable("dbo.WorkingExperienceAgeWorkerProfiles");
            DropTable("dbo.WorkingSkillWorkerProfiles");
            DropTable("dbo.WorkingTermWorkerProfiles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.WorkingTermWorkerProfiles",
                c => new
                    {
                        WorkingTerm_Id = c.Int(nullable: false),
                        WorkerProfile_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.WorkingTerm_Id, t.WorkerProfile_Id });
            
            CreateTable(
                "dbo.WorkingSkillWorkerProfiles",
                c => new
                    {
                        WorkingSkill_Id = c.Int(nullable: false),
                        WorkerProfile_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.WorkingSkill_Id, t.WorkerProfile_Id });
            
            CreateTable(
                "dbo.WorkingExperienceAgeWorkerProfiles",
                c => new
                    {
                        WorkingExperienceAge_Id = c.Int(nullable: false),
                        WorkerProfile_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.WorkingExperienceAge_Id, t.WorkerProfile_Id });
            
            CreateTable(
                "dbo.WorkingConditionWorkerProfiles",
                c => new
                    {
                        WorkingCondition_Id = c.Int(nullable: false),
                        WorkerProfile_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.WorkingCondition_Id, t.WorkerProfile_Id });
            
            CreateTable(
                "dbo.EducationWorkerProfiles",
                c => new
                    {
                        Education_Id = c.Int(nullable: false),
                        WorkerProfile_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Education_Id, t.WorkerProfile_Id });
            
            CreateTable(
                "dbo.ChoiceWorkerProfiles",
                c => new
                    {
                        Choice_Id = c.Int(nullable: false),
                        WorkerProfile_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Choice_Id, t.WorkerProfile_Id });
            
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
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.WorkerProfiles", "Employment_Id", c => c.Int());
            AddColumn("dbo.WorkerProfiles", "ChildrenCount_Id", c => c.Int());
            AddColumn("dbo.WorkerProfiles", "WorkStartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.WorkerProfiles", "MinCharge", c => c.Int(nullable: false));
            AddColumn("dbo.WorkerProfiles", "YearExperience", c => c.Int(nullable: false));
            AddColumn("dbo.AboutMes", "WorkerProfile_Id", c => c.Int());
            DropForeignKey("dbo.NannyProfiles", "Employment_Id", "dbo.Employments");
            DropForeignKey("dbo.NannyProfiles", "ChildrenCount_Id", "dbo.ChildrenCounts");
            DropForeignKey("dbo.NannyProfiles", "Id", "dbo.WorkerProfiles");
            DropForeignKey("dbo.Customers", "Profile_Id", "dbo.WorkerProfiles");
            DropForeignKey("dbo.WorkingTerms", "NannyProfile_Id", "dbo.NannyProfiles");
            DropForeignKey("dbo.WorkerProfiles", "WorkingTerm_Id", "dbo.WorkingTerms");
            DropForeignKey("dbo.WorkingSkills", "NannyProfile_Id", "dbo.NannyProfiles");
            DropForeignKey("dbo.WorkerProfiles", "WorkingSkill_Id", "dbo.WorkingSkills");
            DropForeignKey("dbo.WorkingExperienceAges", "NannyProfile_Id", "dbo.NannyProfiles");
            DropForeignKey("dbo.WorkerProfiles", "WorkingExperienceAge_Id", "dbo.WorkingExperienceAges");
            DropForeignKey("dbo.WorkingConditions", "NannyProfile_Id", "dbo.NannyProfiles");
            DropForeignKey("dbo.WorkerProfiles", "WorkingCondition_Id", "dbo.WorkingConditions");
            DropForeignKey("dbo.Educations", "NannyProfile_Id", "dbo.NannyProfiles");
            DropForeignKey("dbo.WorkerProfiles", "Education_Id", "dbo.Educations");
            DropForeignKey("dbo.AboutMes", "NannyProfile_Id", "dbo.NannyProfiles");
            DropIndex("dbo.NannyProfiles", new[] { "Employment_Id" });
            DropIndex("dbo.NannyProfiles", new[] { "ChildrenCount_Id" });
            DropIndex("dbo.NannyProfiles", new[] { "Id" });
            DropIndex("dbo.Customers", new[] { "Profile_Id" });
            DropIndex("dbo.WorkingTerms", new[] { "NannyProfile_Id" });
            DropIndex("dbo.WorkingSkills", new[] { "NannyProfile_Id" });
            DropIndex("dbo.WorkingExperienceAges", new[] { "NannyProfile_Id" });
            DropIndex("dbo.WorkingConditions", new[] { "NannyProfile_Id" });
            DropIndex("dbo.Educations", new[] { "NannyProfile_Id" });
            DropIndex("dbo.WorkerProfiles", new[] { "WorkingTerm_Id" });
            DropIndex("dbo.WorkerProfiles", new[] { "WorkingSkill_Id" });
            DropIndex("dbo.WorkerProfiles", new[] { "WorkingExperienceAge_Id" });
            DropIndex("dbo.WorkerProfiles", new[] { "WorkingCondition_Id" });
            DropIndex("dbo.WorkerProfiles", new[] { "Education_Id" });
            DropIndex("dbo.AboutMes", new[] { "NannyProfile_Id" });
            DropColumn("dbo.WorkerProfiles", "WorkingTerm_Id");
            DropColumn("dbo.WorkerProfiles", "WorkingSkill_Id");
            DropColumn("dbo.WorkerProfiles", "WorkingExperienceAge_Id");
            DropColumn("dbo.WorkerProfiles", "WorkingCondition_Id");
            DropColumn("dbo.WorkerProfiles", "Education_Id");
            DropColumn("dbo.WorkerProfiles", "HaveCar");
            DropColumn("dbo.WorkerProfiles", "HaveDriverLicense");
            DropColumn("dbo.WorkerProfiles", "NotSmoke");
            DropColumn("dbo.WorkerProfiles", "RightToWork");
            DropColumn("dbo.WorkerProfiles", "Citizenship");
            DropColumn("dbo.Customers", "Profile_Id");
            DropColumn("dbo.WorkingTerms", "NannyProfile_Id");
            DropColumn("dbo.WorkingSkills", "NannyProfile_Id");
            DropColumn("dbo.WorkingExperienceAges", "NannyProfile_Id");
            DropColumn("dbo.WorkingConditions", "NannyProfile_Id");
            DropColumn("dbo.Educations", "NannyProfile_Id");
            DropColumn("dbo.AboutMes", "NannyProfile_Id");
            DropTable("dbo.NannyProfiles");
            CreateIndex("dbo.WorkingTermWorkerProfiles", "WorkerProfile_Id");
            CreateIndex("dbo.WorkingTermWorkerProfiles", "WorkingTerm_Id");
            CreateIndex("dbo.WorkingSkillWorkerProfiles", "WorkerProfile_Id");
            CreateIndex("dbo.WorkingSkillWorkerProfiles", "WorkingSkill_Id");
            CreateIndex("dbo.WorkingExperienceAgeWorkerProfiles", "WorkerProfile_Id");
            CreateIndex("dbo.WorkingExperienceAgeWorkerProfiles", "WorkingExperienceAge_Id");
            CreateIndex("dbo.WorkingConditionWorkerProfiles", "WorkerProfile_Id");
            CreateIndex("dbo.WorkingConditionWorkerProfiles", "WorkingCondition_Id");
            CreateIndex("dbo.EducationWorkerProfiles", "WorkerProfile_Id");
            CreateIndex("dbo.EducationWorkerProfiles", "Education_Id");
            CreateIndex("dbo.ChoiceWorkerProfiles", "WorkerProfile_Id");
            CreateIndex("dbo.ChoiceWorkerProfiles", "Choice_Id");
            CreateIndex("dbo.Choices", "OwnerCountry_Iso");
            CreateIndex("dbo.WorkerProfiles", "Employment_Id");
            CreateIndex("dbo.WorkerProfiles", "ChildrenCount_Id");
            CreateIndex("dbo.AboutMes", "WorkerProfile_Id");
            AddForeignKey("dbo.WorkingTermWorkerProfiles", "WorkerProfile_Id", "dbo.WorkerProfiles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.WorkingTermWorkerProfiles", "WorkingTerm_Id", "dbo.WorkingTerms", "Id", cascadeDelete: true);
            AddForeignKey("dbo.WorkingSkillWorkerProfiles", "WorkerProfile_Id", "dbo.WorkerProfiles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.WorkingSkillWorkerProfiles", "WorkingSkill_Id", "dbo.WorkingSkills", "Id", cascadeDelete: true);
            AddForeignKey("dbo.WorkingExperienceAgeWorkerProfiles", "WorkerProfile_Id", "dbo.WorkerProfiles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.WorkingExperienceAgeWorkerProfiles", "WorkingExperienceAge_Id", "dbo.WorkingExperienceAges", "Id", cascadeDelete: true);
            AddForeignKey("dbo.WorkingConditionWorkerProfiles", "WorkerProfile_Id", "dbo.WorkerProfiles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.WorkingConditionWorkerProfiles", "WorkingCondition_Id", "dbo.WorkingConditions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.WorkerProfiles", "Employment_Id", "dbo.Employments", "Id");
            AddForeignKey("dbo.EducationWorkerProfiles", "WorkerProfile_Id", "dbo.WorkerProfiles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EducationWorkerProfiles", "Education_Id", "dbo.Educations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ChoiceWorkerProfiles", "WorkerProfile_Id", "dbo.WorkerProfiles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ChoiceWorkerProfiles", "Choice_Id", "dbo.Choices", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Choices", "OwnerCountry_Iso", "dbo.Countries", "Iso");
            AddForeignKey("dbo.WorkerProfiles", "ChildrenCount_Id", "dbo.ChildrenCounts", "Id");
            AddForeignKey("dbo.AboutMes", "WorkerProfile_Id", "dbo.WorkerProfiles", "Id");
        }
    }
}
