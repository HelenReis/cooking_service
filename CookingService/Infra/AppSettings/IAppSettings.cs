namespace CookingService.Infra
{
    public interface IAppSettings
    {
        string CheeseQueue { get; }
        string BreadQueue { get; }
        string ExchangeCooking { get; }
        string TypeExchangeCooking { get; }
        string RabbitMqHost { get; }
    }
}