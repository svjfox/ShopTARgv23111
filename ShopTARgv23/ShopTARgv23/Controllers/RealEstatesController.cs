using Microsoft.AspNetCore.Mvc;
using ShopTARgv23.Core.Dto;

namespace ShopTARgv23.Controllers
{
    public class RealEstatesController : Controller
    {
        //teha index vaade
        //racendus peab naitama index vaadet koos andmetega
        //create meetotit ei tee valmis
        //andmete sisestate andmebaasi kasitsi
        public IActionResult Index()
        {
           
            var realEstates = new List<RealEstateDto>
    {
        new RealEstateDto
        {
            Id = Guid.NewGuid(),
            Location = "City Center",
            Size = 120.5,
            RoomNumber = 3,
            BuildingType = "Apartment",
            CreatedAt = DateTime.Now.AddMonths(-2),
            ModifiedAt = DateTime.Now
        },
        new RealEstateDto
        {
            Id = Guid.NewGuid(),
            Location = "Suburbs",
            Size = 240,
            RoomNumber = 5,
            BuildingType = "House",
            CreatedAt = DateTime.Now.AddYears(-1),
            ModifiedAt = DateTime.Now.AddMonths(-1)
        }
    };

            return View(realEstates);
        }
    }
}
