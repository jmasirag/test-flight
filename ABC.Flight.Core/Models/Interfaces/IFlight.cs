using ABC.Flight.Core.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.Flight.Core.Models.Interfaces
{
    public interface IFlight
    {
        string FlightType{ get; set; }
        DateTime ScheduleDate { get; set; }
        string ActualTime { get; }
        string AirlineCode { get; set; }
        string FlightNumber { get; set; }
        int FlightID { get; set; }
        int ParentFlightID { get; set; }
        bool IsAtGate { get; set; }
        List<ChildFlight> ChildFlights { get; set; }
        bool IsFlightDelayed(int delta);
        string Origin { get; set; }
        string Destination { get; set; }
        string GateID { get; set; }
        bool? IsBoardingTime { get; set; }
        string FlightStatus { get; set; }
        string ParentAirlineCode { get; set; }
        int ParentFlightNumber { get; set; }
        string AirportCode { get; set; }
        string Remarks { get; set; }
        string GateCode { get; set; }
    }
}
