using Microsoft.AspNetCore.Mvc;
using ShopTARgv23.Data;
using ShopTARgv23.Models.RealEstates;

namespace ShopTARgv23.Controllers
{
    public class RealEstatesController : Controller
    {
        private readonly ShopTARgv23Context _context;

        public RealEstatesController
            (
                ShopTARgv23Context context
            )
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var result = _context.RealEstates
                .Select(x => new RealEstatesIndexViewModel
                {
                    Id = x.Id,
                    Location = x.Location,
                    Size = x.Size,
                    RoomNumber = x.RoomNumber,
                    BuildingType = x.BuildingType,
                });

            return View(result);
        }

        public IActionResult Create()
        {
            RealEstateCreateUpdateViewModel realEstate = new();

            return View("CreateUpdate", realEstate);
        }


    }
}