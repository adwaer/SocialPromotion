using System.Data.Entity.Spatial;
using Adwaer.Entity;

namespace Nanny.Domain.Entities.Location
{
    public class AddressDetails : EntityBase<int>
    {
        public DbGeography Location { get; set; }
        public string Components { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string Url { get; set; }
        public string DetailsId { get; set; }
        public string PlaceId { get; set; }
        public string Reference { get; set; }
        public string Scope { get; set; }
        public string Types { get; set; }
        public string UtcOffset { get; set; }
    }
}
