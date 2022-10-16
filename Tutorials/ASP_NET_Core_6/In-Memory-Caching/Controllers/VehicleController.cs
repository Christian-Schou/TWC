using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using In_Memory_Caching.Entities;
using In_Memory_Caching.Services;
using Microsoft.AspNetCore.Mvc;

namespace In_Memory_Caching.Controllers
{
    [Route("api/[controller]")]
    public class VehicleController : Controller
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Vehicle> vehicles = await _vehicleService.GetAllAsync();

            return Ok(vehicles);
        }
    }
}

