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
            Console.WriteLine("CHAMOU APPSE");
            Console.WriteLine(_configVariables.GetValue<string>("CheeseQueue"));
            Console.WriteLine(_config.GetValue<string>("RABBITMQ_HOST"));
            Console.WriteLine(_config.GetValue<string>("RABBITMQ_USER"));
            Console.WriteLine(_config.GetValue<string>("RABBITMQ_PASSWORD"));
        }
        public string CheeseQueue => _configVariables.GetValue<string>("CheeseQueue");

        public string ReadRoutingKey => _configVariables.GetValue<string>("ReadRoutingKey");

        public string InsertRoutingKey => _configVariables.GetValue<string>("InsertRoutingKey");

        public string UpdateRoutingKey => _configVariables.GetValue<string>("UpdateRoutingKey");

        public string RabbitMqHost => _config.GetValue<string>("RABBITMQ_HOST");

        public string RabbitMqUser => _config.GetValue<string>("RABBITMQ_USER");

        public string RabbitMqPassword => _config.GetValue<string>("RABBITMQ_PASSWORD");
    }
}