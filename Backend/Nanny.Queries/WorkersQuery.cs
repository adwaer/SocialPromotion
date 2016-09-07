using System;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Nanny.Cqrs;
using Nanny.Cqrs.Condition;
using Nanny.Domain.Dto;
using Nanny.Domain.Entities;

namespace Nanny.Queries
{
    public class WorkersQuery : IQuery<WorkersCriteria, Task<WorkersResponse>>
    {
        private readonly DbContext _dbContext;
        private readonly IMapper _mapper;
        public WorkersQuery(DbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<WorkersResponse> Execute(WorkersCriteria criteria)
        {
            await SaveRequest(criteria);

            IQueryable<Customer> workers = _dbContext.Set<Customer>();

            if (criteria.AgeFrom.HasValue)
            {
                workers = workers.Where(c => c.BirthDate.HasValue && c.BirthDate.Value.Year >= criteria.AgeFrom.Value);
            }
            if (criteria.AgeTo.HasValue)
            {
                workers = workers.Where(c => c.BirthDate.HasValue && c.BirthDate.Value.Year <= criteria.AgeTo.Value);
            }

            if (criteria.WorkerType.HasValue)
            {
                workers = workers.Where(c => c.SearchType == criteria.WorkerType.Value);
            }

            if (!criteria.DistanceUntil.HasValue || !criteria.DistanceLat.HasValue || !criteria.DistanceLng.HasValue)
            {
                throw new ArgumentNullException(nameof(criteria), "lat_or_lng_undefined");
            }

            var lat = criteria.DistanceLat.Value.ToString(CultureInfo.GetCultureInfo("en-GB"));
            var lng = criteria.DistanceLng.Value.ToString(CultureInfo.GetCultureInfo("en-GB"));
            var dbGeography = DbGeography.PointFromText($"POINT({lng:R} {lat:R})", 4326);

            /* lar range */
            var distance = criteria.DistanceUntil.Value * 1000;
            workers = CutLocationRange(distance, criteria.DistanceLat.Value, criteria.DistanceLng.Value, workers);


            workers = workers
                .Where(
                    c =>
                        c.Address.Details.Location.Distance(dbGeography) <= distance);

            return new WorkersResponse
            {
                Count = workers.Count(),
                Workers = workers
                    .Include(c => c.Address.Details)
                    .OrderBy(c => c.Address.Details.Location.Distance(dbGeography))
                    .Skip(criteria.Page*criteria.Count)
                    .Take(criteria.Count)
                    .ToArray()
                    .Select(c => WorkerRelative.Get(dbGeography, c))
            };
        }

        private static IQueryable<Customer> CutLocationRange(int meters, double lat, double lng, IQueryable<Customer> workers)
        {
            double radius = meters * 0.000621371192;
            double latRange = radius / ((6076 / 5280) * 60);
            double lngRange = radius / (((Math.Cos(lat * Math.PI / 180) * 6076) / 5280) * 60);
            var lowLat = lat - latRange;
            var highLat = lat + latRange;
            var lowLng = lng - lngRange;
            var highLng = lng + lngRange;

            Debug.WriteLine("CutLocationRange");
            Debug.WriteLine($"location: {lat} {lng}");
            Debug.WriteLine($"hight location: {highLat} {highLng}");
            Debug.WriteLine($"low location: {lowLat} {lowLng}");

            return workers
                .Where(w => w.Address.Details.Lat >= lowLat && w.Address.Details.Lat <= highLat
                            && w.Address.Details.Lng >= lowLng && w.Address.Details.Lng <= highLng);
        }

        private async Task SaveRequest(WorkersCriteria criteria)
        {
            _dbContext
                .Set<CustomerSearch>()
                .Add(_mapper.Map<CustomerSearch>(criteria));
            await _dbContext.SaveChangesAsync();
        }
    }
}
