using Microsoft.AspNetCore.Mvc;
using ShopTARgv23.Core.Dto.WeatherDtos;
using ShopTARgv23.Core.ServiceInterface;
using ShopTARgv23.Models.AccuWeathers;

namespace ShopTARgv23.Controllers
{
    public class AccuWeathersController : Controller
    {
        private readonly IWeatherForecastServices _weatherForecastServices;

        public AccuWeathersController
            (
                IWeatherForecastServices weatherForecastServices
            )
        {
            _weatherForecastServices = weatherForecastServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchCity(AccuWeatherSearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "AccuWeathers", new { city = model.CityName });
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult City(string city)
        {

            AccuLocationWeatherResultDto dto = new();


             dto. CityName = city;
            _weatherForecastServices.AccuWeatherResult(dto);
            AccuWeatherViewModel vm = new();



            return View();
        }
    }
}