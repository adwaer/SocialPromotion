using System.Collections.Generic;
using System.Linq;
using Nanny.Domain.Entities.Dictionaries;
using Nanny.Enums;

namespace Nanny.Dal.Seeds
{
    internal class WorkingConditionSeed
    {
        private readonly DefaultCtx _context;

        public WorkingConditionSeed(DefaultCtx context)
        {
            _context = context;
        }

        public void Execute()
        {
            if (!_context.NannyWorkingConditions.Any())
            {
                _context.NannyWorkingConditions.AddRange(new[]
                {
                    new NannyWorkingCondition
                    {
                        Disabled = false,
                        Name = "working_condition|with_animals"
                    },
                    new NannyWorkingCondition
                    {
                        Disabled = false,
                        Name = "working_condition|can_move"
                    },
                    new NannyWorkingCondition
                    {
                        Disabled = false,
                        Name = "working_condition|can_night"
                    },
                    new NannyWorkingCondition
                    {
                        Disabled = false,
                        Name = "working_condition|can_travel"
                    }
                });
            }

            if (!_context.NurseWorkingConditions.Any())
            {
                _context.NurseWorkingConditions.AddRange(new[]
                {
                    new NurseWorkingCondition
                    {
                        Disabled = false,
                        Name = "working_condition|with_animals"
                    },
                    new NurseWorkingCondition
                    {
                        Disabled = false,
                        Name = "working_condition|can_move"
                    },
                    new NurseWorkingCondition
                    {
                        Disabled = false,
                        Name = "working_condition|can_night"
                    },
                    new NurseWorkingCondition
                    {
                        Disabled = false,
                        Name = "working_condition|can_travel"
                    }
                });
            }

            if (!_context.HousekeeperWorkingConditions.Any())
            {
                _context.HousekeeperWorkingConditions.AddRange(new[]
                {
                    new HousekeeperWorkingCondition
                    {
                        Disabled = false,
                        Name = "working_condition|with_animals"
                    },
                    new HousekeeperWorkingCondition
                    {
                        Disabled = false,
                        Name = "working_condition|can_move"
                    }
                });
            }
        }

    }
}