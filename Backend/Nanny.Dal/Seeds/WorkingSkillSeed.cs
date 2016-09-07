using System.Collections.Generic;
using System.Linq;
using Nanny.Domain.Entities.Dictionaries;
using Nanny.Enums;

namespace Nanny.Dal.Seeds
{
    internal class WorkingSkillSeed
    {
        private readonly DefaultCtx _context;

        public WorkingSkillSeed(DefaultCtx context)
        {
            _context = context;
        }

        public void Execute()
        {
            if (!_context.NannyWorkingSkills.Any())
            {
                _context.NannyWorkingSkills.AddRange(new[]
                {
                    new NannyWorkingSkill
                    {
                        Disabled = false,
                        Name = "working_skills|with_disabled"
                    },
                    new NannyWorkingSkill
                    {
                        Disabled = false,
                        Name = "working_skills|home_works"
                    },
                    new NannyWorkingSkill
                    {
                        Disabled = false,
                        Name = "working_skills|clean_room"
                    },
                    new NannyWorkingSkill
                    {
                        Disabled = false,
                        Name = "working_skills|events"
                    },
                    new NannyWorkingSkill
                    {
                        Disabled = false,
                        Name = "working_skills|care"
                    },
                    new NannyWorkingSkill
                    {
                        Disabled = false,
                        Name = "working_skills|bathing"
                    },
                    new NannyWorkingSkill
                    {
                        Disabled = false,
                        Name = "working_skills|accompnying"
                    },
                    new NannyWorkingSkill
                    {
                        Disabled = false,
                        Name = "working_skills|cooking"
                    },
                    new NannyWorkingSkill
                    {
                        Disabled = false,
                        Name = "working_skills|clean_home"
                    },
                    new NannyWorkingSkill
                    {
                        Disabled = false,
                        Name = "working_skills|keeping_order"
                    },
                    new NannyWorkingSkill
                    {
                        Disabled = false,
                        Name = "working_skills|clothes_iron"
                    },
                    new NannyWorkingSkill
                    {
                        Disabled = false,
                        Name = "working_skills|buying_products"
                    },
                    new NannyWorkingSkill
                    {
                        Disabled = false,
                        Name = "working_skills|care_pet"
                    },
                    new NannyWorkingSkill
                    {
                        Disabled = false,
                        Name = "working_skills|plant_care"
                    },
                });
            }
            if (!_context.NurseWorkingSkills.Any())
            {
                _context.NurseWorkingSkills.AddRange(new[]
                {
                    new NurseWorkingSkill
                    {
                        Disabled = false,
                        Name = "working_skills|sport_physiotherapy"
                    },
                    new NurseWorkingSkill
                    {
                        Disabled = false,
                        Name = "working_skills|tube_feeding_diet"
                    },
                    new NurseWorkingSkill
                    {
                        Disabled = false,
                        Name = "working_skills|patient_movement"
                    },
                    new NurseWorkingSkill
                    {
                        Disabled = false,
                        Name = "working_skills|help_change_catheter"
                    },
                });
            }

            if (!_context.HousekeeperWorkingSkills.Any())
            {
                _context.HousekeeperWorkingSkills.AddRange(new[]
                {
                    new HousekeeperWorkingSkill
                    {
                        Disabled = false,
                        Name = "working_skills|cooking"
                    },
                    new HousekeeperWorkingSkill
                    {
                        Disabled = false,
                        Name = "working_skills|clean_home"
                    },
                    new HousekeeperWorkingSkill
                    {
                        Disabled = false,
                        Name = "working_skills|keeping_order"
                    },
                    new HousekeeperWorkingSkill
                    {
                        Disabled = false,
                        Name = "working_skills|clothes_iron"
                    },
                    new HousekeeperWorkingSkill
                    {
                        Disabled = false,
                        Name = "working_skills|buying_products"
                    },
                    new HousekeeperWorkingSkill
                    {
                        Disabled = false,
                        Name = "working_skills|care_pet"
                    },
                    new HousekeeperWorkingSkill
                    {
                        Disabled = false,
                        Name = "working_skills|plant_care"
                    },
                    new HousekeeperWorkingSkill
                    {
                        Disabled = false,
                        Name = "working_skills|reception_desk"
                    },
                    new HousekeeperWorkingSkill
                    {
                        Disabled = false,
                        Name = "working_skills|accounting_expenses_paying_bills"
                    },
                    new HousekeeperWorkingSkill
                    {
                        Disabled = false,
                        Name = "working_skills|controlling_other_domestic_workers"
                    },
                    new HousekeeperWorkingSkill
                    {
                        Disabled = false,
                        Name = "working_skills|own_equipment_harvesting"
                    },
                    new HousekeeperWorkingSkill
                    {
                        Disabled = false,
                        Name = "working_skills|own_detergents"
                    },
                    new HousekeeperWorkingSkill
                    {
                        Disabled = false,
                        Name = "working_skills|babysitting"
                    },
                    new HousekeeperWorkingSkill
                    {
                        Disabled = false,
                        Name = "working_skills|help_sick_and_elderly"
                    }
                });
            }
        }
    }
}