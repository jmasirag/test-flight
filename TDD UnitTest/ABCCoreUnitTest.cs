using ABC.Flight.Core.Common.Enum;
using ABC.Repository;


namespace TDD_UnitTest
{
    [TestFixture]
    public class ABCCoreUnitTest
    {
        private ABCDatabase db; 
       
        [SetUp]
        public void Start() {
            db = new ABCDatabase();
        }

        #region Specify Flight Type 
        [TestCase(0, "DEP", "DEPARTURE")]
        [TestCase(1, "ARR", "ARRIVAL")]
        public void DetermineWhetherFlighIsArrivalOrDeparture(int flightType, string strFlight, string result)
        {
            var mockDataJson = db.DFWGateLoungeFlight.FirstOrDefault(a => a.arrdep.ToUpperInvariant() == strFlight);

            ABC.Flight.Core.Flight flight = new ABC.Flight.Core.Flight(mockDataJson, db.DFWGateLoungeFlight);
     
            Assert.AreEqual(flight.FlightType, result);

        }


        [TestCase(1, "DEPs")]
        public void WhenFlightTypeIsnotExistsApplicationShouldThrowException(int flightType, string strFlight)
        {
            try
            {
                var mockDataJson = db.DFWGateLoungeFlight.FirstOrDefault();

               ABC.Flight.Core.Flight flight = new ABC.Flight.Core.Flight(mockDataJson, db.DFWGateLoungeFlight);
                flight.FlightType = strFlight;
             

                Assert.Fail();

            }
            catch
            {
                Assert.Pass();
            }

        }

        #endregion Specify Flight Type 

        #region Bording Time

        [TestCase(1)]
        [TestCase(0.2)]
        public void DepartureBoardingShouldReturnTrue(double hour)
        {
            var mockDataJson = db.DFWGateLoungeFlight.FirstOrDefault();
            mockDataJson.actual_time = DateTime.Now.AddHours(hour);

            ABC.Flight.Core.Flight flight = new ABC.Flight.Core.Flight(mockDataJson, db.DFWGateLoungeFlight);
            flight.IsBoardingTime = flight.IsBoarding();

            Assert.True(flight.IsBoardingTime);
        }

        [TestCase(-1)]
        
        public void DepartureBoardingShouldReturnFalse(int hour)
        {
            var mockDataJson = db.DFWGateLoungeFlight.FirstOrDefault();
            mockDataJson.actual_time = DateTime.Now.AddHours(hour);

            ABC.Flight.Core.Flight flight = new ABC.Flight.Core.Flight(mockDataJson, db.DFWGateLoungeFlight);
            flight.IsBoardingTime = flight.IsBoarding();

            Assert.False(flight.IsBoardingTime);


        }
        #endregion Bording Time


        #region Flight is At Gate 

        [TestCase(1, "DEP")]
        [TestCase(-1, "ARR")]
        public void DetermineIfFlightIsAtAgeForArrivalDeparture_ShouldReturnTrue(double hour, string fType)
        {
            var mockDataJson = db.DFWGateLoungeFlight.FirstOrDefault();
            mockDataJson.actual_time = DateTime.Now.AddHours(hour);
            mockDataJson.arrdep = fType;

            ABC.Flight.Core.Flight flight = new ABC.Flight.Core.Flight(mockDataJson, db.DFWGateLoungeFlight);


            Assert.True(flight.IsAtGate);
        }

        [TestCase(-1, "DEP")]
        [TestCase(1, "ARR")]
        public void DetermineIfFlightIsAtAgeForArrivalDeparture_ShouldReturnFalse(double hour, string fType)
        {
            var mockDataJson = db.DFWGateLoungeFlight.FirstOrDefault();
            mockDataJson.actual_time = DateTime.Now.AddHours(hour);
            mockDataJson.arrdep = fType;

            ABC.Flight.Core.Flight flight = new ABC.Flight.Core.Flight(mockDataJson, db.DFWGateLoungeFlight);


            Assert.False(flight.IsAtGate);
        }
        #endregion Flight is At Gate 

    }
}