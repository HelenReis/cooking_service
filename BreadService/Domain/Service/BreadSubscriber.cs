using System.Text;
using BreadService.Domain;
using BreadService.Infra;
using BreadService.Infra.Data;
using Newtonsoft.Json.Linq;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace BreadService.Application.Bread
{
    public class BreadSubscriber : IBreadSubscriber
    {
        private readonly IAppSettings _config;
        public BreadSubscriber(IAppSettings config)
        {
            _config = config;
        }
        public void ListenToMessage()
        {
            var factory = new ConnectionFactory();
            factory.HostName = _config.RabbitMqHost;
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += async(model, ea) =>
            {                
                Console.WriteLine("received message on bread service.");
            };

            channel.BasicConsume(queue: _config.BreadQueue,
                                     autoAck: true,
                                     consumer: consumer);
        }
    }
}