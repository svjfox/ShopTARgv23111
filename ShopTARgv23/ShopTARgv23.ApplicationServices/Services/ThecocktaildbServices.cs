using ShopTARgv23.Core.Dto.ThecocktaildbDto;
using ShopTARgv23.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShopTARgv23.ApplicationServices.Services
{
    public class ThecocktaildbServices : IThecocktaildbServices
    {
        public  async Task<List<CocktailRootDto>> GetCocktail()
        {
            var url = "https://www.thecocktaildb.com/api/json/v1/1/search.php?s=margarita";
            List<CocktailRootDto> cocktailList = new List<CocktailRootDto>();
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                var cocktailResults = JsonSerializer
                    .Deserialize<CocktailRootDto>(json);
                if (cocktailResults != null)
                {
                    cocktailList.AddRange((IEnumerable<CocktailRootDto>)cocktailResults);
                }
            }
            return cocktailList;
        }
    }
}
