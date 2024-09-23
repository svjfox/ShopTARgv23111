using Microsoft.AspNetCore.Mvc;
using ShopTARgv23.Data;
using ShopTARgv23.Models.Spaceships;

namespace ShopTARgv23.Controllers
{
    public class SpaceshipsController : Controller
    {
        private readonly ShopTARgv23Context _context;

        public SpaceshipsController
            (
                ShopTARgv23Context context
            )
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var result = _context.Spaceships
                .Select(x => new SpaceshipsIndexViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Type = x.Type,
                    BuiltDate = x.BuiltDate,
                    EnginePower = x.EnginePower
                });

            return View(result);
        }
    }
}
