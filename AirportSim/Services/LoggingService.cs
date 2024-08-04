using AirportSim.Data;
using AirportSim.Models;

namespace AirportSim.Services
{
    public class LoggingService
    {
        public void LogMovement(int legNum, Flight flight, DataContext data)
        {
            Log log = new Log() { FlightNumber = flight.FlightNumber, FlightStatus = flight.Status, In = DateTime.Now, Leg = legNum };
            Console.WriteLine(log);
            data.Logs.Add(log);
            data.SaveChanges();
        }
        public void LogFlightEnd(Flight flight, DataContext data)
        {
            Log log = new Log() { FlightNumber = flight.FlightNumber, FlightStatus = flight.Status, Out = DateTime.Now };
            Console.WriteLine(log.EndFlight());
            data.Logs.Add(log);
            data.SaveChanges();
        }

        public ICollection<Log> GetLogs(DataContext data, int startingId = 0) //only get new logs 
        {
            return data.Logs.Where(l => l.LogId > startingId).OrderByDescending(l => l.LogId).ToList();
        }
    }
}
