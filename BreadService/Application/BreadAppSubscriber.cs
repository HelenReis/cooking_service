using BreadService.Application.Bread;
using BreadService.Infra;

public class BreadAppSubscriber : IBreadAppSubscriber
{
    private readonly IAppSettings _appSettings;
    public BreadAppSubscriber(IAppSettings appSettings)
    {
        _appSettings = appSettings;
    }

    public void SubscribeToMessages()
    {
        var listeningService = new BreadSubscriber(_appSettings);
        listeningService.ListenToMessage();
    }
}