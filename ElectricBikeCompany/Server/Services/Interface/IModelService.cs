using ElectricBikeCompany.Shared;

namespace ElectricBikeCompany.Server.Services;

public interface IModelService
{
    Task<List<Model>> GetModels();
    Task<Model?> GetModelById(Guid ModelId);
    Task<Model> CreateModel(Model Model);
    Task<Model?> UpdateModel(Guid ModelId, Model Model);
    Task<bool> DeleteModel(Guid ModelId);
}
