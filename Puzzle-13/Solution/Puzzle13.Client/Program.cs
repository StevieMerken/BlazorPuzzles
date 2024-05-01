using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Puzzle13.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddHttpClient("Puzzle13.ServerAPI",
    client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

builder.Services.AddScoped(sp =>
    sp.GetRequiredService<IHttpClientFactory>().CreateClient("Puzzle13.ServerAPI"));

builder.Services.AddScoped<ApiService>();

await builder.Build().RunAsync();
