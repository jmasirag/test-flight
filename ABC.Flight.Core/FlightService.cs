using ABC.Flight.Core.Models.Interfaces;
using ABC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.Flight.Core
{
    public class FlightService : IFlightService
    {
        private IABCDatabase _aBCDatabase;
        public FlightService(IABCDatabase aBCDatabase)
        {
            _aBCDatabase = aBCDatabase;
        }
        public IEnumerable<IFlight> GetActiveFlightAtGate()
        {
            IEnumerable<IFlight> flights = _aBCDatabase.DFWGateLoungeFlight.Select(a => new Flight(a, _aBCDatabase.DFWGateLoungeFlight)).ToList();

            return flights.Where(a=> a.IsAtGate).ToList();
        }

        public IEnumerable<IFlight> GetDelayedFlightByDelta(int delta)
        {
            IEnumerable<IFlight> flights = _aBCDatabase.DFWGateLoungeFlight.Select(a => new Flight(a, _aBCDatabase.DFWGateLoungeFlight)).ToList();
            return flights.Where(a => a.IsFlightDelayed(delta)).ToList();
        }

        public string GetFlightStatus(int flightID)
        {
            var rec = _aBCDatabase.DFWGateLoungeFlight.FirstOrDefault(a => a.flightid == flightID);

            if (rec == null)
                return string.Empty;

            return new Flight(rec, _aBCDatabase.DFWGateLoungeFlight).FlightStatus;

        }
    }
}
