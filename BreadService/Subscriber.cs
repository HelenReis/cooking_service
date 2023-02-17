using BreadService.Application.Bread;
using BreadService.Infra;
using BreadService.Infra.Data;

namespace BreadService
{
    public static class Subscriber
    {
        public static void SubscribeToMessages(IAppSettings appSettings, BreadDataContext breadDataContext) {
            ListenToMessages(appSettings, breadDataContext);
        }

        private static void ListenToMessages(IAppSettings appSettings, BreadDataContext dataContext) {
            var listeningService = new BreadSubscriber(dataContext, appSettings);
            listeningService.ListenToMessage();
        }
    }
}
    