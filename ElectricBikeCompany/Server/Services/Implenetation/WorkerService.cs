using ElectricBikeCompany.Shared;

namespace ElectricBikeCompany.Server.Services;

public class WorkerService : IWorkerService
{
    public List<Worker> Workers = new List<Worker>();

    public async Task<List<Worker>> GetWorkers()
    {
        return Workers;
    }

    public async Task<Worker?> GetWorkerById(Guid workerId)
    {
        var dbWorker = Workers.Where(t => t.Id == workerId).FirstOrDefault();
        return dbWorker;
    }

    public async Task<Worker> CreateWorker(Worker worker)
    {
        worker.Id = Guid.NewGuid();
        Workers.Add(worker);
        return worker;
    }

    public async Task<Worker?> UpdateWorker(Guid workerId, Worker worker)
    {
        var dbWorker = Workers.Where(t => t.Id == workerId).FirstOrDefault();
        if (dbWorker is not null)
        {
            dbWorker.Name = worker.Name;
            dbWorker.Bus = worker.Bus;
        }
        return dbWorker;
    }

    public async Task<bool> DeleteWorker(Guid workerId)
    {
        //todo: remove this emloyee from his tasks
        var dbWorker = Workers.Where(t => t.Id == workerId).FirstOrDefault();
        if (dbWorker is not null)
        {
            Workers.Remove(dbWorker);
            return true;
        }
        return false;
    }
}
