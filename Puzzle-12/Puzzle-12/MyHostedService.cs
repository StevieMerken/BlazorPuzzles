using System.Diagnostics;
using System.Threading;

namespace Puzzle_12
{
    public sealed class MyHostedService : BackgroundService
    {
        private readonly Task _completedTask = Task.CompletedTask;
        private readonly ILogger<MyHostedService> logger;

        public MyHostedService(ILogger<MyHostedService> logger)
        {
            this.logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    // Perform the background task operation.
                    await ProcessDataAsync();

                    // Wait for a certain period before running again.
                    await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
                }
                catch (TaskCanceledException)
                {
                    // Ignore the task cancellation.
                }
                catch (Exception ex)
                {
                    // Exception handling logic (potentially incomplete or incorrect).
                    LogError(ex);
                }
            }
        }

        private async Task ProcessDataAsync()
        {
            // Processing logic goes here.
            Debug.WriteLine($"Processing Data at {DateTime.Now.ToLongTimeString()}");
        }

        private void LogError(Exception ex)
        {
            // Log the error (implementation omitted for brevity)
        }
    }
}
