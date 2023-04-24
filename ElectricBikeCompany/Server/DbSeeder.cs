using ElectricBikeCompany.Shared;
using ElectricBikeCompany.Server.Services;

namespace ElectricBikeCompany.Server.Seeder;

public class DbSeeder
{
    private readonly IWorkerService _workerService;
    private readonly IBusService _busService;
    private readonly IUserService _userService;
    private readonly IBikeService _bikeService;
    private readonly IRentService _rentService;
    private readonly IModelService _modelService;
    private readonly IDockService _dockService;

    public DbSeeder(
        IWorkerService workerService,
        IBusService busService,
        IUserService userService,
        IBikeService bikeService,
        IRentService rentService,
        IModelService modelService,
        IDockService dockService
    )
    {
        _workerService = workerService;
        _busService = busService;
        _userService = userService;
        _bikeService = bikeService;
        _rentService = rentService;
        _modelService = modelService;
        _dockService = dockService;
    }

    private static List<Bus> Buses = new List<Bus>()
    {
        new Bus() { LicensePlate = "WG12345", Capacity = 15 },
        new Bus() { LicensePlate = "WG00001", Capacity = 15 },
        new Bus() { LicensePlate = "WG01230", Capacity = 20 },
        new Bus() { LicensePlate = "WG12321", Capacity = 20 },
    };
    private List<Worker> Workers = new List<Worker>()
    {
        new Worker() { Name = "Tom", Bus = Buses[0] },
        new Worker() { Name = "Mark", Bus = Buses[1] },
        new Worker() { Name = "Anna", Bus = Buses[2] },
        new Worker() { Name = "John", Bus = Buses[3] },
    };
    private List<User> Users = new List<User>()
    {
        new User() { Username = "Johhhny123", Password = "12345" },
        new User() { Username = "ILoveDogs", Password = "doggy_*_*" },
        new User() { Username = "SpeedyGonzalez", Password = "iamspeed" },
        new User() { Username = "JustTom", Password = "MyNameIsTom" },
        new User() { Username = "FancyBiker", Password = "bike_bike" },
    };
    private static List<Model> Models = new List<Model>()
    {
        new Model()
        {
            Name = "EB Speedy",
            Production_year = 2020,
            Battery_capacity = 8
        },
        new Model()
        {
            Name = "EB Comfy",
            Production_year = 2018,
            Battery_capacity = 10
        }
    };

    private static List<Dock> Docks = new List<Dock>()
    {
        new Dock()
        {
            Capacity = 25,
            Taken_spaces = 0,
            Address = "Flower Street 12a"
        },
        new Dock()
        {
            Capacity = 15,
            Taken_spaces = 0,
            Address = "Long Street 2/6"
        },
        new Dock()
        {
            Capacity = 30,
            Taken_spaces = 0,
            Address = "Wide Street 13"
        },
    };
    private List<Bike> Bikes = new List<Bike>();

    public void Seed()
    {
        Random rand = new Random();
        var bikeCount = 10;
        for (int i = 0; i < bikeCount; i++)
        {
            var n = rand.NextDouble() >= 0.5 ? 1 : 0;
            Bikes.Add(GenerateBike(n));
        }

        foreach (var w in Workers)
        {
            _workerService.CreateWorker(w);
        }
        foreach (var b in Buses)
        {
            _busService.CreateBus(b);
        }
        foreach (var u in Users)
        {
            _userService.CreateUser(u);
        }
        foreach (var m in Models)
        {
            _modelService.CreateModel(m);
        }
        foreach (var d in Docks)
        {
            _dockService.CreateDock(d);
        }
        foreach (var b in Bikes)
        {
            _bikeService.CreateBike(b);
        }
        _rentService.CreateRent(
            new Rent()
            {
                User = Users[0],
                Bike = Bikes[0],
                Rent_start = DateTime.Now,
                Rent_end = DateTime.Now,
                Dock_start = Docks[0],
                Dock_end = Docks[1],
            }
        );
    }

    private Bike GenerateBike(int n)
    {
        var bike = new Bike()
        {
            BatteryPercent = 80,
            Model = Models[n],
            Dock = Docks[1 - n]
        };
        return bike;
    }
}
