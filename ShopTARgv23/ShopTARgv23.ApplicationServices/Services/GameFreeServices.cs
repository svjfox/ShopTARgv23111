using Nancy.Json;
using ShopTARgv23.Core.Dto.GameFreeDto;
using ShopTARgv23.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace ShopTARgv23.ApplicationServices.Services
{
    public class GameFreeServices : IGameFreeServices
    {

        public async Task<GameFreeResultDto> GameFreeResult(GameFreeResultDto dto)
        {
          var url = "https://www.freetogame.com/api/games";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                GameFreeDto gameFreeResult = new JavaScriptSerializer().Deserialize<GameFreeDto>(json);

                dto.id = gameFreeResult.id;
                dto.title = gameFreeResult.title;
                dto.thumbnail = gameFreeResult.thumbnail;
                dto.short_description = gameFreeResult.short_description;
                dto.game_url = gameFreeResult.game_url;
                dto.genre = gameFreeResult.genre;
                dto.platform = gameFreeResult.platform;
                dto.publisher = gameFreeResult.publisher;
                dto.developer = gameFreeResult.developer;
                dto.release_date = gameFreeResult.release_date;
                dto.freetogame_profile_url = gameFreeResult.freetogame_profile_url;
            }

            return dto;





        }


    }
}
