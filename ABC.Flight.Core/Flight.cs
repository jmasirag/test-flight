using ABC.Flight.Core.Common.Enum;
using ABC.Flight.Core.Models;
using ABC.Flight.Core.Models.Interfaces;
using ABC.Repository.Schema;
using System.Text.Json.Serialization;

namespace ABC.Flight.Core
{
    public partial class Flight : IFlight
    {
        DFWGateLoungeFlight _loungeFlight;
        private FlightTypeEnum type { get { return GetFlightType(); } }

        public string FlightType { get;  set; }
        public DateTime ScheduleDate { get; set; }
        public DateTime? ActTime { get; set; }
        public string ActualTime { get { return ActTime?.ToString() ?? string.Empty;  } }  
        public string AirlineCode { get; set; }
        public string FlightNumber { get; set; }
        public int FlightID { get; set; }
        public int ParentFlightID { get; set; }
        public bool IsAtGate { get; set; }
        public string ParentAirlineCode { get; set; }
        public int ParentFlightNumber { get; set; }
        public List<ChildFlight> ChildFlights { get; set; }
        public string AirportCode { get; set; }
        public string Remarks { get; set; }
        public string GateCode { get; set; }
        public Flight(DFWGateLoungeFlight loungeFlight, List<DFWGateLoungeFlight> dFWGateLoungeFlights)
        {
            _loungeFlight = loungeFlight;

            Map();
            PopulateAdditonalFields();
            PopulateChildFlights(dFWGateLoungeFlights);
        }

        public void PopulateAdditonalFields()
        {

            switch (type)
            {
                case FlightTypeEnum.Arrival:
                    this.Origin = _loungeFlight.city_name;
                    break;
                case FlightTypeEnum.Departure:
                    this.Destination = _loungeFlight.city_name;
                    this.GateID = _loungeFlight.gatecode;
                    this.IsBoardingTime = this.IsBoarding();
                    this.FlightStatus = this.GetFlightStatus();
                    break;

                default: throw new NotImplementedException();
            }
        }

        private void PopulateChildFlights(List<DFWGateLoungeFlight> dFWGateLoungeFlights)
        {
            ChildFlights = dFWGateLoungeFlights.Where(a => a.parentflightid == FlightID).Select(b => new ChildFlight()
            {
                AirlineCode = b.airlinecode,
                FlightNumber = b.flightnumber
            }).ToList();
        }

        private FlightTypeEnum GetFlightType()
        {
            switch (FlightType.ToUpperInvariant())
            {
                case "ARRIVAL":
                    return FlightTypeEnum.Arrival;
                case "DEPARTURE":
                    return FlightTypeEnum.Departure;
                default: throw new NotImplementedException();
            }
        }

        private string GetFlightTypeName(string n)
        {   string flightName = string.Empty; 

            switch (n.ToUpper())
            {
                case "ARR":
                    flightName = "ARRIVAL";
                    break;
                case "DEP":
                    flightName = "DEPARTURE";
                    break;
            }

            return flightName;
        }

      

        private void Map()
        {
            FlightType = GetFlightTypeName(_loungeFlight.arrdep);
            ScheduleDate = _loungeFlight.sched_time;
            ActTime = _loungeFlight.actual_time;
            AirlineCode = _loungeFlight.airlinecode;
            FlightID = _loungeFlight.flightid;
            ParentFlightID = _loungeFlight.parentflightid;
            IsAtGate = IsFlightAtGate();
            ParentAirlineCode = _loungeFlight.parentairlinecode;
            ParentFlightNumber = _loungeFlight.parentfltnumber;
            Remarks = _loungeFlight.remarks;
            GateCode = _loungeFlight.gatecode;
            AirportCode = _loungeFlight.airportcode;
        }

        private bool IsFlightAtGate()
        {
            bool isFlightAtGate = false;

            if(type == FlightTypeEnum.Departure && DateTime.Now < (ActTime ?? ScheduleDate)  )
            {
                isFlightAtGate = true;
            }else if(type == FlightTypeEnum.Arrival && DateTime.Now > (ActTime ?? ScheduleDate))
            {
                isFlightAtGate = true;
            }

            return isFlightAtGate;
        }

        public bool IsFlightDelayed(int delta)
        {
            TimeSpan timeSpan = (ActTime ?? DateTime.Now) - ScheduleDate;
            if (timeSpan.TotalMinutes >= delta)
                return true;

            return false;

        }
    }
}