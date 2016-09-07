using System.Runtime.Serialization;
using Nanny.Cqrs.Condition.Abstract;
using Nanny.Enums;

namespace Nanny.Cqrs.Condition
{
    [DataContract]
    public class WorkersCriteria : PagingContition, IWorkersCondition
    {
        [DataMember(Name = "ageFrom")]
        public int? AgeFrom { get; set; }
        [DataMember(Name = "ageTo")]
        public int? AgeTo { get; set; }

        [DataMember(Name = "distanceLat")]
        public double? DistanceLat { get; set; }

        [DataMember(Name = "distanceLng")]
        public double? DistanceLng { get; set; }

        [DataMember(Name = "distanceUntil")]
        public int? DistanceUntil { get; set; }
        [DataMember(Name = "workerType")]
        public WorkerType? WorkerType { get; set; }
    }
}