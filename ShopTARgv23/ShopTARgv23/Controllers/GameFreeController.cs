using Microsoft.AspNetCore.Mvc;
using ShopTARgv23.Core.Dto.GameFreeDto;
using ShopTARgv23.Core.ServiceInterface;
using ShopTARgv23.Models.GameFrees;
using System.Threading.Tasks;

namespace ShopTARgv23.Controllers
{
    public class GameFreeController : Controller
    {
        public IActionResult Index()
        {
            var result = _gameFreeServices.GameFreeResult(new GameFreeResultDto());




            return View(result);
        }


        private readonly IGameFreeServices _gameFreeServices;

        public GameFreeController(IGameFreeServices gameFreeServices)
        {
            _gameFreeServices = gameFreeServices;
        }



       
    }
}
