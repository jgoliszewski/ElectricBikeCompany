using ElectricBikeCompany.Shared;
using ElectricBikeCompany.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace ElectricBikeCompany.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ModelController : ControllerBase
{
    private readonly IModelService _ModelService;

    public ModelController(IModelService ModelService)
    {
        _ModelService = ModelService;
    }

    [HttpGet]
    public async Task<List<Model>> GetModels()
    {
        return await _ModelService.GetModels();
    }

    [HttpGet("{id}")]
    public async Task<Model?> GetModelById(Guid id)
    {
        return await _ModelService.GetModelById(id);
    }

    [HttpPost]
    public async Task<Model?> CreateModel(Model Model)
    {
        return await _ModelService.CreateModel(Model);
    }

    [HttpPut("{id}")]
    public async Task<Model?> UpdateModel(Guid id, Model Model)
    {
        return await _ModelService.UpdateModel(id, Model);
    }

    [HttpDelete("{id}")]
    public async Task<bool> DeleteModel(Guid id)
    {
        return await _ModelService.DeleteModel(id);
    }
}
