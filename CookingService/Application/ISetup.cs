using RabbitMQ.Client;

namespace CookingService.Application
{
    public interface ISetup
    {
        void SetupAMQTP();
        IModel? GetChannel();
    }
}