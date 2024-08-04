using AirportSim.Data;
using AirportSim.Models;
using Microsoft.EntityFrameworkCore;

namespace AirportSim.Services
{
    public class FlightService
    {
        private readonly LoggingService _loggingService;
        private readonly IDbContextFactory<DataContext> _dbContextFactory;
        private static SemaphoreSlim _processingQueue = new SemaphoreSlim(4, 4);
        public FlightService(LoggingService loggingService, IDbContextFactory<DataContext> dbContextFactory)
        {
            _loggingService = loggingService;
            _dbContextFactory = dbContextFactory;
        }
        public async Task HandleFlight(Flight flight)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                await _processingQueue.WaitAsync();
                try
                {

                    var legs = flight.IsArriving ? FlightProtocols.Arrival : FlightProtocols.Departure;
                    for (int i = 0; i < legs.Length; i++)
                    {
                        int legNum = await legs[i].Enter();
                        try
                        {
                            _loggingService.LogMovement(legNum, flight, context);
                            await Task.Delay(legs[i].CrossingTime);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            Console.WriteLine(e.Message);
                            Console.WriteLine(e.InnerException);
                        }
                        finally
                        {
                            legs[i].Exit(legNum);
                        }
                    }
                }
                finally
                {
                    _loggingService.LogFlightEnd(flight, context);
                    _processingQueue.Release();
                }
            }
        }

        public ICollection<Log> GetLogs(int startingId = 0)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return _loggingService.GetLogs(context, startingId);
            }
        }
    }
}
