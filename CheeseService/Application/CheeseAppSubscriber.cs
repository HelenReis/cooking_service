using CheeseService.Domain;
using CheeseService.Infra;

namespace CheeseService.Application
{
    public class CheeseAppSubscriber : ICheeseAppSubscriber
    {
        private readonly IAppSettings _appSettings;
        public CheeseAppSubscriber(IAppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public void SubscribeToMessages()
        {
            var listeningService = new CheeseSubscriber(_appSettings);
            listeningService.ListenToMessage();
        }
    }
}