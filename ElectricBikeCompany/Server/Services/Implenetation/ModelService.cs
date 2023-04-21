using ElectricBikeCompany.Shared;

namespace ElectricBikeCompany.Server.Services;

public class ModelService : IModelService
{
    public List<Model> Models = new List<Model>();

    public async Task<List<Model>> GetModels()
    {
        return Models;
    }

    public async Task<Model?> GetModelById(Guid modelId)
    {
        var dbModel = Models.Where(t => t.Id == modelId).FirstOrDefault();
        return dbModel;
    }

    public async Task<Model> CreateModel(Model model)
    {
        model.Id = Guid.NewGuid();
        Models.Add(model);
        return model;
    }

    public async Task<Model?> UpdateModel(Guid modelId, Model model)
    {
        var dbModel = Models.Where(t => t.Id == modelId).FirstOrDefault();
        if (dbModel is not null)
        {
            dbModel.Name = model.Name;
            dbModel.Production_year = model.Production_year;
            dbModel.Battery_capacity = model.Battery_capacity;
        }
        return dbModel;
    }

    public async Task<bool> DeleteModel(Guid modelId)
    {
        //todo: remove this emloyee from his tasks
        var dbModel = Models.Where(t => t.Id == modelId).FirstOrDefault();
        if (dbModel is not null)
        {
            Models.Remove(dbModel);
            return true;
        }
        return false;
    }
}
