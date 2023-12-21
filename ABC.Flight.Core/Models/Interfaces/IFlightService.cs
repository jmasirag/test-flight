using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.Flight.Core.Models.Interfaces
{
    public interface IFlightService
    {
        string GetFlightStatus(int flightID);
        IEnumerable<IFlight> GetActiveFlightAtGate();
        IEnumerable<IFlight> GetDelayedFlightByDelta(int delta);
    }
}
