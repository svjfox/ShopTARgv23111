using Microsoft.AspNetCore.Mvc;
using ShopTARgv23.Core.ServiceInterface;
using ShopTARgv23.Models.Thecocktaildbs;

namespace ShopTARgv23.Controllers
{
    public class CocktailController : Controller
    {
        private readonly IThecocktaildbServices _cocktailService;

        public CocktailController(IThecocktaildbServices cocktailService)
        {
            _cocktailService = cocktailService;
        }

        public async Task<IActionResult> Index()
        {
            var cocktails = await _cocktailService.GetCocktail();
            return View(cocktails);
        }
    }
}
