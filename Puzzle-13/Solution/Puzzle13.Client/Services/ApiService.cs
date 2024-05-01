using System.Diagnostics;
using System.Net.Http.Json;

namespace Puzzle13.Client.Services;

public class ApiService
{
    private readonly HttpClient _httpClient;

    public ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<dtoPerson>> GetPeopleAsync()
    {
        if (_httpClient.BaseAddress == null)
        {
            return new List<dtoPerson>();
        }

        Debug.WriteLine($"BaseAddress: {_httpClient.BaseAddress}");
        
        var response = await _httpClient.GetAsync("api/person");
        if (response.IsSuccessStatusCode)
        {
            var people = await response.Content.ReadFromJsonAsync<List<dtoPerson>>();
            return people;
        }
        return new List<dtoPerson>();
    }
}
