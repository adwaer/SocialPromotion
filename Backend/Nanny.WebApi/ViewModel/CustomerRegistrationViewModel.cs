using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Nanny.Enums;
using Nanny.WebApi.Attributes;

namespace Nanny.WebApi.ViewModel
{
    public class CustomerRegistrationViewModel
    {
        [DataMember(Name = "birthDate"), ValidateDate]
        public DateTime? BirthDate { get; set; }

        [Required]
        [DataMember(Name = "searchType")]
        public WorkerType SearchType { get; set; }

        [DataMember(Name = "addressJson", IsRequired = true), Display(Name = "Адрес")]
        public string AddressJson { get; set; }

        public string DisplayName { get; set; }
        public AddressViewModel Address { get; set; }
    }
}
