using ShopTARgv23.Core.Dto.GameFreeDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARgv23.Core.ServiceInterface
{
    public interface IGameFreeServices
    {
        Task<GameFreeResultDto> GameFreeResult(GameFreeResultDto dto);
    }
}
