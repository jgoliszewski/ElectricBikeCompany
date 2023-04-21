using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ElectricBikeCompany.Client;
using ElectricBikeCompany.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(
    sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) }
);
builder.Services.AddScoped<IWorkerService, WorkerService>();
builder.Services.AddScoped<IBusService, BusService>();
builder.Services.AddScoped<IBikeService, BikeService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRentService, RentService>();
builder.Services.AddScoped<IModelService, ModelService>();
builder.Services.AddScoped<IDockService, DockService>();

await builder.Build().RunAsync();
