using System;
using In_Memory_Caching.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace In_Memory_Caching.Services
{
    public class CachedVehicleService : IVehicleService
    {
        private const string VehicleListCacheKey = "VehicleList";
        private readonly IMemoryCache _memoryCache;
        private readonly IVehicleService _vehicleService;

        public CachedVehicleService(
            IVehicleService vehicleService,
            IMemoryCache memoryCache)
        {
            _vehicleService = vehicleService;
            _memoryCache = memoryCache;
        }

        public async Task<List<Vehicle>> GetAllAsync(CancellationToken ct)
        {
            var cacheOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromSeconds(10))
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(30));

            if (_memoryCache.TryGetValue(VehicleListCacheKey, out List<Vehicle> query))
                return query;

            query = await _vehicleService.GetAllAsync(ct);

            _memoryCache.Set(VehicleListCacheKey, query, cacheOptions);

            return query;
            
        }
    }
}

