namespace AirportSim.Models
{
    public static class FlightProtocols
    {
        private static Leg leg1 = new Leg(3000, [1]);
        private static Leg leg2 = new Leg(2000, [2]);
        private static Leg leg3 = new Leg(2000, [3]);
        private static Leg leg4 = new Leg(5000, [4]);
        private static Leg leg5 = new Leg(7000, [5]);
        private static Leg leg67 = new Leg(2000, [6, 7]);
        private static Leg leg8 = new Leg(4000, [8]);

        public static Leg[] Departure
        {
            get
            {
                return [leg67, leg8, leg4];
            }
        }
        public static Leg[] Arrival
        {
            get
            {
                return [leg1, leg2, leg3, leg4, leg5, leg67];
            }
        }
    }
}
