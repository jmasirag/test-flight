

using System.Text.Json.Serialization;

namespace ABC.Repository.Schema
{
    public class DFWGateLoungeFlight
    {

        public string aircraftregnumber { get; set; }
        public int parentflightid { get; set; }
        public DateTime? remote_airport_sch_dtm { get; set; }
        public DateTime? remote_airport_act_dtm { get; set; }
        public string airportcode { get; set; }
        public object eventtime { get; set; }
        public string airlinecode { get; set; }
        public string parrentsuffix { get; set; }
        public string suffix { get; set; }
        public object viaairportcodes { get; set; }
        public DateTime sched_time { get; set; }
        public string arrdep { get; set; }
        public string bagbelt { get; set; }
        public string city_name { get; set; }
        public string flighttype { get; set; }
        public DateTime? remote_airport_est_dtm { get; set; }
        public object @event { get; set; }
        public string aircrafttype { get; set; }
        public object tail { get; set; }
        public int flightnumber { get; set; }
        public int flightid { get; set; }
        public string terminalcode { get; set; }
        public string airline_name { get; set; }
        public DateTime? actual_time { get; set; }
        public object flightstatuscode { get; set; }
        public string parentairlinecode { get; set; }
        public int parentfltnumber { get; set; }
        public string gatecode { get; set; }
        public string remarks { get; set; }
        public DateTime? estimated_time { get; set; }
        public object dep_boardingstart_dtm { get; set; }

    }

    public class MainObject
    {
        [JsonPropertyName("DFW GateLounge Flight List")]
        public List<DFWGateLoungeFlight> DFWGateLoungeFlightList { get; set; }
        public string status { get; set; }
    }

}