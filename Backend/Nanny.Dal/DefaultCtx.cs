using System.Data.Entity;
using System.Diagnostics;
using Nanny.Domain.Entities;
using Nanny.Domain.Entities.Dictionaries;
using Nanny.Domain.Entities.Localization;
using Nanny.Domain.Entities.Location;
using Nanny.Domain.Entities.Profiles;

namespace Nanny.Dal
{
    public class DefaultCtx : DbContext
    {
        public DefaultCtx()
            : base("ctx")
        {
#if DEBUG
            Database.Log = s => Debug.WriteLine(s);
#endif
        }

        public DbSet<EmailPublish> EmailPublishes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<AddressUnit> AddressUnits { get; set; }
        public DbSet<CustomerSearch> CustomerSearches { get; set; }
        public DbSet<Metro> Metroes { get; set; }
        public DbSet<LangResource> LangResources { get; set; }
        public DbSet<LangResourceValue> LangResourceValues { get; set; }
        public DbSet<LangCulture> LangCultures { get; set; }
        public DbSet<HttpDomain> HttpDomains { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<WorkingTerm> WorkingTerms { get; set; }
        public DbSet<WorkingExperienceAge> WorkingExperienceAges { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Liveinout> Liveinouts { get; set; }
        public DbSet<Employment> Employments { get; set; }
        public DbSet<ChildrenCount> ChildrenCounts { get; set; }
        public DbSet<Religion> Religions { get; set; }
        public DbSet<TeachingSubject> TeachingSubjects { get; set; }
        public DbSet<WorkingExperienceDiagnose> WorkingExperienceDiagnoses { get; set; }

        public DbSet<WorkerProfile> WorkerProfiles { get; set; }
        public DbSet<NannyProfile> NannyProfiles { get; set; }
        public DbSet<NurseProfile> NurseProfiles { get; set; }
        public DbSet<HousekeeperProfile> HousekeeperProfiles { get; set; }
        public DbSet<PetCareProfile> PetCareProfiles { get; set; }
        public DbSet<TutorProfile> TutorProfiles { get; set; }
        public DbSet<AboutNanny> AboutNannies { get; set; }
        public DbSet<AboutNurse> AboutNurses { get; set; }
        public DbSet<AboutHousekeeper> AboutHousekeepers { get; set; }
        public DbSet<NannyEducation> NannyEducations { get; set; }
        public DbSet<NurseEducation> NurseEducations { get; set; }
        public DbSet<PetCareEducation> PetCareEducations { get; set; }
        public DbSet<TutorEducation> TutorEducations { get; set; }
        public DbSet<NannyWorkingCondition> NannyWorkingConditions { get; set; }
        public DbSet<NurseWorkingCondition> NurseWorkingConditions { get; set; }
        public DbSet<HousekeeperWorkingCondition> HousekeeperWorkingConditions { get; set; }
        public DbSet<NannyWorkingSkill> NannyWorkingSkills { get; set; }
        public DbSet<NurseWorkingSkill> NurseWorkingSkills { get; set; }
        public DbSet<HousekeeperWorkingSkill> HousekeeperWorkingSkills { get; set; }
        public DbSet<PetCareWorkingSkill> PetCareWorkingSkills { get; set; }
        public DbSet<TutorWorkingSkill> TutorWorkingSkills { get; set; }

    }

}
