using ElectricBikeCompany.Shared;

namespace ElectricBikeCompany.Client.Services;

public interface IModelService
{
    List<Model> Models { get; set; }
    Task GetModels();
    Task<Model?> GetModelById(Guid modelId);
    Task CreateModel(Model model);
    Task UpdateModel(Guid modelId, Model model);
    Task DeleteModel(Guid modelId);
}
