using TutorialAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using TutorialAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace TutorialAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuperHeroController(DataContext context) : ControllerBase
    {
        private readonly DataContext _context = context;

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            var superHeroes = await _context.SuperHeroes.ToListAsync();
            return Ok(superHeroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);

            if (hero is null)
                return NotFound("Hero Not Found");
            return Ok(hero);
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero UpdatedHero)
        {
            var DbHero = await _context.SuperHeroes.FindAsync(UpdatedHero.Id);
            if (DbHero is null)
                return NotFound("Hero Not Found");
            
            DbHero.Name = UpdatedHero.Name;
            DbHero.FirstName = UpdatedHero.FirstName;
            DbHero.LastName = UpdatedHero.LastName;
            DbHero.Place = UpdatedHero.Place;
            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero Hero)
        {
            _context.SuperHeroes.Add(Hero);
            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SuperHero>> DeleteHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero is null)
                return NotFound("Hero Not Found");

            _context.SuperHeroes.Remove(hero);
            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }
    }
}