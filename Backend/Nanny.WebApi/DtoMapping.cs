using System.Data.Entity.Spatial;
using System.Globalization;
using AutoMapper;
using Nanny.Cqrs.Condition;
using Nanny.Domain.Dto;
using Nanny.Domain.Entities;
using Nanny.Domain.Entities.Dictionaries;
using Nanny.Domain.Entities.Location;
using Nanny.WebApi.ViewModel;

namespace Nanny.WebApi
{
    class DtoMapping
    {
        public static IMapper Register()
        {
            var config = new MapperConfiguration(configuration =>
            {
                configuration
                    .CreateMap<RegistrationViewModel, SimpleCustomerAccount>()
                    .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => $"{src.Name} {src.LastName}"))
                    .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Phone));

                configuration
                    .CreateMap<CustomerRegistrationViewModel, Customer>()
                    .ForMember(dest => dest.SearchType, opt => opt.MapFrom(src => src.SearchType))
                    .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
                    .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));

                configuration
                    .CreateMap<AddressViewModel, Address>()
                    .ForMember(dest => dest.City, opt => opt.Ignore())
                    .ForMember(dest => dest.Home, opt => opt.Ignore())
                    .ForMember(dest => dest.Postal, opt => opt.Ignore())
                    .ForMember(dest => dest.Street, opt => opt.Ignore())
                    .ForMember(dest => dest.AddressUnits, opt => opt.MapFrom(src => src.UnitsAddressUnitViewModels));

                configuration
                    .CreateMap<AddressDetailsViewModel, AddressDetails>()
                    .ForMember(dest => dest.Location,
                        opt => opt.MapFrom(src => DbGeography.PointFromText($"POINT({src.Lng.ToString(CultureInfo.GetCultureInfo("en-GB")):R} {src.Lat.ToString(CultureInfo.GetCultureInfo("en-GB")):R})", 4326)));

                configuration
                    .CreateMap<AddressUnitViewModel, AddressUnit>();
                configuration
                    .CreateMap<AddressUnit, AddressUnitViewModel>();
                configuration
                    .CreateMap<AddressDetailsViewModel, AddressDetails>();
                configuration
                    .CreateMap<WorkersCriteria, CustomerSearch>();
                configuration
                    .CreateMap<NannyEducation, DictionaryDto>();

                configuration
                    .CreateMap<Metro, MetroDto>();

                configuration.CreateProfile("identity");
            });

            return config.CreateMapper();
        }
    }
}
