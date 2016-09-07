using Adwaer.Entity;
using Nanny.Cqrs.Condition.Abstract;
using Nanny.Enums;

namespace Nanny.Domain.Entities
{
    public class CustomerSearch : EntityBase<long>, IWorkersCondition
    {
        public int Count { get; set; }
        public int Page { get; set; }
        public int? AgeFrom { get; set; }
        public int? AgeTo { get; set; }
        public double? DistanceLat { get; set; }
        public double? DistanceLng { get; set; }
        public int? DistanceUntil { get; set; }
        public WorkerType? WorkerType { get; set; }
    }
}
