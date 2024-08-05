using ClientLogic.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace ClientLogic
{
    public class FlightService
    {
        private readonly HttpClient client = new HttpClient { BaseAddress = new Uri("http://localhost:5002") };

        public async Task AddFlightAsync(FlightDto flight)
        {
            try
            {
                var jsonPayload = JsonSerializer.Serialize(flight);
                Console.WriteLine($"Sending JSON Payload: {jsonPayload}");

                var response = await client.PostAsJsonAsync("api/Flights", flight);
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Successfully added flight with ID: {flight.FlightNumber}");
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error adding flight: {response.StatusCode} - {errorContent}");
                }
            }
            catch (Exception ex)
            {
                // Log or handle the error
                Console.WriteLine($"Error adding flight: {ex.Message}");
            }
        }
    }
}
