namespace BreadService.Infra
{
    public class AppSettings : IAppSettings
    {
        private readonly IConfigurationSection _configVariables;
        private readonly IConfiguration _config;
        public AppSettings(IConfiguration config)
        {
            _configVariables = config.GetSection("Messages");
            _config = config;
        }
        public string BreadQueue => _configVariables.GetValue<string>("BreadQueue");
        public string RabbitMqHost => _config.GetValue<string>("RABBITMQ_HOST");
    }
}