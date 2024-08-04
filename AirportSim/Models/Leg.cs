using System.Collections.Concurrent;

namespace AirportSim.Models
{
    public class Leg
    {
        private SemaphoreSlim _sync;
        private ConcurrentQueue<int> _legs = new ConcurrentQueue<int>();
        public int CrossingTime { get; private set; } // time in milliseconds
        public Leg(int crossingTime, params int[] legs)
        {
            _sync = new SemaphoreSlim(legs.Length, legs.Length);
            CrossingTime = crossingTime;
            foreach (int l in legs)
            {
                _legs.Enqueue(l);
            }
        }
        public async Task<int> Enter()
        {
            await _sync.WaitAsync();
            _legs.TryDequeue(out int l);
            return l;
        }
        public void Exit(int value)
        {
            _legs.Enqueue(value);
            _sync.Release();
        }
    }
}
