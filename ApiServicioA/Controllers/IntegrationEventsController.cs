using Microsoft.AspNetCore.Mvc;
using Dapr;
using Dapr.Client;

[ApiController]
[Route("[controller]")]
public class IntegrationEventsController : ControllerBase
{
    private readonly DaprClient _daprClient;
    public IntegrationEventsController(DaprClient daprClient)
    {
        this._daprClient = daprClient;
    }

    [Topic("pubsub","topicNameMensajes")]
    [HttpPost]
    public async Task<IActionResult> OnEventRecieved(object item)
    {

        await _daprClient.PublishEventAsync("pubsub", "topicNameMensajesRecibidos", new { mensaje = "Hola", fecha = DateTime.Now });

        return Ok();
    }

    // internal record MessageEvent(string mensaje, string fecha);
}