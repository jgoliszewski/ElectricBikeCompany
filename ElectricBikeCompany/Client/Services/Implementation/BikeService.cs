using ElectricBikeCompany.Shared;
using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http.Json;

namespace ElectricBikeCompany.Client.Services;

public class BikeService : IBikeService
{
    private readonly HttpClient _http;
    private readonly NavigationManager _navigationManger;

    public BikeService(HttpClient http, NavigationManager navigationManger)
    {
        _http = http;
        _navigationManger = navigationManger;
    }

    public List<Bike> Bikes { get; set; } = new List<Bike>();

    public async Task GetBikes()
    {
        var result = await _http.GetFromJsonAsync<List<Bike>>("api/bike");
        if (result is not null)
            Bikes = result;
    }

    public async Task<Bike?> GetBikeById(Guid bikeId)
    {
        var result = await _http.GetAsync($"api/bike/{bikeId}");
        if (result.StatusCode == HttpStatusCode.OK)
        {
            return await result.Content.ReadFromJsonAsync<Bike>();
        }
        return null;
    }

    public async Task CreateBike(Bike bike)
    {
        await _http.PostAsJsonAsync("api/bike", bike);
        _navigationManger.NavigateTo("bikes");
    }

    public async Task UpdateBike(Guid bikeId, Bike bike)
    {
        await _http.PutAsJsonAsync($"api/bike/{bikeId}", bike);
    }

    public async Task DeleteBike(Guid bikeId)
    {
        var result = await _http.DeleteAsync($"api/bike/{bikeId}");
        _navigationManger.NavigateTo("bikes");
    }
}
