using ElectricBikeCompany.Shared;
using ElectricBikeCompany.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace ElectricBikeCompany.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorkerController : ControllerBase
{
    private readonly IWorkerService _WorkerService;

    public WorkerController(IWorkerService WorkerService)
    {
        _WorkerService = WorkerService;
    }

    [HttpGet]
    public async Task<List<Worker>> GetWorkers()
    {
        return await _WorkerService.GetWorkers();
    }

    [HttpGet("{id}")]
    public async Task<Worker?> GetWorkerById(Guid id)
    {
        return await _WorkerService.GetWorkerById(id);
    }

    [HttpPost]
    public async Task<Worker?> CreateWorker(Worker Worker)
    {
        return await _WorkerService.CreateWorker(Worker);
    }

    [HttpPut("{id}")]
    public async Task<Worker?> UpdateWorker(Guid id, Worker Worker)
    {
        return await _WorkerService.UpdateWorker(id, Worker);
    }

    [HttpDelete("{id}")]
    public async Task<bool> DeleteWorker(Guid id)
    {
        return await _WorkerService.DeleteWorker(id);
    }
}
