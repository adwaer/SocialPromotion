using System.Runtime.Serialization;
using Nanny.Cqrs.Condition.Abstract;

namespace Nanny.Cqrs.Condition
{
    public class PagingContition : IPagingContition
    {
        [DataMember(Name = "page")]
        public int Page { get; set; }
        [DataMember(Name = "count")]
        public int Count { get; set; }
    }
}
