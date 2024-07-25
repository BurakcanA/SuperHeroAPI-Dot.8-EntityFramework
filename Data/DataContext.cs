using Microsoft.EntityFrameworkCore;
using TutorialAPI.Entities;

namespace TutorialAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<SuperHero> SuperHeroes { get;}
    }

}