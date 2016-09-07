using Nanny.Enums;

namespace Nanny.Cqrs.Condition.Abstract
{
    public interface IWorkersCondition : IPagingContition
    {
        int? AgeFrom { get; set; }
        int? AgeTo { get; set; }
        double? DistanceLat { get; set; }
        double? DistanceLng { get; set; }
        int? DistanceUntil { get; set; }
        WorkerType? WorkerType { get; set; }
    }
}