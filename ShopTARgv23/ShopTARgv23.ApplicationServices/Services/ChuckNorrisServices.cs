using Nancy.Json;
using ShopTARgv23.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARgv23.ApplicationServices.Services
{
    public class ChuckNorrisServices
    {
        public async Task<ChuckNorrisJokeDto> GetRandomJoke(ChuckNorrisJokeDto dto)
        {
            string url = "https://api.chucknorris.io/jokes/random";

           using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                ChuckNorrisJokeDto joke = new JavaScriptSerializer().Deserialize<ChuckNorrisJokeDto>(json);

                dto.icon_url = joke.icon_url;
                dto.id = joke.id;
                dto.url = joke.url;
                dto.value = joke.value;
            }

            return dto;
        }
    }
}
