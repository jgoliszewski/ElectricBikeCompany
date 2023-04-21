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
        new Bus()
        {
            Id = Guid.NewGuid(),
            LicensePlate = "WG12345",
            Capacity = 15
        },
        new Bus()
        {
            Id = Guid.NewGuid(),
            LicensePlate = "WG00001",
            Capacity = 15
        },
        new Bus()
        {
            Id = Guid.NewGuid(),
            LicensePlate = "WG01230",
            Capacity = 20
        },
        new Bus()
        {
            Id = Guid.NewGuid(),
            LicensePlate = "WG12321",
            Capacity = 20
        },
    };
    private List<Worker> Workers = new List<Worker>()
    {
        new Worker()
        {
            Id = Guid.NewGuid(),
            Name = "Tom",
            Bus = Buses[0]
        },
        new Worker()
        {
            Id = Guid.NewGuid(),
            Name = "Mark",
            Bus = Buses[1]
        },
        new Worker()
        {
            Id = Guid.NewGuid(),
            Name = "Anna",
            Bus = Buses[2]
        },
        new Worker()
        {
            Id = Guid.NewGuid(),
            Name = "John",
            Bus = Buses[3]
        },
    };
    private List<User> Users = new List<User>()
    {
        new User()
        {
            Id = Guid.NewGuid(),
            Username = "Johhhny123",
            Password = "12345"
        },
        new User()
        {
            Id = Guid.NewGuid(),
            Username = "ILoveDogs",
            Password = "doggy_*_*"
        },
        new User()
        {
            Id = Guid.NewGuid(),
            Username = "SpeedyGonzalez",
            Password = "iamspeed"
        },
        new User()
        {
            Id = Guid.NewGuid(),
            Username = "JustTom",
            Password = "MyNameIsTom"
        },
        new User()
        {
            Id = Guid.NewGuid(),
            Username = "FancyBiker",
            Password = "bike_bike"
        },
    };
    private static List<Model> Models = new List<Model>()
    {
        new Model()
        {
            Id = Guid.NewGuid(),
            Name = "EB Speedy",
            Production_year = 2020,
            Battery_capacity = 8
        },
        new Model()
        {
            Id = Guid.NewGuid(),
            Name = "EB Comfy",
            Production_year = 2018,
            Battery_capacity = 10
        }
    };

    private static List<Dock> Docks = new List<Dock>()
    {
        new Dock()
        {
            Id = Guid.NewGuid(),
            Capacity = 25,
            Taken_spaces = 0,
            Address = "Flower Street 12a"
        },
        new Dock()
        {
            Id = Guid.NewGuid(),
            Capacity = 15,
            Taken_spaces = 0,
            Address = "Long Street 2/6"
        },
        new Dock()
        {
            Id = Guid.NewGuid(),
            Capacity = 30,
            Taken_spaces = 0,
            Address = "Wide Street 13"
        },
    };
    private List<Bike> Bikes = new List<Bike>();

    public void Seed()
    {
        var bikeCount = 10;
        for (int i = 0; i < bikeCount; i++)
        {
            Bikes.Add(GenerateBike());
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
    }

    private Bike GenerateBike()
    {
        var bike = new Bike()
        {
            Id = Guid.NewGuid(),
            BatteryPercent = 80,
            Model = Models[0],
            Dock = Docks[0]
        };
        return bike;
    }
}
