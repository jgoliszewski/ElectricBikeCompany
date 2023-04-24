using ElectricBikeCompany.Shared;
using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http.Json;

namespace ElectricBikeCompany.Client.Services;

public class BusService : IBusService
{
    private readonly HttpClient _http;
    private readonly NavigationManager _navigationManger;

    public BusService(HttpClient http, NavigationManager navigationManger)
    {
        _http = http;
        _navigationManger = navigationManger;
    }

    public List<Bus> Buses { get; set; } = new List<Bus>();

    public async Task GetBuses()
    {
        var result = await _http.GetFromJsonAsync<List<Bus>>("api/bus");
        if (result is not null)
            Buses = result;
    }

    public async Task<Bus?> GetBusById(Guid busId)
    {
        var result = await _http.GetAsync($"api/bus/{busId}");
        if (result.StatusCode == HttpStatusCode.OK)
        {
            return await result.Content.ReadFromJsonAsync<Bus>();
        }
        return null;
    }

    public async Task CreateBus(Bus bus)
    {
        await _http.PostAsJsonAsync("api/bus", bus);
        _navigationManger.NavigateTo("buses");
    }

    public async Task UpdateBus(Guid busId, Bus bus)
    {
        await _http.PutAsJsonAsync($"api/bus/{busId}", bus);
    }

    public async Task DeleteBus(Guid busId)
    {
        var result = await _http.DeleteAsync($"api/bus/{busId}");
        _navigationManger.NavigateTo("buses");
    }
}
