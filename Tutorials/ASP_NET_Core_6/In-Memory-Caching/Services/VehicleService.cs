using System;
using In_Memory_Caching.Data;
using In_Memory_Caching.Entities;
using Microsoft.EntityFrameworkCore;

namespace In_Memory_Caching.Services
{
    public interface IVehicleService
    {
        Task<List<Vehicle>> GetAllAsync(CancellationToken ct);
    }

    public class VehicleService : IVehicleService
    {
        private readonly ApplicationDbContext _dbContext;

        public VehicleService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Vehicle>> GetAllAsync(CancellationToken ct)
        {
            var vehicles = await _dbContext.Vehicles
                .ToListAsync(ct);

            return vehicles;
        }
    }
}

