using ShopTARgv23.Core.Dto.ThecocktaildbDto;

namespace ShopTARgv23.Core.ServiceInterface
{
    public interface IThecocktaildbServices
    {
        Task<List<CocktailRootDto>> GetCocktail();


    }
}
