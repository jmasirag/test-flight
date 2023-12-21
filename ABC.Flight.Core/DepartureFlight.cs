using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ABC.Flight.Core
{
    public partial class Flight
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Destination { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? GateID { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IsBoardingTime { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? FlightStatus { get; set; } 

        public bool IsBoarding()
        {
            return (ActTime ?? ScheduleDate) > DateTime.Now;
        }

        public string GetFlightStatus()
        {
            return (IsBoardingTime?? false) ? "Boarding" : "Closed";
        }
    }
}
