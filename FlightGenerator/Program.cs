
using ClientLogic;
using ClientLogic.Models;

namespace FlightGenerator
{
    internal class Program
    {
        static readonly FlightService service = new FlightService();
        static readonly Random random = new Random();
        static CancellationTokenSource cts = new CancellationTokenSource();

        static void Main(string[] args)
        {
            Task.Run(() => CreateFlightsAsync(cts.Token));
            Console.WriteLine("Press Enter to stop...");
            Console.ReadLine();
            cts.Cancel();
        }

        private static async Task CreateFlightsAsync(CancellationToken token)
        {

            while (!token.IsCancellationRequested)
            {
                var interval = random.Next(5000, 30000); // Random interval between 5 and 10 seconds
                await Task.Delay(interval, token);

                if (!token.IsCancellationRequested)
                {
                    CreateFlight();
                }
            }
        }

        private async static void CreateFlight()
        {
            var flight = new FlightDto { FlightNumber = Guid.NewGuid(), Status = (FlightStatusDto)random.Next(0, 2) };
            await service.AddFlightAsync(flight);
            Console.WriteLine($"Flight created: {flight.FlightNumber} at {DateTime.Now}");
        }
    }
}
