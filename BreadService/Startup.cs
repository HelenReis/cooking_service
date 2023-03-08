using BreadService.Application.Bread;
using BreadService.Infra;
using BreadService.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace BreadService
{
    public static class Startup
    {
        public static WebApplication InitializeApp(string[] args) {
            var builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder);
            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.MapControllers();
            var serviceProvider = ConfigureScope(app);
            EnsureDatabaseIsCreated(serviceProvider);
            SubscribeToMessages(serviceProvider);
            return app;
        }

        public static void ConfigureServices(WebApplicationBuilder builder) {
            builder.Services.AddDbContext<BreadDataContext>(options => 
                options.UseSqlite(
                builder.Configuration
                .GetSection("DbConnection")
                .GetValue<string>("Database")
                )
            );
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IBreadDataContext, BreadDataContext>();
            builder.Services.AddScoped<IAppSettings, AppSettings>();
            builder.Services.AddScoped<IBreadSubscriber, BreadSubscriber>();
        }

        public static void EnsureDatabaseIsCreated(IServiceProvider serviceProvider) {
            var dataContext = GetServiceScope<BreadDataContext>(serviceProvider);
            dataContext.Database.EnsureCreated();
        }

        public static void SubscribeToMessages(IServiceProvider serviceProvider) {
            var appSettings = GetServiceScope<IAppSettings>(serviceProvider);
            var dataContext = GetServiceScope<BreadDataContext>(serviceProvider);
            var subscriber = new BreadAppSubscriber(appSettings);
            subscriber.SubscribeToMessages();
        }

        public static T GetServiceScope<T>(IServiceProvider serviceProvider) {
            return serviceProvider.GetRequiredService<T>();
        }

        public static IServiceProvider ConfigureScope(WebApplication webHost) {
            var serviceScopeFactory = (IServiceScopeFactory)webHost.Services.GetService(typeof(IServiceScopeFactory));
            var scope = serviceScopeFactory.CreateScope();
            var services = scope.ServiceProvider;

            return services;
        }
    }
}