namespace Puzzle_12;

/// <summary>
/// This is a robust task that runs continuously in the background.
/// In Program.cs, we register this as a Hosted Service so that the
/// system can start it automatically and manage it's lifecycle.
/// We do not need to inject this service, as it runs automatically
/// on startup
/// 
/// Benefits of using a Hosted BackgroundService:
/// 
/// Lifecycle Management: 
/// The BackgroundService integrates with the application's lifecycle, meaning 
/// the background task starts and stops in sync with the application's start 
/// and stop events, ensuring clean shutdowns and reducing the risk of 
/// resource leakage.
/// 
/// Improved Resource Management: 
/// By being managed within the application's lifecycle, the service can more 
/// effectively share and manage resources with other parts of the application, 
/// reducing the risk of contention and exhaustion.
/// 
/// Graceful Cancellation Support: 
/// The background task respects cancellation tokens, which allows for graceful 
/// interruption and termination of the task, particularly important during 
/// application shutdowns.
/// 
/// Error Handling and Resilience: 
/// MyBackgroundTask includes structured exception handling, which makes it more 
/// resilient to failures. It also allows for a controlled response to exceptions, 
/// such as logging errors and implementing retry logic.
/// 
/// Logging Integration: 
/// The service has integrated logging, which is crucial for diagnosing issues 
/// in production environments. This integration makes it easier to track the 
/// behavior of the background task and identify problems.
/// 
/// Asynchronous and Thread-Safe: 
/// The implementation is asynchronous, reducing the likelihood of blocking 
/// threads, which is essential for maintaining the responsiveness of the server 
/// application.
/// 
/// Scalability: 
/// As part of the application's infrastructure, the BackgroundService can be 
/// more easily managed and scaled within the context of the application, 
/// especially if the application is deployed in a scaled-out environment.
/// 
/// Cleaner Code and Separation of Concerns: 
/// Using BackgroundService encourages a cleaner architecture with a clearer 
/// separation of concerns, making the codebase easier to maintain and extend.
/// 
/// Consistency and Best Practices: 
/// Adhering to the framework's recommended approach for background tasks 
/// promotes consistency across the application and aligns with established 
/// best practices.
/// 
/// Observability and Monitoring: 
/// Integrating with the application's logging and lifecycle makes it easier 
/// to observe and monitor the background task, which is crucial for maintaining 
/// and troubleshooting production applications.
/// 
/// </summary>
public class MyBackgroundTask : BackgroundService
{
    private readonly ILogger<MyBackgroundTask> _logger;

    public MyBackgroundTask(ILogger<MyBackgroundTask> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Robust Background Task is starting.");

        stoppingToken.Register(() =>
            _logger.LogInformation("Robust Background Task is stopping."));

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                // Perform the background task operation.
                await ProcessDataAsync(stoppingToken);

                // Wait for a certain period before running again.
                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            }
            catch (OperationCanceledException)
            {
                // Prevent throwing if stoppingToken was cancelled.
                break;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in the robust background task.");
                
                // Wait a while before continuing after an error,
                // to avoid a tight error loop.
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }

        _logger.LogInformation("Robust Background Task is stopping gracefully.");
    }

    private async Task ProcessDataAsync(CancellationToken cancellationToken)
    {
        // Processing logic goes here.
        _logger.LogInformation($"Processing Data at {DateTime.Now.ToLongTimeString()}");
    }
}


