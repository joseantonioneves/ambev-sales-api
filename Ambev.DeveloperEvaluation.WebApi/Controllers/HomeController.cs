// Em Controllers/HomeController.cs
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Redirect("/swagger");
        }
    }
}