namespace BreadService.Infra
{
    public interface IAppSettings
    {
        string BreadQueue { get; }
        string RabbitMqHost { get; }
    }
}