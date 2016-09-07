using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Nanny.Domain.Dto
{
    [DataContract]
    public class WorkersResponse
    {
        [DataMember(Name = "workers")]
        public IEnumerable<WorkerRelative> Workers { get; set; }
        [DataMember(Name = "count")]
        public int Count { get; set; }
    }
}
