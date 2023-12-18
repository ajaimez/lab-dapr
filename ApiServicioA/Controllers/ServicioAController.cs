using Dapr.Client;
using Microsoft.AspNetCore.Mvc;

namespace ApiServicioA.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ServicioAController : ControllerBase
	{
		
		//[HttpGet(Name = "GetWeatherForecast")
		public async Task<IActionResult> Get(DaprClient daprClient)
		{

			await daprClient.PublishEventAsync("pubsub", "topicName", new { mensaje = "Hola", fecha = DateTime.Now });

			return Ok();
		}
	}
}
