using TutorialAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace TutorialAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuperHeroController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeros()
        {
            var heroes = new List<SuperHero>
            {
                new SuperHero
                {
                    Id= 1,
                    Name = "Spiderman",
                    FirstName = "Peter",
                    LastName = "Parker",
                    Place = "NYC",
                }
            };
            return Ok(heroes);
        }
    }
}