using ElectricBikeCompany.Shared;
using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http.Json;

namespace ElectricBikeCompany.Client.Services;

public class ModelService : IModelService
{
    private readonly HttpClient _http;
    private readonly NavigationManager _navigationManger;

    public ModelService(HttpClient http, NavigationManager navigationManger)
    {
        _http = http;
        _navigationManger = navigationManger;
    }

    public List<Model> Models { get; set; } = new List<Model>();

    public async Task GetModels()
    {
        var result = await _http.GetFromJsonAsync<List<Model>>("api/model");
        if (result is not null)
            Models = result;
    }

    public async Task<Model?> GetModelById(Guid modelId)
    {
        var result = await _http.GetAsync($"api/model/{modelId}");
        if (result.StatusCode == HttpStatusCode.OK)
        {
            return await result.Content.ReadFromJsonAsync<Model>();
        }
        return null;
    }

    public async Task CreateModel(Model model)
    {
        await _http.PostAsJsonAsync("api/model", model);
        _navigationManger.NavigateTo("models");
    }

    public async Task UpdateModel(Guid modelId, Model model)
    {
        await _http.PutAsJsonAsync($"api/model/{modelId}", model);
    }

    public async Task DeleteModel(Guid modelId)
    {
        var result = await _http.DeleteAsync($"api/model/{modelId}");
        _navigationManger.NavigateTo("models");
    }
}
