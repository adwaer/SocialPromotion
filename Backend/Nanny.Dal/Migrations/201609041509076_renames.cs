namespace Nanny.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renames : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ZoonyanyaProfiles", newName: "PetcareProfiles");
            RenameTable(name: "dbo.Worships", newName: "Religions");
            RenameTable(name: "dbo.Residences", newName: "Liveinouts");
            RenameTable(name: "dbo.AnimalTypeZoonyanyaProfiles", newName: "AnimalTypePetCareProfiles");
            RenameTable(name: "dbo.ZoonyanyaProfileEducations", newName: "PetCareProfileEducations");
            RenameColumn(table: "dbo.WorkerProfiles", name: "Worship_Id", newName: "Religion_Id");
            RenameColumn(table: "dbo.HousekeeperProfiles", name: "Residence_Id", newName: "Liveinout_Id");
            RenameColumn(table: "dbo.NannyProfiles", name: "Residence_Id", newName: "Liveinout_Id");
            RenameColumn(table: "dbo.NurseProfiles", name: "Residence_Id", newName: "Liveinout_Id");
            RenameColumn(table: "dbo.AnimalTypePetCareProfiles", name: "ZoonyanyaProfile_Id", newName: "PetCareProfile_Id");
            RenameColumn(table: "dbo.PetCareProfileEducations", name: "ZoonyanyaProfile_Id", newName: "PetCareProfile_Id");
            RenameColumn(table: "dbo.PetcareProfiles", name: "Residence_Id", newName: "Liveinout_Id");
            RenameIndex(table: "dbo.WorkerProfiles", name: "IX_Worship_Id", newName: "IX_Religion_Id");
            RenameIndex(table: "dbo.AnimalTypePetCareProfiles", name: "IX_ZoonyanyaProfile_Id", newName: "IX_PetCareProfile_Id");
            RenameIndex(table: "dbo.PetCareProfileEducations", name: "IX_ZoonyanyaProfile_Id", newName: "IX_PetCareProfile_Id");
            RenameIndex(table: "dbo.NannyProfiles", name: "IX_Residence_Id", newName: "IX_Liveinout_Id");
            RenameIndex(table: "dbo.PetcareProfiles", name: "IX_Residence_Id", newName: "IX_Liveinout_Id");
            RenameIndex(table: "dbo.HousekeeperProfiles", name: "IX_Residence_Id", newName: "IX_Liveinout_Id");
            RenameIndex(table: "dbo.NurseProfiles", name: "IX_Residence_Id", newName: "IX_Liveinout_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.NurseProfiles", name: "IX_Liveinout_Id", newName: "IX_Residence_Id");
            RenameIndex(table: "dbo.HousekeeperProfiles", name: "IX_Liveinout_Id", newName: "IX_Residence_Id");
            RenameIndex(table: "dbo.PetcareProfiles", name: "IX_Liveinout_Id", newName: "IX_Residence_Id");
            RenameIndex(table: "dbo.NannyProfiles", name: "IX_Liveinout_Id", newName: "IX_Residence_Id");
            RenameIndex(table: "dbo.PetCareProfileEducations", name: "IX_PetCareProfile_Id", newName: "IX_ZoonyanyaProfile_Id");
            RenameIndex(table: "dbo.AnimalTypePetCareProfiles", name: "IX_PetCareProfile_Id", newName: "IX_ZoonyanyaProfile_Id");
            RenameIndex(table: "dbo.WorkerProfiles", name: "IX_Religion_Id", newName: "IX_Worship_Id");
            RenameColumn(table: "dbo.PetcareProfiles", name: "Liveinout_Id", newName: "Residence_Id");
            RenameColumn(table: "dbo.PetCareProfileEducations", name: "PetCareProfile_Id", newName: "ZoonyanyaProfile_Id");
            RenameColumn(table: "dbo.AnimalTypePetCareProfiles", name: "PetCareProfile_Id", newName: "ZoonyanyaProfile_Id");
            RenameColumn(table: "dbo.NurseProfiles", name: "Liveinout_Id", newName: "Residence_Id");
            RenameColumn(table: "dbo.NannyProfiles", name: "Liveinout_Id", newName: "Residence_Id");
            RenameColumn(table: "dbo.HousekeeperProfiles", name: "Liveinout_Id", newName: "Residence_Id");
            RenameColumn(table: "dbo.WorkerProfiles", name: "Religion_Id", newName: "Worship_Id");
            RenameTable(name: "dbo.PetCareProfileEducations", newName: "ZoonyanyaProfileEducations");
            RenameTable(name: "dbo.AnimalTypePetCareProfiles", newName: "AnimalTypeZoonyanyaProfiles");
            RenameTable(name: "dbo.Liveinouts", newName: "Residences");
            RenameTable(name: "dbo.Religions", newName: "Worships");
            RenameTable(name: "dbo.PetcareProfiles", newName: "ZoonyanyaProfiles");
        }
    }
}
