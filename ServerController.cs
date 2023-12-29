using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
namespace Galytix.WebApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ServerController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        [Route("ping")]
        public async Task<IActionResult> Ping()
        {
            // Simulate some CPU-bound work
            await Task.Run(() => {
                Thread.Sleep(500); // Example of a time-consuming task
            });

            return Ok("pong");
        }
    }
}
