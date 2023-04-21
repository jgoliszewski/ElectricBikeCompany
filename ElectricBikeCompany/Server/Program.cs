using ElectricBikeCompany.Server.Services;
using ElectricBikeCompany.Server.Seeder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSingleton<IWorkerService, WorkerService>();
builder.Services.AddSingleton<IBusService, BusService>();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IRentService, RentService>();
builder.Services.AddSingleton<IBikeService, BikeService>();
builder.Services.AddSingleton<IDockService, DockService>();
builder.Services.AddSingleton<IModelService, ModelService>();
builder.Services.AddScoped<DbSeeder>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
using (var scope = scopedFactory.CreateScope())
{
    var service = scope.ServiceProvider.GetService<DbSeeder>();
    service.Seed();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
