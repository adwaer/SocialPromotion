using System;
using System.Diagnostics;
using Nanny.Dal.Seeds;
using Nanny.Domain.Entities.Dictionaries;
using Nanny.Domain.Entities.Localization;

namespace Nanny.Dal.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DefaultCtx>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DefaultCtx context)
        {
            //Debugger.Launch();
            try
            {
                var cultureSeed = new CultureSeed(context);
                var langSeed = new LanguageSeed(context);
                var countrySeed = new ContrySeed(context, cultureSeed, langSeed);
                var domainSeed = new HttpDomainSeed(context);
                var educationSeed = new EducationSeed(context);
                var workingTermsSeed = new WorkingTermsSeed(context);
                var workingSkillSeed = new WorkingSkillSeed(context);
                var residenceSeed = new LiveinoutSeed(context);
                var employmentSeed = new EmploymentSeed(context);
                var childrenCountSeed = new ChildrenCountSeed(context);
                var worshipSeed = new ReligionSeed(context);
                var aboutNannySeed = new AboutNannySeed(context);
                var aboutNurseSeed = new AboutNurseSeed(context);
                var aboutHousekeeperSeed = new AboutHousekeeperSeed(context);
                var workingConditionSeed = new WorkingConditionSeed(context);

                countrySeed.Execute();
                langSeed.Execute();
                domainSeed.Execute();
                educationSeed.Execute();
                workingTermsSeed.Execute();
                workingSkillSeed.Execute();
                residenceSeed.Execute();
                employmentSeed.Execute();
                childrenCountSeed.Execute();
                worshipSeed.Execute();
                aboutNannySeed.Execute();
                aboutNurseSeed.Execute();
                aboutHousekeeperSeed.Execute();
                workingConditionSeed.Execute();

                if (context.Metroes.Any())
                {
                    return;
                }

                var enLangCulture = langSeed.GetCulture("en-US", "languages|english");

                var ruLr = new LangResource
                {
                    Name = "metro",
                    Culture = enLangCulture,
                    Values = new[]
                    {
                        new LangResourceValue
                        {
                            Key = "kazan_prospect_pobedy",
                            Value = "Pobedy prospeck"
                        },
                        new LangResourceValue
                        {
                            Key = "kazan_gorky",
                            Value = "Gorky"
                        },
                        new LangResourceValue
                        {
                            Key = "kazan_ametievo",
                            Value = "Ametievo"
                        },
                        new LangResourceValue
                        {
                            Key = "kazan_sukonnaya_sloboda",
                            Value = "Sukonnaya Sloboda"
                        },
                        new LangResourceValue
                        {
                            Key = "kazan_ploshad_tukaya",
                            Value = "Ploshad turaya"
                        },
                        new LangResourceValue
                        {
                            Key = "kazan_kremlin",
                            Value = "Kremlin"
                        },
                        new LangResourceValue
                        {
                            Key = "kazan_kozia_sloboda",
                            Value = "Kozia Sloboda"
                        },
                        new LangResourceValue
                        {
                            Key = "kazan_yashlek",
                            Value = "Yashlek"
                        },
                        new LangResourceValue
                        {
                            Key = "kazan_severny_vokzal",
                            Value = "Severny Vokzal"
                        },
                        new LangResourceValue
                        {
                            Key = "kazan_aviastroy",
                            Value = "Aviastroy"
                        },
                        new LangResourceValue
                        {
                            Key = "moscow_tverskaya",
                            Value = "Tverskaya"
                        }
                    }
                };

                context.LangResources.RemoveRange(context.LangResources);
                context.LangResources.Add(ruLr);

                context.LangResources.Add(new LangResource
                {
                    Culture = enLangCulture,
                    Name = "workers",
                    Values = new[]
                    {
                        new LangResourceValue
                        {
                            Key = "range_until",
                            Value = "Range until"
                        },
                        new LangResourceValue
                        {
                            Key = "search_result",
                            Value = "Search Results"
                        },
                        new LangResourceValue
                        {
                            Key = "filters_me",
                            Value = "me"
                        },
                        new LangResourceValue
                        {
                            Key = "filters_address",
                            Value = "address"
                        },
                        new LangResourceValue
                        {
                            Key = "filters_metro",
                            Value = "metro"
                        },
                        new LangResourceValue
                        {
                            Key = "filters_apply",
                            Value = "Apply"
                        },
                        new LangResourceValue
                        {
                            Key = "on_range",
                            Value = "On range"
                        },
                        new LangResourceValue
                        {
                            Key = "workerType_nannywork",
                            Value = "Nanny"
                        },
                        new LangResourceValue
                        {
                            Key = "workerType_nursework",
                            Value = "Nurse"
                        },
                        new LangResourceValue
                        {
                            Key = "workerType_housekeeperwork",
                            Value = "Housekeeper"
                        },
                        new LangResourceValue
                        {
                            Key = "workerType_nanny",
                            Value = "Nanny"
                        },
                        new LangResourceValue
                        {
                            Key = "workerType_nurse",
                            Value = "Nurse"
                        },
                        new LangResourceValue
                        {
                            Key = "workerType_housekeeper",
                            Value = "Housekeeper"
                        },
                    }
                });

                context.LangResources.Add(new LangResource
                {
                    Name = "landing",
                    Culture = enLangCulture,
                    Values = new[]
                    {
                        new LangResourceValue
                        {
                            Key = "brand",
                            Value = "Nanny"
                        }
                    }
                });

                context.LangResources.Add(new LangResource
                {
                    Name = "common",
                    Culture = enLangCulture,
                    Values = new[]
                    {
                        new LangResourceValue
                        {
                            Key = "in",
                            Value = "In"
                        },
                        new LangResourceValue
                        {
                            Key = "from",
                            Value = "from"
                        },
                        new LangResourceValue
                        {
                            Key = "kilometers",
                            Value = "km"
                        },
                        new LangResourceValue
                        {
                            Key = "meters",
                            Value = "m."
                        },
                        new LangResourceValue
                        {
                            Key = "logon",
                            Value = "LogOn."
                        }
                    }
                });

                context.Metroes.Add(new Metro
                {
                    Name = "metro|kazan_prospect_pobedy",
                    Lat = 55.74982583593993,
                    Lng = 49.208557284200076,
                    OwnerCountry_Iso = "RU"
                });
                context.Metroes.Add(new Metro
                {
                    Name = "metro|kazan_gorky",
                    Lat = 55.759477669771954,
                    Lng = 49.19215638320032,
                    OwnerCountry_Iso = "RU"
                });
                context.Metroes.Add(new Metro
                {
                    Name = "metro|kazan_ametievo",
                    Lat = 55.76497036834872,
                    Lng = 49.166578838034305,
                    OwnerCountry_Iso = "RU"
                });
                context.Metroes.Add(new Metro
                {
                    Name = "metro|kazan_sukonnaya_sloboda",
                    Lat = 55.77693044535312,
                    Lng = 49.14235202678089,
                    OwnerCountry_Iso = "RU"
                });
                context.Metroes.Add(new Metro
                {
                    Name = "metro|kazan_ploshad_tukaya",
                    Lat = 55.78654860581989,
                    Lng = 49.12337271579151,
                    OwnerCountry_Iso = "RU"
                });
                context.Metroes.Add(new Metro
                {
                    Name = "metro|kazan_kremlin",
                    Lat = 55.795829292769206,
                    Lng = 49.106142833648505,
                    OwnerCountry_Iso = "RU"
                });
                context.Metroes.Add(new Metro
                {
                    Name = "metro|kazan_kozia_sloboda",
                    Lat = 55.8304307,
                    Lng = 49.06608060000008,
                    OwnerCountry_Iso = "RU"
                });
                context.Metroes.Add(new Metro
                {
                    Name = "metro|kazan_yashlek",
                    Lat = 55.817156,
                    Lng = 49.09857099999999,
                    OwnerCountry_Iso = "RU"
                });
                context.Metroes.Add(new Metro
                {
                    Name = "metro|kazan_severny_vokzal",
                    Lat = 55.84159170224533,
                    Lng = 49.0821988303947,
                    OwnerCountry_Iso = "RU"
                });
                context.Metroes.Add(new Metro
                {
                    Name = "metro|kazan_aviastroy",
                    Lat = 55.85560589324356,
                    Lng = 49.08437007464978,
                    OwnerCountry_Iso = "RU"
                });

                context.Metroes.Add(new Metro
                {
                    Name = "metro|moscow_tverskaya",
                    Lat = 55.7644550,
                    Lng = 37.6059390,
                    OwnerCountry_Iso = "RU"
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

    }
}
