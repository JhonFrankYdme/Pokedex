using Microsoft.EntityFrameworkCore;
using pokedex.Models;

namespace pokedex.Data
{
    public class PokedexContext : DbContext
    {
        public DbSet<Pokemon> Pokemones { get; set; }

        public PokedexContext(DbContextOptions dco) : base(dco) {

        }
    }
}