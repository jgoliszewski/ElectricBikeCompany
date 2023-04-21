using ElectricBikeCompany.Shared;
using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http.Json;

namespace ElectricBikeCompany.Client.Services;

public class RentService : IRentService
{
    private readonly HttpClient _http;
    private readonly NavigationManager _navigationManger;

    public RentService(HttpClient http, NavigationManager navigationManger)
    {
        _http = http;
        _navigationManger = navigationManger;
    }

    public List<Rent> Rents { get; set; } = new List<Rent>();

    public async Task GetRents()
    {
        var result = await _http.GetFromJsonAsync<List<Rent>>("api/rent");
        if (result is not null)
            Rents = result;
    }

    public async Task<Rent?> GetRentById(Guid rentId)
    {
        var result = await _http.GetAsync($"api/rent/{rentId}");
        if (result.StatusCode == HttpStatusCode.OK)
        {
            return await result.Content.ReadFromJsonAsync<Rent>();
        }
        return null;
    }

    public async Task CreateRent(Rent rent)
    {
        await _http.PostAsJsonAsync("api/rent", rent);
        _navigationManger.NavigateTo("rents");
    }

    public async Task UpdateRent(Guid rentId, Rent rent)
    {
        await _http.PutAsJsonAsync($"api/rent/{rentId}", rent);
    }

    public async Task DeleteRent(Guid rentId)
    {
        var result = await _http.DeleteAsync($"api/rent/{rentId}");
        _navigationManger.NavigateTo("rents");
    }
}
