using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pokedex.Data;
using pokedex.Models;

namespace pokedex.Controllers
{
    public class PokemonController : Controller
    {
        private PokedexContext _context;
        public PokemonController(PokedexContext context)
        {
            _context = context;
        }

        public IActionResult Nuevo() {
            return View();
        }

        [HttpPost]
        public IActionResult Nuevo(Pokemon p) {
            if (ModelState.IsValid) {
                // Guardar el objeto Pokemon (p)
                _context.Add(p);
                _context.SaveChanges();
                
                return RedirectToAction("Lista");
            }
            
            return View(p);
        }

        public IActionResult Lista() {
            var pokemones = _context.Pokemones.OrderBy(x => x.Nombre).ToList();
            return View(pokemones);
        }
    }
}