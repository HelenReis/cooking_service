using BreadService.Application.Bread;
using Microsoft.AspNetCore.Mvc;

namespace BreadService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BreadController : ControllerBase
    {
    private readonly IBreadSubscriber _breadSubscriber;

    public BreadController(IBreadSubscriber breadSubscriber)
    {
        _breadSubscriber = breadSubscriber;
    }

    [HttpPost(Name = "Prepare")]
    public void Prepare()
    {
        _breadSubscriber.ListenToMessage();
    }
    }
}