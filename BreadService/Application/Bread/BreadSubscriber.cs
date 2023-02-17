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
        private readonly IBreadDataContext _context;
        private readonly IAppSettings _config;
        public BreadSubscriber(IBreadDataContext context, IAppSettings config)
        {
            _context = context; 
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
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(" [x] Received {0}", message);

                var type = ea.RoutingKey;
                
                 if (type == _config.ReadRoutingKey)
                {
                    var data = JObject.Parse(message);
                    var cheese =_context.Cheese.First();
                }

                if (type == _config.InsertRoutingKey)
                {
                    var data = JObject.Parse(message);
                    _context.Cheese.Add(new Cheese()
                    {
                        StartTime = data["startTime"].Value<DateTime>()
                    });
                    _context.SaveChanges();
                }
            };

            channel.BasicConsume(queue: _config.CheeseQueue,
                                     autoAck: true,
                                     consumer: consumer);
        }
    }
}