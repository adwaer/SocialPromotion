namespace Nanny.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wt_tables : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.WorkingConditions", newName: "NannyEducations");
            RenameTable(name: "dbo.WorkingConditionNannyProfiles", newName: "NannyEducationNannyProfiles");
            DropForeignKey("dbo.WorkerProfileAboutMes", "WorkerProfile_Id", "dbo.WorkerProfiles");
            DropForeignKey("dbo.WorkerProfileAboutMes", "AboutMe_Id", "dbo.AboutMes");
            DropForeignKey("dbo.WorkingSkills", "OwnerCountry_Iso", "dbo.Countries");
            DropForeignKey("dbo.WorkingSkillWorkerProfiles", "WorkingSkill_Id", "dbo.WorkingSkills");
            DropForeignKey("dbo.WorkingSkillWorkerProfiles", "WorkerProfile_Id", "dbo.WorkerProfiles");
            DropForeignKey("dbo.EducationNannyProfiles", "Education_Id", "dbo.Educations");
            DropForeignKey("dbo.EducationNannyProfiles", "NannyProfile_Id", "dbo.NannyProfiles");
            DropForeignKey("dbo.NurseProfileEducations", "NurseProfile_Id", "dbo.NurseProfiles");
            DropForeignKey("dbo.NurseProfileEducations", "Education_Id", "dbo.Educations");
            DropForeignKey("dbo.PetCareProfileEducations", "PetCareProfile_Id", "dbo.PetcareProfiles");
            DropForeignKey("dbo.PetCareProfileEducations", "Education_Id", "dbo.Educations");
            DropForeignKey("dbo.WorkingConditionHousekeeperProfiles", "WorkingCondition_Id", "dbo.WorkingConditions");
            DropForeignKey("dbo.WorkingConditionHousekeeperProfiles", "HousekeeperProfile_Id", "dbo.HousekeeperProfiles");
            DropForeignKey("dbo.WorkingConditionNurseProfiles", "WorkingCondition_Id", "dbo.WorkingConditions");
            DropForeignKey("dbo.WorkingConditionNurseProfiles", "NurseProfile_Id", "dbo.NurseProfiles");
            DropForeignKey("dbo.Educations", "OwnerCountry_Iso", "dbo.Countries");
            DropForeignKey("dbo.EducationTutorProfiles", "Education_Id", "dbo.Educations");
            DropForeignKey("dbo.EducationTutorProfiles", "TutorProfile_Id", "dbo.TutorProfiles");
            DropForeignKey("dbo.AboutMes", "OwnerCountry_Iso", "dbo.Countries");
            DropIndex("dbo.AboutMes", new[] { "OwnerCountry_Iso" });
            DropIndex("dbo.WorkingSkills", new[] { "OwnerCountry_Iso" });
            DropIndex("dbo.Educations", new[] { "OwnerCountry_Iso" });
            DropIndex("dbo.WorkerProfileAboutMes", new[] { "WorkerProfile_Id" });
            DropIndex("dbo.WorkerProfileAboutMes", new[] { "AboutMe_Id" });
            DropIndex("dbo.WorkingSkillWorkerProfiles", new[] { "WorkingSkill_Id" });
            DropIndex("dbo.WorkingSkillWorkerProfiles", new[] { "WorkerProfile_Id" });
            DropIndex("dbo.EducationNannyProfiles", new[] { "Education_Id" });
            DropIndex("dbo.EducationNannyProfiles", new[] { "NannyProfile_Id" });
            DropIndex("dbo.NurseProfileEducations", new[] { "NurseProfile_Id" });
            DropIndex("dbo.NurseProfileEducations", new[] { "Education_Id" });
            DropIndex("dbo.PetCareProfileEducations", new[] { "PetCareProfile_Id" });
            DropIndex("dbo.PetCareProfileEducations", new[] { "Education_Id" });
            DropIndex("dbo.WorkingConditionHousekeeperProfiles", new[] { "WorkingCondition_Id" });
            DropIndex("dbo.WorkingConditionHousekeeperProfiles", new[] { "HousekeeperProfile_Id" });
            DropIndex("dbo.WorkingConditionNurseProfiles", new[] { "WorkingCondition_Id" });
            DropIndex("dbo.WorkingConditionNurseProfiles", new[] { "NurseProfile_Id" });
            DropIndex("dbo.EducationTutorProfiles", new[] { "Education_Id" });
            DropIndex("dbo.EducationTutorProfiles", new[] { "TutorProfile_Id" });
            RenameColumn(table: "dbo.NannyEducationNannyProfiles", name: "WorkingCondition_Id", newName: "NannyEducation_Id");
            RenameIndex(table: "dbo.NannyEducationNannyProfiles", name: "IX_WorkingCondition_Id", newName: "IX_NannyEducation_Id");
            CreateTable(
                "dbo.AboutHousekeepers",
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
                "dbo.AboutNannies",
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
                "dbo.TutorEducations",
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
                "dbo.TutorWorkingSkills",
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
                "dbo.AboutNurses",
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
                "dbo.NurseEducations",
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
                "dbo.NurseWorkingConditions",
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
                "dbo.NurseWorkingSkills",
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
                "dbo.PetCareEducations",
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
                "dbo.PetCareWorkingSkills",
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
                "dbo.NannyWorkingConditions",
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
                "dbo.NannyWorkingSkills",
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
                "dbo.HousekeeperWorkingConditions",
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
                "dbo.HousekeeperWorkingSkills",
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
                "dbo.HousekeeperProfileAboutHousekeepers",
                c => new
                    {
                        HousekeeperProfile_Id = c.Int(nullable: false),
                        AboutHousekeeper_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.HousekeeperProfile_Id, t.AboutHousekeeper_Id })
                .ForeignKey("dbo.HousekeeperProfiles", t => t.HousekeeperProfile_Id, cascadeDelete: true)
                .ForeignKey("dbo.AboutHousekeepers", t => t.AboutHousekeeper_Id, cascadeDelete: true)
                .Index(t => t.HousekeeperProfile_Id)
                .Index(t => t.AboutHousekeeper_Id);
            
            CreateTable(
                "dbo.AboutNannyNannyProfiles",
                c => new
                    {
                        AboutNanny_Id = c.Int(nullable: false),
                        NannyProfile_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AboutNanny_Id, t.NannyProfile_Id })
                .ForeignKey("dbo.AboutNannies", t => t.AboutNanny_Id, cascadeDelete: true)
                .ForeignKey("dbo.NannyProfiles", t => t.NannyProfile_Id, cascadeDelete: true)
                .Index(t => t.AboutNanny_Id)
                .Index(t => t.NannyProfile_Id);
            
            CreateTable(
                "dbo.TutorEducationTutorProfiles",
                c => new
                    {
                        TutorEducation_Id = c.Int(nullable: false),
                        TutorProfile_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TutorEducation_Id, t.TutorProfile_Id })
                .ForeignKey("dbo.TutorEducations", t => t.TutorEducation_Id, cascadeDelete: true)
                .ForeignKey("dbo.TutorProfiles", t => t.TutorProfile_Id, cascadeDelete: true)
                .Index(t => t.TutorEducation_Id)
                .Index(t => t.TutorProfile_Id);
            
            CreateTable(
                "dbo.TutorWorkingSkillTutorProfiles",
                c => new
                    {
                        TutorWorkingSkill_Id = c.Int(nullable: false),
                        TutorProfile_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TutorWorkingSkill_Id, t.TutorProfile_Id })
                .ForeignKey("dbo.TutorWorkingSkills", t => t.TutorWorkingSkill_Id, cascadeDelete: true)
                .ForeignKey("dbo.TutorProfiles", t => t.TutorProfile_Id, cascadeDelete: true)
                .Index(t => t.TutorWorkingSkill_Id)
                .Index(t => t.TutorProfile_Id);
            
            CreateTable(
                "dbo.AboutNurseNurseProfiles",
                c => new
                    {
                        AboutNurse_Id = c.Int(nullable: false),
                        NurseProfile_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AboutNurse_Id, t.NurseProfile_Id })
                .ForeignKey("dbo.AboutNurses", t => t.AboutNurse_Id, cascadeDelete: true)
                .ForeignKey("dbo.NurseProfiles", t => t.NurseProfile_Id, cascadeDelete: true)
                .Index(t => t.AboutNurse_Id)
                .Index(t => t.NurseProfile_Id);
            
            CreateTable(
                "dbo.NurseEducationNurseProfiles",
                c => new
                    {
                        NurseEducation_Id = c.Int(nullable: false),
                        NurseProfile_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.NurseEducation_Id, t.NurseProfile_Id })
                .ForeignKey("dbo.NurseEducations", t => t.NurseEducation_Id, cascadeDelete: true)
                .ForeignKey("dbo.NurseProfiles", t => t.NurseProfile_Id, cascadeDelete: true)
                .Index(t => t.NurseEducation_Id)
                .Index(t => t.NurseProfile_Id);
            
            CreateTable(
                "dbo.NurseWorkingConditionNurseProfiles",
                c => new
                    {
                        NurseWorkingCondition_Id = c.Int(nullable: false),
                        NurseProfile_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.NurseWorkingCondition_Id, t.NurseProfile_Id })
                .ForeignKey("dbo.NurseWorkingConditions", t => t.NurseWorkingCondition_Id, cascadeDelete: true)
                .ForeignKey("dbo.NurseProfiles", t => t.NurseProfile_Id, cascadeDelete: true)
                .Index(t => t.NurseWorkingCondition_Id)
                .Index(t => t.NurseProfile_Id);
            
            CreateTable(
                "dbo.NurseWorkingSkillNurseProfiles",
                c => new
                    {
                        NurseWorkingSkill_Id = c.Int(nullable: false),
                        NurseProfile_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.NurseWorkingSkill_Id, t.NurseProfile_Id })
                .ForeignKey("dbo.NurseWorkingSkills", t => t.NurseWorkingSkill_Id, cascadeDelete: true)
                .ForeignKey("dbo.NurseProfiles", t => t.NurseProfile_Id, cascadeDelete: true)
                .Index(t => t.NurseWorkingSkill_Id)
                .Index(t => t.NurseProfile_Id);
            
            CreateTable(
                "dbo.PetCareEducationPetCareProfiles",
                c => new
                    {
                        PetCareEducation_Id = c.Int(nullable: false),
                        PetCareProfile_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PetCareEducation_Id, t.PetCareProfile_Id })
                .ForeignKey("dbo.PetCareEducations", t => t.PetCareEducation_Id, cascadeDelete: true)
                .ForeignKey("dbo.PetcareProfiles", t => t.PetCareProfile_Id, cascadeDelete: true)
                .Index(t => t.PetCareEducation_Id)
                .Index(t => t.PetCareProfile_Id);
            
            CreateTable(
                "dbo.PetCareWorkingSkillPetCareProfiles",
                c => new
                    {
                        PetCareWorkingSkill_Id = c.Int(nullable: false),
                        PetCareProfile_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PetCareWorkingSkill_Id, t.PetCareProfile_Id })
                .ForeignKey("dbo.PetCareWorkingSkills", t => t.PetCareWorkingSkill_Id, cascadeDelete: true)
                .ForeignKey("dbo.PetcareProfiles", t => t.PetCareProfile_Id, cascadeDelete: true)
                .Index(t => t.PetCareWorkingSkill_Id)
                .Index(t => t.PetCareProfile_Id);
            
            CreateTable(
                "dbo.NannyWorkingConditionNannyProfiles",
                c => new
                    {
                        NannyWorkingCondition_Id = c.Int(nullable: false),
                        NannyProfile_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.NannyWorkingCondition_Id, t.NannyProfile_Id })
                .ForeignKey("dbo.NannyWorkingConditions", t => t.NannyWorkingCondition_Id, cascadeDelete: true)
                .ForeignKey("dbo.NannyProfiles", t => t.NannyProfile_Id, cascadeDelete: true)
                .Index(t => t.NannyWorkingCondition_Id)
                .Index(t => t.NannyProfile_Id);
            
            CreateTable(
                "dbo.NannyWorkingSkillNannyProfiles",
                c => new
                    {
                        NannyWorkingSkill_Id = c.Int(nullable: false),
                        NannyProfile_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.NannyWorkingSkill_Id, t.NannyProfile_Id })
                .ForeignKey("dbo.NannyWorkingSkills", t => t.NannyWorkingSkill_Id, cascadeDelete: true)
                .ForeignKey("dbo.NannyProfiles", t => t.NannyProfile_Id, cascadeDelete: true)
                .Index(t => t.NannyWorkingSkill_Id)
                .Index(t => t.NannyProfile_Id);
            
            CreateTable(
                "dbo.HousekeeperWorkingConditionHousekeeperProfiles",
                c => new
                    {
                        HousekeeperWorkingCondition_Id = c.Int(nullable: false),
                        HousekeeperProfile_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.HousekeeperWorkingCondition_Id, t.HousekeeperProfile_Id })
                .ForeignKey("dbo.HousekeeperWorkingConditions", t => t.HousekeeperWorkingCondition_Id, cascadeDelete: true)
                .ForeignKey("dbo.HousekeeperProfiles", t => t.HousekeeperProfile_Id, cascadeDelete: true)
                .Index(t => t.HousekeeperWorkingCondition_Id)
                .Index(t => t.HousekeeperProfile_Id);
            
            CreateTable(
                "dbo.HousekeeperWorkingSkillHousekeeperProfiles",
                c => new
                    {
                        HousekeeperWorkingSkill_Id = c.Int(nullable: false),
                        HousekeeperProfile_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.HousekeeperWorkingSkill_Id, t.HousekeeperProfile_Id })
                .ForeignKey("dbo.HousekeeperWorkingSkills", t => t.HousekeeperWorkingSkill_Id, cascadeDelete: true)
                .ForeignKey("dbo.HousekeeperProfiles", t => t.HousekeeperProfile_Id, cascadeDelete: true)
                .Index(t => t.HousekeeperWorkingSkill_Id)
                .Index(t => t.HousekeeperProfile_Id);
            
            DropColumn("dbo.NannyEducations", "WorkerType");
            DropTable("dbo.AboutMes");
            DropTable("dbo.WorkingSkills");
            DropTable("dbo.PetCareProfileEducations");
            DropTable("dbo.Educations");
            DropTable("dbo.WorkerProfileAboutMes");
            DropTable("dbo.WorkingSkillWorkerProfiles");
            DropTable("dbo.EducationNannyProfiles");
            DropTable("dbo.NurseProfileEducations");
            DropTable("dbo.WorkingConditionHousekeeperProfiles");
            DropTable("dbo.WorkingConditionNurseProfiles");
            DropTable("dbo.EducationTutorProfiles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EducationTutorProfiles",
                c => new
                    {
                        Education_Id = c.Int(nullable: false),
                        TutorProfile_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Education_Id, t.TutorProfile_Id });
            
            CreateTable(
                "dbo.WorkingConditionNurseProfiles",
                c => new
                    {
                        WorkingCondition_Id = c.Int(nullable: false),
                        NurseProfile_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.WorkingCondition_Id, t.NurseProfile_Id });
            
            CreateTable(
                "dbo.WorkingConditionHousekeeperProfiles",
                c => new
                    {
                        WorkingCondition_Id = c.Int(nullable: false),
                        HousekeeperProfile_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.WorkingCondition_Id, t.HousekeeperProfile_Id });
            
            CreateTable(
                "dbo.PetCareProfileEducations",
                c => new
                    {
                        PetCareProfile_Id = c.Int(nullable: false),
                        Education_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PetCareProfile_Id, t.Education_Id });
            
            CreateTable(
                "dbo.NurseProfileEducations",
                c => new
                    {
                        NurseProfile_Id = c.Int(nullable: false),
                        Education_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.NurseProfile_Id, t.Education_Id });
            
            CreateTable(
                "dbo.EducationNannyProfiles",
                c => new
                    {
                        Education_Id = c.Int(nullable: false),
                        NannyProfile_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Education_Id, t.NannyProfile_Id });
            
            CreateTable(
                "dbo.WorkingSkillWorkerProfiles",
                c => new
                    {
                        WorkingSkill_Id = c.Int(nullable: false),
                        WorkerProfile_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.WorkingSkill_Id, t.WorkerProfile_Id });
            
            CreateTable(
                "dbo.WorkerProfileAboutMes",
                c => new
                    {
                        WorkerProfile_Id = c.Int(nullable: false),
                        AboutMe_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.WorkerProfile_Id, t.AboutMe_Id });
            
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WorkerType = c.Int(nullable: false),
                        Name = c.String(),
                        Order = c.Int(nullable: false),
                        Disabled = c.Boolean(nullable: false),
                        OwnerCountry_Iso = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WorkingSkills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WorkerType = c.Int(nullable: false),
                        Name = c.String(),
                        Order = c.Int(nullable: false),
                        Disabled = c.Boolean(nullable: false),
                        OwnerCountry_Iso = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AboutMes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WorkerType = c.Int(nullable: false),
                        Name = c.String(),
                        Order = c.Int(nullable: false),
                        Disabled = c.Boolean(nullable: false),
                        OwnerCountry_Iso = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.NannyEducations", "WorkerType", c => c.Int(nullable: false));
            DropForeignKey("dbo.AboutHousekeepers", "OwnerCountry_Iso", "dbo.Countries");
            DropForeignKey("dbo.HousekeeperWorkingSkillHousekeeperProfiles", "HousekeeperProfile_Id", "dbo.HousekeeperProfiles");
            DropForeignKey("dbo.HousekeeperWorkingSkillHousekeeperProfiles", "HousekeeperWorkingSkill_Id", "dbo.HousekeeperWorkingSkills");
            DropForeignKey("dbo.HousekeeperWorkingSkills", "OwnerCountry_Iso", "dbo.Countries");
            DropForeignKey("dbo.HousekeeperWorkingConditionHousekeeperProfiles", "HousekeeperProfile_Id", "dbo.HousekeeperProfiles");
            DropForeignKey("dbo.HousekeeperWorkingConditionHousekeeperProfiles", "HousekeeperWorkingCondition_Id", "dbo.HousekeeperWorkingConditions");
            DropForeignKey("dbo.HousekeeperWorkingConditions", "OwnerCountry_Iso", "dbo.Countries");
            DropForeignKey("dbo.NannyWorkingSkillNannyProfiles", "NannyProfile_Id", "dbo.NannyProfiles");
            DropForeignKey("dbo.NannyWorkingSkillNannyProfiles", "NannyWorkingSkill_Id", "dbo.NannyWorkingSkills");
            DropForeignKey("dbo.NannyWorkingSkills", "OwnerCountry_Iso", "dbo.Countries");
            DropForeignKey("dbo.NannyWorkingConditionNannyProfiles", "NannyProfile_Id", "dbo.NannyProfiles");
            DropForeignKey("dbo.NannyWorkingConditionNannyProfiles", "NannyWorkingCondition_Id", "dbo.NannyWorkingConditions");
            DropForeignKey("dbo.NannyWorkingConditions", "OwnerCountry_Iso", "dbo.Countries");
            DropForeignKey("dbo.PetCareWorkingSkillPetCareProfiles", "PetCareProfile_Id", "dbo.PetcareProfiles");
            DropForeignKey("dbo.PetCareWorkingSkillPetCareProfiles", "PetCareWorkingSkill_Id", "dbo.PetCareWorkingSkills");
            DropForeignKey("dbo.PetCareWorkingSkills", "OwnerCountry_Iso", "dbo.Countries");
            DropForeignKey("dbo.PetCareEducationPetCareProfiles", "PetCareProfile_Id", "dbo.PetcareProfiles");
            DropForeignKey("dbo.PetCareEducationPetCareProfiles", "PetCareEducation_Id", "dbo.PetCareEducations");
            DropForeignKey("dbo.PetCareEducations", "OwnerCountry_Iso", "dbo.Countries");
            DropForeignKey("dbo.NurseWorkingSkillNurseProfiles", "NurseProfile_Id", "dbo.NurseProfiles");
            DropForeignKey("dbo.NurseWorkingSkillNurseProfiles", "NurseWorkingSkill_Id", "dbo.NurseWorkingSkills");
            DropForeignKey("dbo.NurseWorkingSkills", "OwnerCountry_Iso", "dbo.Countries");
            DropForeignKey("dbo.NurseWorkingConditionNurseProfiles", "NurseProfile_Id", "dbo.NurseProfiles");
            DropForeignKey("dbo.NurseWorkingConditionNurseProfiles", "NurseWorkingCondition_Id", "dbo.NurseWorkingConditions");
            DropForeignKey("dbo.NurseWorkingConditions", "OwnerCountry_Iso", "dbo.Countries");
            DropForeignKey("dbo.NurseEducationNurseProfiles", "NurseProfile_Id", "dbo.NurseProfiles");
            DropForeignKey("dbo.NurseEducationNurseProfiles", "NurseEducation_Id", "dbo.NurseEducations");
            DropForeignKey("dbo.NurseEducations", "OwnerCountry_Iso", "dbo.Countries");
            DropForeignKey("dbo.AboutNurseNurseProfiles", "NurseProfile_Id", "dbo.NurseProfiles");
            DropForeignKey("dbo.AboutNurseNurseProfiles", "AboutNurse_Id", "dbo.AboutNurses");
            DropForeignKey("dbo.AboutNurses", "OwnerCountry_Iso", "dbo.Countries");
            DropForeignKey("dbo.TutorWorkingSkillTutorProfiles", "TutorProfile_Id", "dbo.TutorProfiles");
            DropForeignKey("dbo.TutorWorkingSkillTutorProfiles", "TutorWorkingSkill_Id", "dbo.TutorWorkingSkills");
            DropForeignKey("dbo.TutorWorkingSkills", "OwnerCountry_Iso", "dbo.Countries");
            DropForeignKey("dbo.TutorEducationTutorProfiles", "TutorProfile_Id", "dbo.TutorProfiles");
            DropForeignKey("dbo.TutorEducationTutorProfiles", "TutorEducation_Id", "dbo.TutorEducations");
            DropForeignKey("dbo.TutorEducations", "OwnerCountry_Iso", "dbo.Countries");
            DropForeignKey("dbo.AboutNannyNannyProfiles", "NannyProfile_Id", "dbo.NannyProfiles");
            DropForeignKey("dbo.AboutNannyNannyProfiles", "AboutNanny_Id", "dbo.AboutNannies");
            DropForeignKey("dbo.AboutNannies", "OwnerCountry_Iso", "dbo.Countries");
            DropForeignKey("dbo.HousekeeperProfileAboutHousekeepers", "AboutHousekeeper_Id", "dbo.AboutHousekeepers");
            DropForeignKey("dbo.HousekeeperProfileAboutHousekeepers", "HousekeeperProfile_Id", "dbo.HousekeeperProfiles");
            DropIndex("dbo.HousekeeperWorkingSkillHousekeeperProfiles", new[] { "HousekeeperProfile_Id" });
            DropIndex("dbo.HousekeeperWorkingSkillHousekeeperProfiles", new[] { "HousekeeperWorkingSkill_Id" });
            DropIndex("dbo.HousekeeperWorkingConditionHousekeeperProfiles", new[] { "HousekeeperProfile_Id" });
            DropIndex("dbo.HousekeeperWorkingConditionHousekeeperProfiles", new[] { "HousekeeperWorkingCondition_Id" });
            DropIndex("dbo.NannyWorkingSkillNannyProfiles", new[] { "NannyProfile_Id" });
            DropIndex("dbo.NannyWorkingSkillNannyProfiles", new[] { "NannyWorkingSkill_Id" });
            DropIndex("dbo.NannyWorkingConditionNannyProfiles", new[] { "NannyProfile_Id" });
            DropIndex("dbo.NannyWorkingConditionNannyProfiles", new[] { "NannyWorkingCondition_Id" });
            DropIndex("dbo.PetCareWorkingSkillPetCareProfiles", new[] { "PetCareProfile_Id" });
            DropIndex("dbo.PetCareWorkingSkillPetCareProfiles", new[] { "PetCareWorkingSkill_Id" });
            DropIndex("dbo.PetCareEducationPetCareProfiles", new[] { "PetCareProfile_Id" });
            DropIndex("dbo.PetCareEducationPetCareProfiles", new[] { "PetCareEducation_Id" });
            DropIndex("dbo.NurseWorkingSkillNurseProfiles", new[] { "NurseProfile_Id" });
            DropIndex("dbo.NurseWorkingSkillNurseProfiles", new[] { "NurseWorkingSkill_Id" });
            DropIndex("dbo.NurseWorkingConditionNurseProfiles", new[] { "NurseProfile_Id" });
            DropIndex("dbo.NurseWorkingConditionNurseProfiles", new[] { "NurseWorkingCondition_Id" });
            DropIndex("dbo.NurseEducationNurseProfiles", new[] { "NurseProfile_Id" });
            DropIndex("dbo.NurseEducationNurseProfiles", new[] { "NurseEducation_Id" });
            DropIndex("dbo.AboutNurseNurseProfiles", new[] { "NurseProfile_Id" });
            DropIndex("dbo.AboutNurseNurseProfiles", new[] { "AboutNurse_Id" });
            DropIndex("dbo.TutorWorkingSkillTutorProfiles", new[] { "TutorProfile_Id" });
            DropIndex("dbo.TutorWorkingSkillTutorProfiles", new[] { "TutorWorkingSkill_Id" });
            DropIndex("dbo.TutorEducationTutorProfiles", new[] { "TutorProfile_Id" });
            DropIndex("dbo.TutorEducationTutorProfiles", new[] { "TutorEducation_Id" });
            DropIndex("dbo.AboutNannyNannyProfiles", new[] { "NannyProfile_Id" });
            DropIndex("dbo.AboutNannyNannyProfiles", new[] { "AboutNanny_Id" });
            DropIndex("dbo.HousekeeperProfileAboutHousekeepers", new[] { "AboutHousekeeper_Id" });
            DropIndex("dbo.HousekeeperProfileAboutHousekeepers", new[] { "HousekeeperProfile_Id" });
            DropIndex("dbo.HousekeeperWorkingSkills", new[] { "OwnerCountry_Iso" });
            DropIndex("dbo.HousekeeperWorkingConditions", new[] { "OwnerCountry_Iso" });
            DropIndex("dbo.NannyWorkingSkills", new[] { "OwnerCountry_Iso" });
            DropIndex("dbo.NannyWorkingConditions", new[] { "OwnerCountry_Iso" });
            DropIndex("dbo.PetCareWorkingSkills", new[] { "OwnerCountry_Iso" });
            DropIndex("dbo.PetCareEducations", new[] { "OwnerCountry_Iso" });
            DropIndex("dbo.NurseWorkingSkills", new[] { "OwnerCountry_Iso" });
            DropIndex("dbo.NurseWorkingConditions", new[] { "OwnerCountry_Iso" });
            DropIndex("dbo.NurseEducations", new[] { "OwnerCountry_Iso" });
            DropIndex("dbo.AboutNurses", new[] { "OwnerCountry_Iso" });
            DropIndex("dbo.TutorWorkingSkills", new[] { "OwnerCountry_Iso" });
            DropIndex("dbo.TutorEducations", new[] { "OwnerCountry_Iso" });
            DropIndex("dbo.AboutNannies", new[] { "OwnerCountry_Iso" });
            DropIndex("dbo.AboutHousekeepers", new[] { "OwnerCountry_Iso" });
            DropTable("dbo.HousekeeperWorkingSkillHousekeeperProfiles");
            DropTable("dbo.HousekeeperWorkingConditionHousekeeperProfiles");
            DropTable("dbo.NannyWorkingSkillNannyProfiles");
            DropTable("dbo.NannyWorkingConditionNannyProfiles");
            DropTable("dbo.PetCareWorkingSkillPetCareProfiles");
            DropTable("dbo.PetCareEducationPetCareProfiles");
            DropTable("dbo.NurseWorkingSkillNurseProfiles");
            DropTable("dbo.NurseWorkingConditionNurseProfiles");
            DropTable("dbo.NurseEducationNurseProfiles");
            DropTable("dbo.AboutNurseNurseProfiles");
            DropTable("dbo.TutorWorkingSkillTutorProfiles");
            DropTable("dbo.TutorEducationTutorProfiles");
            DropTable("dbo.AboutNannyNannyProfiles");
            DropTable("dbo.HousekeeperProfileAboutHousekeepers");
            DropTable("dbo.HousekeeperWorkingSkills");
            DropTable("dbo.HousekeeperWorkingConditions");
            DropTable("dbo.NannyWorkingSkills");
            DropTable("dbo.NannyWorkingConditions");
            DropTable("dbo.PetCareWorkingSkills");
            DropTable("dbo.PetCareEducations");
            DropTable("dbo.NurseWorkingSkills");
            DropTable("dbo.NurseWorkingConditions");
            DropTable("dbo.NurseEducations");
            DropTable("dbo.AboutNurses");
            DropTable("dbo.TutorWorkingSkills");
            DropTable("dbo.TutorEducations");
            DropTable("dbo.AboutNannies");
            DropTable("dbo.AboutHousekeepers");
            RenameIndex(table: "dbo.NannyEducationNannyProfiles", name: "IX_NannyEducation_Id", newName: "IX_WorkingCondition_Id");
            RenameColumn(table: "dbo.NannyEducationNannyProfiles", name: "NannyEducation_Id", newName: "WorkingCondition_Id");
            CreateIndex("dbo.EducationTutorProfiles", "TutorProfile_Id");
            CreateIndex("dbo.EducationTutorProfiles", "Education_Id");
            CreateIndex("dbo.WorkingConditionNurseProfiles", "NurseProfile_Id");
            CreateIndex("dbo.WorkingConditionNurseProfiles", "WorkingCondition_Id");
            CreateIndex("dbo.WorkingConditionHousekeeperProfiles", "HousekeeperProfile_Id");
            CreateIndex("dbo.WorkingConditionHousekeeperProfiles", "WorkingCondition_Id");
            CreateIndex("dbo.PetCareProfileEducations", "Education_Id");
            CreateIndex("dbo.PetCareProfileEducations", "PetCareProfile_Id");
            CreateIndex("dbo.NurseProfileEducations", "Education_Id");
            CreateIndex("dbo.NurseProfileEducations", "NurseProfile_Id");
            CreateIndex("dbo.EducationNannyProfiles", "NannyProfile_Id");
            CreateIndex("dbo.EducationNannyProfiles", "Education_Id");
            CreateIndex("dbo.WorkingSkillWorkerProfiles", "WorkerProfile_Id");
            CreateIndex("dbo.WorkingSkillWorkerProfiles", "WorkingSkill_Id");
            CreateIndex("dbo.WorkerProfileAboutMes", "AboutMe_Id");
            CreateIndex("dbo.WorkerProfileAboutMes", "WorkerProfile_Id");
            CreateIndex("dbo.Educations", "OwnerCountry_Iso");
            CreateIndex("dbo.WorkingSkills", "OwnerCountry_Iso");
            CreateIndex("dbo.AboutMes", "OwnerCountry_Iso");
            AddForeignKey("dbo.AboutMes", "OwnerCountry_Iso", "dbo.Countries", "Iso");
            AddForeignKey("dbo.EducationTutorProfiles", "TutorProfile_Id", "dbo.TutorProfiles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EducationTutorProfiles", "Education_Id", "dbo.Educations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Educations", "OwnerCountry_Iso", "dbo.Countries", "Iso");
            AddForeignKey("dbo.WorkingConditionNurseProfiles", "NurseProfile_Id", "dbo.NurseProfiles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.WorkingConditionNurseProfiles", "WorkingCondition_Id", "dbo.WorkingConditions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.WorkingConditionHousekeeperProfiles", "HousekeeperProfile_Id", "dbo.HousekeeperProfiles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.WorkingConditionHousekeeperProfiles", "WorkingCondition_Id", "dbo.WorkingConditions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PetCareProfileEducations", "Education_Id", "dbo.Educations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PetCareProfileEducations", "PetCareProfile_Id", "dbo.PetcareProfiles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.NurseProfileEducations", "Education_Id", "dbo.Educations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.NurseProfileEducations", "NurseProfile_Id", "dbo.NurseProfiles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EducationNannyProfiles", "NannyProfile_Id", "dbo.NannyProfiles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EducationNannyProfiles", "Education_Id", "dbo.Educations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.WorkingSkillWorkerProfiles", "WorkerProfile_Id", "dbo.WorkerProfiles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.WorkingSkillWorkerProfiles", "WorkingSkill_Id", "dbo.WorkingSkills", "Id", cascadeDelete: true);
            AddForeignKey("dbo.WorkingSkills", "OwnerCountry_Iso", "dbo.Countries", "Iso");
            AddForeignKey("dbo.WorkerProfileAboutMes", "AboutMe_Id", "dbo.AboutMes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.WorkerProfileAboutMes", "WorkerProfile_Id", "dbo.WorkerProfiles", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.NannyEducationNannyProfiles", newName: "WorkingConditionNannyProfiles");
            RenameTable(name: "dbo.NannyEducations", newName: "WorkingConditions");
        }
    }
}
