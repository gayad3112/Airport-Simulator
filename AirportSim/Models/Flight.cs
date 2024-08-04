namespace AirportSim.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public Guid FlightNumber { get; set; }
        public FlightStatus Status { get; set; }
        public bool IsArriving { get { if (Status == FlightStatus.Arrival) return true; return false; } }

    }
}
