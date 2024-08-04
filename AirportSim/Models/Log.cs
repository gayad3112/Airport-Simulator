namespace AirportSim.Models
{
    public class Log
    {
        public int LogId { get; set; }
        public Guid FlightNumber { get; set; }
        public FlightStatus FlightStatus { get; set; }
        public int Leg { get; set; }
        public DateTime? In { get; set; }
        public DateTime? Out { get; set; }
        public override string ToString()
        {
            return $"Flight number {FlightNumber}, status {FlightStatus} | Entered leg {Leg} | in: {In} | out: {Out}";
        }
        public string EndFlight()
        {
            return $"Flight number {FlightNumber}, status {FlightStatus} | Finished it's course | in: {In} | out: {Out}";
        }
    }
}
