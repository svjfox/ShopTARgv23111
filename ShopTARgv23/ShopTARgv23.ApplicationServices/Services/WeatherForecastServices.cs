using Nancy.Json;
using ShopTARgv23.Core.Dto.WeatherDtos;
using ShopTARgv23.Core.ServiceInterface;
using System.Net;


namespace ShopTARgv23.ApplicationServices.Services
{
    public class WeatherForecastServices : IWeatherForecastServices
    {

        public async Task<AccuLocationWeatherResultDto> AccuWeatherResult(AccuLocationWeatherResultDto dto)
        {
            string accuApiKey = "2LBA498kppCQjyb9ZAh5IgNuMYgZZDEr";
            string url = $"http://dataservice.accuweather.com/locations/v1/cities/search?apikey={accuApiKey}&q={dto.CityName}";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                List<AccuLocationRootDto> accuResult = new JavaScriptSerializer().Deserialize<List<AccuLocationRootDto>>(json);

                dto.CityName = accuResult[0].LocalizedName;
                dto.CityCode = accuResult[0].Key;
                dto.Rank = accuResult[0].Rank;

            }

            string urlWeather = $"http://dataservice.accuweather.com/currentconditions/v1/daily/1day/{dto.CityCode}?apikey={accuApiKey}&metric=true";


            return dto;
        }
    }
}