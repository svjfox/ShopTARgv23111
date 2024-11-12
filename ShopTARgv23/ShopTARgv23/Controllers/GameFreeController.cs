using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopTARgv23.Core.ServiceInterface;

namespace ShopTARgv23.Controllers
{
    public class GameFreeController : Controller
    {

        private readonly IGameFreeServices _gameFreeServices;

        public GameFreeController
            (
                IGameFreeServices gameFreeServices
            )
        {
            _gameFreeServices = gameFreeServices;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult SearchGameFree(IGameFreeServices model)
        {
            return RedirectToAction(nameof(GameFree));
        }
    
    }
}
