using System.Runtime.Serialization;

namespace Nanny.Domain.Dto
{
    [DataContract]
    public class DictionaryDto
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "order")]
        public int Order { get; set; }
    }
}
