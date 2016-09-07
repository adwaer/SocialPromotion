namespace Nanny.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_profiles : DbMigration
    {
        public override void Up()
        {
            Sql("delete Residences delete WorkerProfiles");
            DropForeignKey("dbo.AboutMes", "NannyProfile_Id", "dbo.NannyProfiles");
            DropForeignKey("dbo.WorkerProfiles", "Residence_Id", "dbo.Residences");
            DropForeignKey("dbo.WorkerProfiles", "Education_Id", "dbo.Educations");
            DropForeignKey("dbo.Educations", "NannyProfile_Id", "dbo.NannyProfiles");
            DropForeignKey("dbo.WorkerProfiles", "WorkingCondition_Id", "dbo.WorkingConditions");
            DropForeignKey("dbo.WorkingConditions", "NannyProfile_Id", "dbo.NannyProfiles");
            DropForeignKey("dbo.WorkerProfiles", "WorkingExperienceAge_Id", "dbo.WorkingExperienceAges");
            DropForeignKey("dbo.WorkingExperienceAges", "NannyProfile_Id", "dbo.NannyProfiles");
            DropForeignKey("dbo.WorkerProfiles", "WorkingSkill_Id", "dbo.WorkingSkills");
            DropForeignKey("dbo.WorkingSkills", "NannyProfile_Id", "dbo.NannyProfiles");
            DropForeignKey("dbo.WorkerProfiles", "WorkingTerm_Id", "dbo.WorkingTerms");
            DropForeignKey("dbo.WorkingTerms", "NannyProfile_Id", "dbo.NannyProfiles");
            DropIndex("dbo.AboutMes", new[] { "NannyProfile_Id" });
            DropIndex("dbo.WorkerProfiles", new[] { "Residence_Id" });
            DropIndex("dbo.WorkerProfiles", new[] { "Education_Id" });
            DropIndex("dbo.WorkerProfiles", new[] { "WorkingCondition_Id" });
            DropIndex("dbo.WorkerProfiles", new[] { "WorkingExperienceAge_Id" });
            DropIndex("dbo.WorkerProfiles", new[] { "WorkingSkill_Id" });
            DropIndex("dbo.WorkerProfiles", new[] { "WorkingTerm_Id" });
            DropIndex("dbo.Educations", new[] { "NannyProfile_Id" });
            DropIndex("dbo.WorkingConditions", new[] { "NannyProfile_Id" });
            DropIndex("dbo.WorkingExperienceAges", new[] { "NannyProfile_Id" });
            DropIndex("dbo.WorkingSkills", new[] { "NannyProfile_Id" });
            DropIndex("dbo.WorkingTerms", new[] { "NannyProfile_Id" });
            CreateTable(
                "dbo.AnimalTypes",
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
                "dbo.WorkingExperienceDiagnoses",
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
                "dbo.TeachingSubjects",
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
                "dbo.WorkerProfileAboutMes",
                c => new
                    {
                        WorkerProfile_Id = c.Int(nullable: false),
                        AboutMe_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.WorkerProfile_Id, t.AboutMe_Id })
                .ForeignKey("dbo.WorkerProfiles", t => t.WorkerProfile_Id, cascadeDelete: true)
                .ForeignKey("dbo.AboutMes", t => t.AboutMe_Id, cascadeDelete: true)
                .Index(t => t.WorkerProfile_Id)
                .Index(t => t.AboutMe_Id);
            
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
            
            CreateTable(
                "dbo.EducationNannyProfiles",
                c => new
                    {
                        Education_Id = c.Int(nullable: false),
                        NannyProfile_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Education_Id, t.NannyProfile_Id })
                .ForeignKey("dbo.Educations", t => t.Education_Id, cascadeDelete: true)
                .ForeignKey("dbo.NannyProfiles", t => t.NannyProfile_Id, cascadeDelete: true)
                .Index(t => t.Education_Id)
                .Index(t => t.NannyProfile_Id);
            
            CreateTable(
                "dbo.NurseProfileEducations",
                c => new
                    {
                        NurseProfile_Id = c.Int(nullable: false),
                        Education_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.NurseProfile_Id, t.Education_Id })
                .ForeignKey("dbo.NurseProfiles", t => t.NurseProfile_Id, cascadeDelete: true)
                .ForeignKey("dbo.Educations", t => t.Education_Id, cascadeDelete: true)
                .Index(t => t.NurseProfile_Id)
                .Index(t => t.Education_Id);
            
            CreateTable(
                "dbo.AnimalTypeZoonyanyaProfiles",
                c => new
                    {
                        AnimalType_Id = c.Int(nullable: false),
                        ZoonyanyaProfile_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AnimalType_Id, t.ZoonyanyaProfile_Id })
                .ForeignKey("dbo.AnimalTypes", t => t.AnimalType_Id, cascadeDelete: true)
                .ForeignKey("dbo.ZoonyanyaProfiles", t => t.ZoonyanyaProfile_Id, cascadeDelete: true)
                .Index(t => t.AnimalType_Id)
                .Index(t => t.ZoonyanyaProfile_Id);
            
            CreateTable(
                "dbo.ZoonyanyaProfileEducations",
                c => new
                    {
                        ZoonyanyaProfile_Id = c.Int(nullable: false),
                        Education_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ZoonyanyaProfile_Id, t.Education_Id })
                .ForeignKey("dbo.ZoonyanyaProfiles", t => t.ZoonyanyaProfile_Id, cascadeDelete: true)
                .ForeignKey("dbo.Educations", t => t.Education_Id, cascadeDelete: true)
                .Index(t => t.ZoonyanyaProfile_Id)
                .Index(t => t.Education_Id);
            
            CreateTable(
                "dbo.WorkingConditionHousekeeperProfiles",
                c => new
                    {
                        WorkingCondition_Id = c.Int(nullable: false),
                        HousekeeperProfile_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.WorkingCondition_Id, t.HousekeeperProfile_Id })
                .ForeignKey("dbo.WorkingConditions", t => t.WorkingCondition_Id, cascadeDelete: true)
                .ForeignKey("dbo.HousekeeperProfiles", t => t.HousekeeperProfile_Id, cascadeDelete: true)
                .Index(t => t.WorkingCondition_Id)
                .Index(t => t.HousekeeperProfile_Id);
            
            CreateTable(
                "dbo.WorkingConditionNannyProfiles",
                c => new
                    {
                        WorkingCondition_Id = c.Int(nullable: false),
                        NannyProfile_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.WorkingCondition_Id, t.NannyProfile_Id })
                .ForeignKey("dbo.WorkingConditions", t => t.WorkingCondition_Id, cascadeDelete: true)
                .ForeignKey("dbo.NannyProfiles", t => t.NannyProfile_Id, cascadeDelete: true)
                .Index(t => t.WorkingCondition_Id)
                .Index(t => t.NannyProfile_Id);
            
            CreateTable(
                "dbo.WorkingConditionNurseProfiles",
                c => new
                    {
                        WorkingCondition_Id = c.Int(nullable: false),
                        NurseProfile_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.WorkingCondition_Id, t.NurseProfile_Id })
                .ForeignKey("dbo.WorkingConditions", t => t.WorkingCondition_Id, cascadeDelete: true)
                .ForeignKey("dbo.NurseProfiles", t => t.NurseProfile_Id, cascadeDelete: true)
                .Index(t => t.WorkingCondition_Id)
                .Index(t => t.NurseProfile_Id);
            
            CreateTable(
                "dbo.WorkingExperienceDiagnoseNurseProfiles",
                c => new
                    {
                        WorkingExperienceDiagnose_Id = c.Int(nullable: false),
                        NurseProfile_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.WorkingExperienceDiagnose_Id, t.NurseProfile_Id })
                .ForeignKey("dbo.WorkingExperienceDiagnoses", t => t.WorkingExperienceDiagnose_Id, cascadeDelete: true)
                .ForeignKey("dbo.NurseProfiles", t => t.NurseProfile_Id, cascadeDelete: true)
                .Index(t => t.WorkingExperienceDiagnose_Id)
                .Index(t => t.NurseProfile_Id);
            
            CreateTable(
                "dbo.EducationTutorProfiles",
                c => new
                    {
                        Education_Id = c.Int(nullable: false),
                        TutorProfile_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Education_Id, t.TutorProfile_Id })
                .ForeignKey("dbo.Educations", t => t.Education_Id, cascadeDelete: true)
                .ForeignKey("dbo.TutorProfiles", t => t.TutorProfile_Id, cascadeDelete: true)
                .Index(t => t.Education_Id)
                .Index(t => t.TutorProfile_Id);
            
            CreateTable(
                "dbo.TeachingSubjectTutorProfiles",
                c => new
                    {
                        TeachingSubject_Id = c.Int(nullable: false),
                        TutorProfile_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TeachingSubject_Id, t.TutorProfile_Id })
                .ForeignKey("dbo.TeachingSubjects", t => t.TeachingSubject_Id, cascadeDelete: true)
                .ForeignKey("dbo.TutorProfiles", t => t.TutorProfile_Id, cascadeDelete: true)
                .Index(t => t.TeachingSubject_Id)
                .Index(t => t.TutorProfile_Id);
            
            CreateTable(
                "dbo.WorkingExperienceAgeNannyProfiles",
                c => new
                    {
                        WorkingExperienceAge_Id = c.Int(nullable: false),
                        NannyProfile_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.WorkingExperienceAge_Id, t.NannyProfile_Id })
                .ForeignKey("dbo.WorkingExperienceAges", t => t.WorkingExperienceAge_Id, cascadeDelete: true)
                .ForeignKey("dbo.NannyProfiles", t => t.NannyProfile_Id, cascadeDelete: true)
                .Index(t => t.WorkingExperienceAge_Id)
                .Index(t => t.NannyProfile_Id);
            
            CreateTable(
                "dbo.WorkingExperienceAgeTutorProfiles",
                c => new
                    {
                        WorkingExperienceAge_Id = c.Int(nullable: false),
                        TutorProfile_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.WorkingExperienceAge_Id, t.TutorProfile_Id })
                .ForeignKey("dbo.WorkingExperienceAges", t => t.WorkingExperienceAge_Id, cascadeDelete: true)
                .ForeignKey("dbo.TutorProfiles", t => t.TutorProfile_Id, cascadeDelete: true)
                .Index(t => t.WorkingExperienceAge_Id)
                .Index(t => t.TutorProfile_Id);
            
            CreateTable(
                "dbo.HousekeeperProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Employment_Id = c.Int(),
                        Residence_Id = c.Int(),
                        HaveDriverLicense = c.Boolean(nullable: false),
                        HaveCar = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WorkerProfiles", t => t.Id)
                .ForeignKey("dbo.Employments", t => t.Employment_Id)
                .ForeignKey("dbo.Residences", t => t.Residence_Id)
                .Index(t => t.Id)
                .Index(t => t.Employment_Id)
                .Index(t => t.Residence_Id);
            
            CreateTable(
                "dbo.TutorProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ChildrenCount_Id = c.Int(),
                        HaveChildren = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WorkerProfiles", t => t.Id)
                .ForeignKey("dbo.ChildrenCounts", t => t.ChildrenCount_Id)
                .Index(t => t.Id)
                .Index(t => t.ChildrenCount_Id);
            
            CreateTable(
                "dbo.NurseProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Employment_Id = c.Int(),
                        Residence_Id = c.Int(),
                        HaveDriverLicense = c.Boolean(nullable: false),
                        HaveCar = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WorkerProfiles", t => t.Id)
                .ForeignKey("dbo.Employments", t => t.Employment_Id)
                .ForeignKey("dbo.Residences", t => t.Residence_Id)
                .Index(t => t.Id)
                .Index(t => t.Employment_Id)
                .Index(t => t.Residence_Id);
            
            CreateTable(
                "dbo.ZoonyanyaProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Employment_Id = c.Int(),
                        Residence_Id = c.Int(),
                        HaveDriverLicense = c.Boolean(nullable: false),
                        HaveCar = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WorkerProfiles", t => t.Id)
                .ForeignKey("dbo.Employments", t => t.Employment_Id)
                .ForeignKey("dbo.Residences", t => t.Residence_Id)
                .Index(t => t.Id)
                .Index(t => t.Employment_Id)
                .Index(t => t.Residence_Id);
            
            AddColumn("dbo.AboutMes", "WorkerType", c => c.Int(nullable: false));
            AddColumn("dbo.WorkerProfiles", "YearExperience", c => c.Int(nullable: false));
            AddColumn("dbo.WorkerProfiles", "WorkStartExperience", c => c.Int(nullable: false));
            AddColumn("dbo.WorkerProfiles", "Salary", c => c.Int(nullable: false));
            AddColumn("dbo.WorkerProfiles", "WorkStartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.NannyProfiles", "Residence_Id", c => c.Int());
            AddColumn("dbo.NannyProfiles", "HaveDriverLicense", c => c.Boolean(nullable: false));
            AddColumn("dbo.NannyProfiles", "HaveCar", c => c.Boolean(nullable: false));
            AddColumn("dbo.Educations", "WorkerType", c => c.Int(nullable: false));
            AddColumn("dbo.WorkingConditions", "WorkerType", c => c.Int(nullable: false));
            AddColumn("dbo.WorkingSkills", "WorkerType", c => c.Int(nullable: false));
            CreateIndex("dbo.NannyProfiles", "Residence_Id");
            DropColumn("dbo.AboutMes", "NannyProfile_Id");
            DropColumn("dbo.WorkerProfiles", "HaveDriverLicense");
            DropColumn("dbo.WorkerProfiles", "HaveCar");
            DropColumn("dbo.WorkerProfiles", "Residence_Id");
            DropColumn("dbo.WorkerProfiles", "Education_Id");
            DropColumn("dbo.WorkerProfiles", "WorkingCondition_Id");
            DropColumn("dbo.WorkerProfiles", "WorkingExperienceAge_Id");
            DropColumn("dbo.WorkerProfiles", "WorkingSkill_Id");
            DropColumn("dbo.WorkerProfiles", "WorkingTerm_Id");
            DropColumn("dbo.NannyProfiles", "YearExperience");
            DropColumn("dbo.NannyProfiles", "Salary");
            DropColumn("dbo.NannyProfiles", "WorkStartDate");
            DropColumn("dbo.Educations", "NannyProfile_Id");
            DropColumn("dbo.WorkingConditions", "NannyProfile_Id");
            DropColumn("dbo.WorkingExperienceAges", "NannyProfile_Id");
            DropColumn("dbo.WorkingSkills", "NannyProfile_Id");
            DropColumn("dbo.WorkingTerms", "NannyProfile_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WorkingTerms", "NannyProfile_Id", c => c.Int());
            AddColumn("dbo.WorkingSkills", "NannyProfile_Id", c => c.Int());
            AddColumn("dbo.WorkingExperienceAges", "NannyProfile_Id", c => c.Int());
            AddColumn("dbo.WorkingConditions", "NannyProfile_Id", c => c.Int());
            AddColumn("dbo.Educations", "NannyProfile_Id", c => c.Int());
            AddColumn("dbo.NannyProfiles", "WorkStartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.NannyProfiles", "Salary", c => c.Int(nullable: false));
            AddColumn("dbo.NannyProfiles", "YearExperience", c => c.Int(nullable: false));
            AddColumn("dbo.WorkerProfiles", "WorkingTerm_Id", c => c.Int());
            AddColumn("dbo.WorkerProfiles", "WorkingSkill_Id", c => c.Int());
            AddColumn("dbo.WorkerProfiles", "WorkingExperienceAge_Id", c => c.Int());
            AddColumn("dbo.WorkerProfiles", "WorkingCondition_Id", c => c.Int());
            AddColumn("dbo.WorkerProfiles", "Education_Id", c => c.Int());
            AddColumn("dbo.WorkerProfiles", "Residence_Id", c => c.Int());
            AddColumn("dbo.WorkerProfiles", "HaveCar", c => c.Boolean(nullable: false));
            AddColumn("dbo.WorkerProfiles", "HaveDriverLicense", c => c.Boolean(nullable: false));
            AddColumn("dbo.AboutMes", "NannyProfile_Id", c => c.Int());
            DropForeignKey("dbo.ZoonyanyaProfiles", "Residence_Id", "dbo.Residences");
            DropForeignKey("dbo.ZoonyanyaProfiles", "Employment_Id", "dbo.Employments");
            DropForeignKey("dbo.ZoonyanyaProfiles", "Id", "dbo.WorkerProfiles");
            DropForeignKey("dbo.NurseProfiles", "Residence_Id", "dbo.Residences");
            DropForeignKey("dbo.NurseProfiles", "Employment_Id", "dbo.Employments");
            DropForeignKey("dbo.NurseProfiles", "Id", "dbo.WorkerProfiles");
            DropForeignKey("dbo.TutorProfiles", "ChildrenCount_Id", "dbo.ChildrenCounts");
            DropForeignKey("dbo.TutorProfiles", "Id", "dbo.WorkerProfiles");
            DropForeignKey("dbo.HousekeeperProfiles", "Residence_Id", "dbo.Residences");
            DropForeignKey("dbo.HousekeeperProfiles", "Employment_Id", "dbo.Employments");
            DropForeignKey("dbo.HousekeeperProfiles", "Id", "dbo.WorkerProfiles");
            DropForeignKey("dbo.WorkingExperienceAgeTutorProfiles", "TutorProfile_Id", "dbo.TutorProfiles");
            DropForeignKey("dbo.WorkingExperienceAgeTutorProfiles", "WorkingExperienceAge_Id", "dbo.WorkingExperienceAges");
            DropForeignKey("dbo.WorkingExperienceAgeNannyProfiles", "NannyProfile_Id", "dbo.NannyProfiles");
            DropForeignKey("dbo.WorkingExperienceAgeNannyProfiles", "WorkingExperienceAge_Id", "dbo.WorkingExperienceAges");
            DropForeignKey("dbo.TeachingSubjectTutorProfiles", "TutorProfile_Id", "dbo.TutorProfiles");
            DropForeignKey("dbo.TeachingSubjectTutorProfiles", "TeachingSubject_Id", "dbo.TeachingSubjects");
            DropForeignKey("dbo.TeachingSubjects", "OwnerCountry_Iso", "dbo.Countries");
            DropForeignKey("dbo.EducationTutorProfiles", "TutorProfile_Id", "dbo.TutorProfiles");
            DropForeignKey("dbo.EducationTutorProfiles", "Education_Id", "dbo.Educations");
            DropForeignKey("dbo.WorkingExperienceDiagnoses", "OwnerCountry_Iso", "dbo.Countries");
            DropForeignKey("dbo.WorkingExperienceDiagnoseNurseProfiles", "NurseProfile_Id", "dbo.NurseProfiles");
            DropForeignKey("dbo.WorkingExperienceDiagnoseNurseProfiles", "WorkingExperienceDiagnose_Id", "dbo.WorkingExperienceDiagnoses");
            DropForeignKey("dbo.WorkingConditionNurseProfiles", "NurseProfile_Id", "dbo.NurseProfiles");
            DropForeignKey("dbo.WorkingConditionNurseProfiles", "WorkingCondition_Id", "dbo.WorkingConditions");
            DropForeignKey("dbo.WorkingConditionNannyProfiles", "NannyProfile_Id", "dbo.NannyProfiles");
            DropForeignKey("dbo.WorkingConditionNannyProfiles", "WorkingCondition_Id", "dbo.WorkingConditions");
            DropForeignKey("dbo.WorkingConditionHousekeeperProfiles", "HousekeeperProfile_Id", "dbo.HousekeeperProfiles");
            DropForeignKey("dbo.WorkingConditionHousekeeperProfiles", "WorkingCondition_Id", "dbo.WorkingConditions");
            DropForeignKey("dbo.ZoonyanyaProfileEducations", "Education_Id", "dbo.Educations");
            DropForeignKey("dbo.ZoonyanyaProfileEducations", "ZoonyanyaProfile_Id", "dbo.ZoonyanyaProfiles");
            DropForeignKey("dbo.AnimalTypeZoonyanyaProfiles", "ZoonyanyaProfile_Id", "dbo.ZoonyanyaProfiles");
            DropForeignKey("dbo.AnimalTypeZoonyanyaProfiles", "AnimalType_Id", "dbo.AnimalTypes");
            DropForeignKey("dbo.AnimalTypes", "OwnerCountry_Iso", "dbo.Countries");
            DropForeignKey("dbo.NurseProfileEducations", "Education_Id", "dbo.Educations");
            DropForeignKey("dbo.NurseProfileEducations", "NurseProfile_Id", "dbo.NurseProfiles");
            DropForeignKey("dbo.EducationNannyProfiles", "NannyProfile_Id", "dbo.NannyProfiles");
            DropForeignKey("dbo.EducationNannyProfiles", "Education_Id", "dbo.Educations");
            DropForeignKey("dbo.WorkingTermWorkerProfiles", "WorkerProfile_Id", "dbo.WorkerProfiles");
            DropForeignKey("dbo.WorkingTermWorkerProfiles", "WorkingTerm_Id", "dbo.WorkingTerms");
            DropForeignKey("dbo.WorkingSkillWorkerProfiles", "WorkerProfile_Id", "dbo.WorkerProfiles");
            DropForeignKey("dbo.WorkingSkillWorkerProfiles", "WorkingSkill_Id", "dbo.WorkingSkills");
            DropForeignKey("dbo.WorkerProfileAboutMes", "AboutMe_Id", "dbo.AboutMes");
            DropForeignKey("dbo.WorkerProfileAboutMes", "WorkerProfile_Id", "dbo.WorkerProfiles");
            DropIndex("dbo.ZoonyanyaProfiles", new[] { "Residence_Id" });
            DropIndex("dbo.ZoonyanyaProfiles", new[] { "Employment_Id" });
            DropIndex("dbo.ZoonyanyaProfiles", new[] { "Id" });
            DropIndex("dbo.NurseProfiles", new[] { "Residence_Id" });
            DropIndex("dbo.NurseProfiles", new[] { "Employment_Id" });
            DropIndex("dbo.NurseProfiles", new[] { "Id" });
            DropIndex("dbo.TutorProfiles", new[] { "ChildrenCount_Id" });
            DropIndex("dbo.TutorProfiles", new[] { "Id" });
            DropIndex("dbo.HousekeeperProfiles", new[] { "Residence_Id" });
            DropIndex("dbo.HousekeeperProfiles", new[] { "Employment_Id" });
            DropIndex("dbo.HousekeeperProfiles", new[] { "Id" });
            DropIndex("dbo.NannyProfiles", new[] { "Residence_Id" });
            DropIndex("dbo.WorkingExperienceAgeTutorProfiles", new[] { "TutorProfile_Id" });
            DropIndex("dbo.WorkingExperienceAgeTutorProfiles", new[] { "WorkingExperienceAge_Id" });
            DropIndex("dbo.WorkingExperienceAgeNannyProfiles", new[] { "NannyProfile_Id" });
            DropIndex("dbo.WorkingExperienceAgeNannyProfiles", new[] { "WorkingExperienceAge_Id" });
            DropIndex("dbo.TeachingSubjectTutorProfiles", new[] { "TutorProfile_Id" });
            DropIndex("dbo.TeachingSubjectTutorProfiles", new[] { "TeachingSubject_Id" });
            DropIndex("dbo.EducationTutorProfiles", new[] { "TutorProfile_Id" });
            DropIndex("dbo.EducationTutorProfiles", new[] { "Education_Id" });
            DropIndex("dbo.WorkingExperienceDiagnoseNurseProfiles", new[] { "NurseProfile_Id" });
            DropIndex("dbo.WorkingExperienceDiagnoseNurseProfiles", new[] { "WorkingExperienceDiagnose_Id" });
            DropIndex("dbo.WorkingConditionNurseProfiles", new[] { "NurseProfile_Id" });
            DropIndex("dbo.WorkingConditionNurseProfiles", new[] { "WorkingCondition_Id" });
            DropIndex("dbo.WorkingConditionNannyProfiles", new[] { "NannyProfile_Id" });
            DropIndex("dbo.WorkingConditionNannyProfiles", new[] { "WorkingCondition_Id" });
            DropIndex("dbo.WorkingConditionHousekeeperProfiles", new[] { "HousekeeperProfile_Id" });
            DropIndex("dbo.WorkingConditionHousekeeperProfiles", new[] { "WorkingCondition_Id" });
            DropIndex("dbo.ZoonyanyaProfileEducations", new[] { "Education_Id" });
            DropIndex("dbo.ZoonyanyaProfileEducations", new[] { "ZoonyanyaProfile_Id" });
            DropIndex("dbo.AnimalTypeZoonyanyaProfiles", new[] { "ZoonyanyaProfile_Id" });
            DropIndex("dbo.AnimalTypeZoonyanyaProfiles", new[] { "AnimalType_Id" });
            DropIndex("dbo.NurseProfileEducations", new[] { "Education_Id" });
            DropIndex("dbo.NurseProfileEducations", new[] { "NurseProfile_Id" });
            DropIndex("dbo.EducationNannyProfiles", new[] { "NannyProfile_Id" });
            DropIndex("dbo.EducationNannyProfiles", new[] { "Education_Id" });
            DropIndex("dbo.WorkingTermWorkerProfiles", new[] { "WorkerProfile_Id" });
            DropIndex("dbo.WorkingTermWorkerProfiles", new[] { "WorkingTerm_Id" });
            DropIndex("dbo.WorkingSkillWorkerProfiles", new[] { "WorkerProfile_Id" });
            DropIndex("dbo.WorkingSkillWorkerProfiles", new[] { "WorkingSkill_Id" });
            DropIndex("dbo.WorkerProfileAboutMes", new[] { "AboutMe_Id" });
            DropIndex("dbo.WorkerProfileAboutMes", new[] { "WorkerProfile_Id" });
            DropIndex("dbo.TeachingSubjects", new[] { "OwnerCountry_Iso" });
            DropIndex("dbo.WorkingExperienceDiagnoses", new[] { "OwnerCountry_Iso" });
            DropIndex("dbo.AnimalTypes", new[] { "OwnerCountry_Iso" });
            DropColumn("dbo.WorkingSkills", "WorkerType");
            DropColumn("dbo.WorkingConditions", "WorkerType");
            DropColumn("dbo.Educations", "WorkerType");
            DropColumn("dbo.NannyProfiles", "HaveCar");
            DropColumn("dbo.NannyProfiles", "HaveDriverLicense");
            DropColumn("dbo.NannyProfiles", "Residence_Id");
            DropColumn("dbo.WorkerProfiles", "WorkStartDate");
            DropColumn("dbo.WorkerProfiles", "Salary");
            DropColumn("dbo.WorkerProfiles", "WorkStartExperience");
            DropColumn("dbo.WorkerProfiles", "YearExperience");
            DropColumn("dbo.AboutMes", "WorkerType");
            DropTable("dbo.ZoonyanyaProfiles");
            DropTable("dbo.NurseProfiles");
            DropTable("dbo.TutorProfiles");
            DropTable("dbo.HousekeeperProfiles");
            DropTable("dbo.WorkingExperienceAgeTutorProfiles");
            DropTable("dbo.WorkingExperienceAgeNannyProfiles");
            DropTable("dbo.TeachingSubjectTutorProfiles");
            DropTable("dbo.EducationTutorProfiles");
            DropTable("dbo.WorkingExperienceDiagnoseNurseProfiles");
            DropTable("dbo.WorkingConditionNurseProfiles");
            DropTable("dbo.WorkingConditionNannyProfiles");
            DropTable("dbo.WorkingConditionHousekeeperProfiles");
            DropTable("dbo.ZoonyanyaProfileEducations");
            DropTable("dbo.AnimalTypeZoonyanyaProfiles");
            DropTable("dbo.NurseProfileEducations");
            DropTable("dbo.EducationNannyProfiles");
            DropTable("dbo.WorkingTermWorkerProfiles");
            DropTable("dbo.WorkingSkillWorkerProfiles");
            DropTable("dbo.WorkerProfileAboutMes");
            DropTable("dbo.TeachingSubjects");
            DropTable("dbo.WorkingExperienceDiagnoses");
            DropTable("dbo.AnimalTypes");
            CreateIndex("dbo.WorkingTerms", "NannyProfile_Id");
            CreateIndex("dbo.WorkingSkills", "NannyProfile_Id");
            CreateIndex("dbo.WorkingExperienceAges", "NannyProfile_Id");
            CreateIndex("dbo.WorkingConditions", "NannyProfile_Id");
            CreateIndex("dbo.Educations", "NannyProfile_Id");
            CreateIndex("dbo.WorkerProfiles", "WorkingTerm_Id");
            CreateIndex("dbo.WorkerProfiles", "WorkingSkill_Id");
            CreateIndex("dbo.WorkerProfiles", "WorkingExperienceAge_Id");
            CreateIndex("dbo.WorkerProfiles", "WorkingCondition_Id");
            CreateIndex("dbo.WorkerProfiles", "Education_Id");
            CreateIndex("dbo.WorkerProfiles", "Residence_Id");
            CreateIndex("dbo.AboutMes", "NannyProfile_Id");
            AddForeignKey("dbo.WorkingTerms", "NannyProfile_Id", "dbo.NannyProfiles", "Id");
            AddForeignKey("dbo.WorkerProfiles", "WorkingTerm_Id", "dbo.WorkingTerms", "Id");
            AddForeignKey("dbo.WorkingSkills", "NannyProfile_Id", "dbo.NannyProfiles", "Id");
            AddForeignKey("dbo.WorkerProfiles", "WorkingSkill_Id", "dbo.WorkingSkills", "Id");
            AddForeignKey("dbo.WorkingExperienceAges", "NannyProfile_Id", "dbo.NannyProfiles", "Id");
            AddForeignKey("dbo.WorkerProfiles", "WorkingExperienceAge_Id", "dbo.WorkingExperienceAges", "Id");
            AddForeignKey("dbo.WorkingConditions", "NannyProfile_Id", "dbo.NannyProfiles", "Id");
            AddForeignKey("dbo.WorkerProfiles", "WorkingCondition_Id", "dbo.WorkingConditions", "Id");
            AddForeignKey("dbo.Educations", "NannyProfile_Id", "dbo.NannyProfiles", "Id");
            AddForeignKey("dbo.WorkerProfiles", "Education_Id", "dbo.Educations", "Id");
            AddForeignKey("dbo.AboutMes", "NannyProfile_Id", "dbo.NannyProfiles", "Id");
        }
    }
}
