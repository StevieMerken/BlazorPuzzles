# Blazor Puzzle #17

## Weather or Not!

YouTube Video: https://youtu.be/rJehC0sDeSI

BlazorPuzzle Home Page: https://blazorpuzzle.com

#### The Challenge:

This is a .NET 8 Blazor Web App with the Interactive render mode set to "Server" and the Interactivity location set to "Global" with sample pages.

While Weather.razor does indeed demonstrate Streaming Rendering, it doesn't quite show off the value of this feature. We want to make it a little more impressive.

We have increased the number of records retrieved to 5000.

Even though the StreamRendering attribute lets us view the page immediately, is there any way we can tighten up the UI so it's more real-world than a table with 5000 records?

NOTE: We do not condone showing 5000 records or more to the user. This is a demo.

#### The Solution:

One way to speed this up is to ditch the `<table>` element and instead use a `<select>` element.

Change the *Weather.razor* page to the following:

```c#
@page "/weather"
@attribute [StreamRendering]

<PageTitle>Weather</PageTitle>

<h1>Weather</h1>

<p>This component demonstrates showing data.</p>

<select size="@listSize" style="width:100%;">
    @foreach (var forecast in forecasts)
    {
        <option value="@forecast.Id">@forecast.Id @forecast.Summary</option>
    }
</select>

@code {
    private readonly int listSize = 20;

    private List<WeatherForecast> forecasts = new List<WeatherForecast>();

    protected override async Task OnInitializedAsync()
    {
        int count = 5000;
        forecasts = await GetWeatherForecasts(count);
    }

    private async Task<List<WeatherForecast>> GetWeatherForecasts(int count)
    {
        var forcasts = new List<WeatherForecast>();
        var startDate = DateOnly.FromDateTime(DateTime.Now);
        var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

        for (int i = 0; i < count; i++)
        {
            var forecast = new WeatherForecast
            {
                Id = i + 1,
                Date = startDate.AddDays(i),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = summaries[Random.Shared.Next(summaries.Length)]
            };
            forecasts.Add(forecast);
        }
        // simulate a timeout from a database query
        await Task.Delay(2000);
        return forecasts;
    }

    private class WeatherForecast
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public int TemperatureC { get; set; }
        public string? Summary { get; set; }
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}
```

Boom!