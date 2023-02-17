using BreadService.Infra;
using Microsoft.EntityFrameworkCore;
using BreadService.Infra.Data;
using BreadService.Application.Bread;
using BreadService;

var app = Startup.InitializeApp(args);
app.Run();

//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
/*builder.Services.AddDbContext<BreadDataContext>(options => 
    options.UseSqlite(
        builder.Configuration
            .GetSection("DbConnection")
            .GetValue<string>("Database"))
        );
builder.Services.AddScoped<IBreadDataContext, BreadDataContext>();
builder.Services.AddScoped<IAppSettings, AppSettings>();
builder.Services.AddScoped<IBreadSubscriber, BreadSubscriber>();

var app = builder.Build();

var serviceProvider = ConfigureScope(app);
EnsureDatabaseIsCreated();
ListenToMessages();

app.Run();

IServiceProvider ConfigureScope(WebApplication webHost) {
    var serviceScopeFactory = (IServiceScopeFactory)webHost.Services.GetService(typeof(IServiceScopeFactory));
    var scope = serviceScopeFactory.CreateScope();
    var services = scope.ServiceProvider;

    return services;
}

T GetServiceScope<T>() {
    return serviceProvider.GetRequiredService<T>();
}

void EnsureDatabaseIsCreated() {
    var dataContext = GetServiceScope<BreadDataContext>();
    dataContext.Database.EnsureCreated();
}

void ListenToMessages() {
    var appSettings = GetServiceScope<IAppSettings>();
    var dataContext = GetServiceScope<BreadDataContext>();
    var listeningService = new BreadSubscriber(dataContext, appSettings);
    listeningService.ListenToMessage();
}*/
