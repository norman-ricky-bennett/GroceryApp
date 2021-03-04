using GroceryAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace GroceryAppAPI.Controllers
{
    public class RecipeController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        [HttpPost]
        public async Task<IHttpActionResult> CreateRecipe(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                _context.Recipes.Add(recipe);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest(ModelState);
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetAllRecipes()
        {
            List<Recipe> recipes = await _context.Recipes.ToListAsync();
            return Ok(recipes);
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetRecipeById(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == default)
            {
                return NotFound();
            }
            return Ok(recipe);
        }
    }
}
