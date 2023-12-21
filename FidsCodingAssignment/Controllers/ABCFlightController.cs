using ABC.Flight.Core;
using ABC.Flight.Core.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FidsCodingAssignment.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ABCFlightController : ControllerBase
    {
        IFlightService _flightService;
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        public ABCFlightController(IFlightService flightService) {
            _flightService = flightService;
            
        }

        

        // GET api/<ABCFlightController>/5
        [HttpGet( "GetFlightStatus")]
        public string GetFlightStatus(int flightID)
        {
            return JsonSerializer.Serialize( new { status = _flightService.GetFlightStatus(flightID) , options });
        }

        [HttpGet("GetActiveFlightAtGate")]
        public string GetActiveFlightAtGate()
        {
            return JsonSerializer.Serialize(_flightService.GetActiveFlightAtGate(), options);
        }

        [HttpGet("GetDelayedFlightByDelta")]
        public string GetDelayedFlightByDelta(int deltaInMinute)
        {
            return JsonSerializer.Serialize(_flightService.GetDelayedFlightByDelta(deltaInMinute), options);
        }

    }
}
