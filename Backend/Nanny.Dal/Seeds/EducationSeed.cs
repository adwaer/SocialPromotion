using System.Collections.Generic;
using System.Linq;
using Nanny.Domain.Entities.Dictionaries;
using Nanny.Enums;

namespace Nanny.Dal.Seeds
{
    internal class EducationSeed
    {
        private readonly DefaultCtx _context;

        public EducationSeed(DefaultCtx context)
        {
            _context = context;
        }

        public void Execute()
        {
            if (!_context.NannyEducations.Any())
            {
                _context.NannyEducations.AddRange(new[]
                {
                    new NannyEducation
                    {
                        Disabled = false,
                        Name = "education|high"
                    },
                    new NannyEducation
                    {
                        Disabled = false,
                        Name = "education|pedagogical"
                    },
                    new NannyEducation
                    {
                        Disabled = false,
                        Name = "education|medical"
                    },
                    new NannyEducation
                    {
                        Disabled = false,
                        Name = "education|сollege"
                    },
                    new NannyEducation
                    {
                        Disabled = false,
                        Name = "education|montessori"
                    },
                    new NannyEducation
                    {
                        Disabled = false,
                        Name = "education|nannies"
                    },
                    new NannyEducation
                    {
                        Disabled = false,
                        Name = "education|firstaid"
                    },
                    new NannyEducation
                    {
                        Disabled = false,
                        Name = "education|student"
                    }
                });

                if (!_context.NurseEducations.Any())
                {
                    _context.NurseEducations.AddRange(new[]
                    {
                        new NurseEducation
                        {
                            Disabled = false,
                            Name = "education|high"
                        },
                        new NurseEducation
                        {
                            Disabled = false,
                            Name = "education|medical"
                        },
                        new NurseEducation
                        {
                            Disabled = false,
                            Name = "education|сollege"
                        },
                        new NurseEducation
                        {
                            Disabled = false,
                            Name = "education|firstaid"
                        },
                        new NurseEducation
                        {
                            Disabled = false,
                            Name = "education|student"
                        },
                        new NurseEducation
                        {
                            Disabled = false,
                            Name = "education|carers_courses"
                        },
                        new NurseEducation
                        {
                            Disabled = false,
                            Name = "education|nurse_course"
                        }
                    });
                }
            }
        }
    }
}