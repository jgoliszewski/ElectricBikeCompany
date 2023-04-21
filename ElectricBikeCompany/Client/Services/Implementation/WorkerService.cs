using ElectricBikeCompany.Shared;
using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http.Json;

namespace ElectricBikeCompany.Client.Services;

public class WorkerService : IWorkerService
{
    private readonly HttpClient _http;
    private readonly NavigationManager _navigationManger;

    public WorkerService(HttpClient http, NavigationManager navigationManger)
    {
        _http = http;
        _navigationManger = navigationManger;
    }

    public List<Worker> Workers { get; set; } = new List<Worker>();

    public async Task GetWorkers()
    {
        var result = await _http.GetFromJsonAsync<List<Worker>>("api/worker");
        if (result is not null)
            Workers = result;
    }

    public async Task<Worker?> GetWorkerById(Guid workerId)
    {
        var result = await _http.GetAsync($"api/worker/{workerId}");
        if (result.StatusCode == HttpStatusCode.OK)
        {
            return await result.Content.ReadFromJsonAsync<Worker>();
        }
        return null;
    }

    public async Task CreateWorker(Worker worker)
    {
        await _http.PostAsJsonAsync("api/worker", worker);
        _navigationManger.NavigateTo("workers");
    }

    public async Task UpdateWorker(Guid workerId, Worker worker)
    {
        await _http.PutAsJsonAsync($"api/worker/{workerId}", worker);
    }

    public async Task DeleteWorker(Guid workerId)
    {
        var result = await _http.DeleteAsync($"api/worker/{workerId}");
        _navigationManger.NavigateTo("workers");
    }
}
