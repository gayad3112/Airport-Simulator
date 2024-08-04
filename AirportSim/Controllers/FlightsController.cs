using AirportSim.Models;
using AirportSim.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AirportSim.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAllOrigins")]
    public class FlightsController : Controller
    {
        private readonly FlightService service;
        public FlightsController(FlightService service) => this.service = service;

        [HttpGet]
        public ICollection<Log> GetLogs(int startingId = 0) => service.GetLogs(startingId);
        [HttpPost]
        public void AddFlight(Flight flight) => service.HandleFlight(flight);

    }

}
