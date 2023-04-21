using ElectricBikeCompany.Shared;

namespace ElectricBikeCompany.Server.Services;

public interface IWorkerService
{
    Task<List<Worker>> GetWorkers();
    Task<Worker?> GetWorkerById(Guid WorkerId);
    Task<Worker> CreateWorker(Worker Worker);
    Task<Worker?> UpdateWorker(Guid WorkerId, Worker Worker);
    Task<bool> DeleteWorker(Guid WorkerId);
}
