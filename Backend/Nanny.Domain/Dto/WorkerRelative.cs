using System;
using System.Data.Entity.Spatial;
using System.Runtime.Serialization;
using Nanny.Domain.Entities;
using Nanny.Enums;

namespace Nanny.Domain.Dto
{
    [DataContract]
    public class WorkerRelative
    {
        [DataMember(Name = "customerId")]
        public int CustomerId { get; set; }
        [DataMember(Name = "distance")]
        public double? Distance { get; set; }
        [DataMember(Name = "birthYear")]
        public DateTime? BirthDate { get; set; }
        [DataMember(Name = "displayName")]
        public string DisplayName { get; set; }
        [DataMember(Name = "workerType")]
        public WorkerType WorkerType { get; set; }
        [DataMember(Name = "address")]
        public string Address { get; set; }

        public static WorkerRelative Get(DbGeography fromGeography, Customer customer)
        {
            var distance = customer.Address.Details.Location.Distance(fromGeography);
            if (distance.HasValue)
            {
                distance = Math.Round(distance.Value, 0);
            }

            return new WorkerRelative
            {
                CustomerId = customer.Id,
                BirthDate = customer.BirthDate,
                WorkerType = customer.SearchType,
                DisplayName = customer.DisplayName,
                Distance = distance,
                Address = $"{customer.Address?.City.Name} - {customer.Address?.Street.Name}"
            };
        }
    }
}
