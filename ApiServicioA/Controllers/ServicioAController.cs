using Dapr.Client;
using Microsoft.AspNetCore.Mvc;

namespace ApiServicioA.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ServicioAController : ControllerBase
	{		
		//[HttpGet(Name = "GetWeatherForecast")
		[HttpGet]
		public async Task<IActionResult> Get(DaprClient daprClient, string mensaje)
		{

			await daprClient.PublishEventAsync("pubsub", "topicNameMensajes", new { mensaje = mensaje, fecha = DateTime.Now });

			return Ok();
		}
	}
}
