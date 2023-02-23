namespace CookingService.Infra
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
        public string CheeseQueue => _configVariables.GetValue<string>("CheeseQueue");
        public string BreadQueue => _configVariables.GetValue<string>("BreadQueue");
        public string ExchangeCooking => _configVariables.GetValue<string>("ExchangeCooking");
        public string TypeExchangeCooking => _configVariables.GetValue<string>("TypeExchangeCooking");
        public string RabbitMqHost => _config.GetValue<string>("RABBITMQ_HOST");
    }
}