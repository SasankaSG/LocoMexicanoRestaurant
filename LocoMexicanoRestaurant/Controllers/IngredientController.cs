using LocoMexicanoRestaurant.Data;
using LocoMexicanoRestaurant.Models;
using Microsoft.AspNetCore.Mvc;

namespace LocoMexicanoRestaurant.Controllers
{
	public class IngredientController : Controller
	{
		private Repository<Ingredient> ingredients;
		public IngredientController(ApplicationDbContext context)
		{
			ingredients = new Repository<Ingredient>(context);

		}
		public async Task<IActionResult> Index()
		{
			return View(await ingredients.GetAllAsync());
		}

		public async Task<IActionResult> Details(int id)
		{
			//ingredient to include product ingredients and the product it is asscoiated with

			return View(await ingredients.GetByIdAsync(id, new QueryOptions<Ingredient>() { Includes = "ProductIngredients.Product" }));
		}

		//Ingredient/Create
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("IngredientId, Name")] Ingredient ingredient)
		{
			if (ModelState.IsValid)
			{
				await ingredients.AddAsync(ingredient);
				return RedirectToAction("Index");
			}
			return View(ingredient);
		}

		//ingredient/delete
		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			return View(await ingredients.GetByIdAsync(id, new QueryOptions<Ingredient> { Includes = "ProductIngredients.Product" }));
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Delete(Ingredient ingredient)
		{
			await ingredients.DeleteAsync(ingredient.IngredientId);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			return View(await ingredients.GetByIdAsync(id, new QueryOptions<Ingredient> { Includes = "ProductIngredients.Product" }));
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(Ingredient ingredient)
		{
			if (ModelState.IsValid) 
			{
				await ingredients.UpdateAsync(ingredient);
				return RedirectToAction("Index");
			}
			return View(ingredient);
		}
	}
}
