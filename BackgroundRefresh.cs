
using System.Runtime.CompilerServices;
using System.Timers;

namespace background_Task
{
    public class BackgroundRefresh : IHostedService,IDisposable
    {

        private System.Threading.Timer? _timer;
        private readonly SampleData _data;

        public BackgroundRefresh(SampleData data)
        {
            _data = data;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new System.Threading.Timer(AddToCache, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

        private void AddToCache(object? state)
        {
            _data.Data.Add($"The new Time is {DateTime.Now.ToLongTimeString()}");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
           _timer?.Dispose();
        }
    }
}
