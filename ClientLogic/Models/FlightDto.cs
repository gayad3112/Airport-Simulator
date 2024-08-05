namespace ClientLogic.Models
{
    //DTO = Data Transfer Object
    public class FlightDto
    {
        public Guid FlightNumber { get; set; }
        public FlightStatusDto Status { get; set; }
    }
}
