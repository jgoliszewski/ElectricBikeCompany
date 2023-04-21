using ElectricBikeCompany.Shared;

namespace ElectricBikeCompany.Client.Services;

public interface IWorkerService
{
    List<Worker> Workers { get; set; }
    Task GetWorkers();
    Task<Worker?> GetWorkerById(Guid workerId);
    Task CreateWorker(Worker worker);
    Task UpdateWorker(Guid workerId, Worker worker);
    Task DeleteWorker(Guid workerId);
}
