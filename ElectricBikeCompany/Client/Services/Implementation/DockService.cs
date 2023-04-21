using ElectricBikeCompany.Shared;
using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http.Json;

namespace ElectricBikeCompany.Client.Services;

public class DockService : IDockService
{
    private readonly HttpClient _http;
    private readonly NavigationManager _navigationManger;

    public DockService(HttpClient http, NavigationManager navigationManger)
    {
        _http = http;
        _navigationManger = navigationManger;
    }

    public List<Dock> Docks { get; set; } = new List<Dock>();

    public async Task GetDocks()
    {
        var result = await _http.GetFromJsonAsync<List<Dock>>("api/dock");
        if (result is not null)
            Docks = result;
    }

    public async Task<Dock?> GetDockById(Guid dockId)
    {
        var result = await _http.GetAsync($"api/dock/{dockId}");
        if (result.StatusCode == HttpStatusCode.OK)
        {
            return await result.Content.ReadFromJsonAsync<Dock>();
        }
        return null;
    }

    public async Task CreateDock(Dock dock)
    {
        await _http.PostAsJsonAsync("api/dock", dock);
        _navigationManger.NavigateTo("docks");
    }

    public async Task UpdateDock(Guid dockId, Dock dock)
    {
        await _http.PutAsJsonAsync($"api/dock/{dockId}", dock);
    }

    public async Task DeleteDock(Guid dockId)
    {
        var result = await _http.DeleteAsync($"api/dock/{dockId}");
        _navigationManger.NavigateTo("docks");
    }
}
