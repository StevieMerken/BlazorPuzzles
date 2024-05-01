using System.Diagnostics;

namespace Puzzle_12;

/// <summary>
/// This is a background task that runs continuously in the background.
/// In Program.cs, we register this as a singleton service so that it
/// can be injected into other components and run as only one instance.
/// In Index.razor, we inject this service to start and stop the task.
/// The task starts automatically when the service is instantiated.
/// 
/// Is there a better way to implement a background task in a Blazor Server app?
/// 
/// </summary>
public class MyBackgroundTask
{
    private CancellationTokenSource _cts = new CancellationTokenSource();

    public MyBackgroundTask()
    {
        // Start the background work immediately upon instantiation.
        Task.Run(() => DoWork(_cts.Token));
    }

    private async Task DoWork(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                // Perform the background task operation.
                await ProcessDataAsync();

                // Wait for a certain period before running again.
                await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);
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

    public void Stop()
    {
        _cts.Cancel();
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

