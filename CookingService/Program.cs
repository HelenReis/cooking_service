using CookingService.Application;
using CookingService.Infra;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ISetup, Setup>();
builder.Services.AddScoped<IPublishMessageService, PublishMessageService>();
builder.Services.AddScoped<IAppSettings, AppSettings>();

var app = builder.Build();

var serviceProvider = ConfigureScope(app);
SendMessages(serviceProvider);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static void SendMessages(IServiceProvider serviceProvider) {
    var appSettings = GetServiceScope<IAppSettings>(serviceProvider);
    var setup = new Setup(appSettings);
    setup.SetupAMQTP();
}

static T GetServiceScope<T>(IServiceProvider serviceProvider) {
    return serviceProvider.GetRequiredService<T>();
}

static IServiceProvider ConfigureScope(WebApplication webHost) {
    var serviceScopeFactory = (IServiceScopeFactory)webHost.Services.GetService(typeof(IServiceScopeFactory));
    var scope = serviceScopeFactory.CreateScope();
    var services = scope.ServiceProvider;

    return services;
}
