namespace BreadService.Infra
{
    public interface IAppSettings
    {
        string CheeseQueue { get; }
        string ReadRoutingKey { get; }
        string InsertRoutingKey { get; }
        string UpdateRoutingKey { get; }
        string RabbitMqHost { get; }
        string RabbitMqUser { get; }
        string RabbitMqPassword { get; }
    }
}