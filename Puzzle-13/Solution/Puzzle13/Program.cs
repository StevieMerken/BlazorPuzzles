global using System.Text.Json;
using Puzzle13.Client.Services;
using Puzzle13.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

// Configure your HttpClient with a local base address for debugging
builder.Services.AddHttpClient("Puzzle13.ServerAPI", client =>
{
    // Replace with your API's local address and port
    client.BaseAddress = new Uri("https://localhost:7146/");
    // Additional configurations
});

builder.Services.AddScoped(sp =>
    sp.GetRequiredService<IHttpClientFactory>().CreateClient("Puzzle13.ServerAPI"));

builder.Services.AddScoped<ApiService>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapControllers();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Puzzle13.Client._Imports).Assembly);

app.Run();
