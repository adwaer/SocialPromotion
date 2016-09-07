using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Adwaer.Identity.ViewModel;

namespace Nanny.WebApi.ViewModel
{
    [DataContract]
    public class RegistrationViewModel : IRegistrationModel
    {
        [Required]
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [Required]
        [DataMember(Name = "lastName")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [DataMember(Name = "email")]
        public string Email { get; set; }

        [Required]
        [DataMember(Name = "phone")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required]
        [DataMember(Name = "password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Required]
        [DataMember(Name = "customer")]
        public CustomerRegistrationViewModel Customer { get; set; }
    }
}
