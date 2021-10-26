using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using ApiGameCatalog.InputModel;
using ApiGameCatalog.ViewModel;

namespace ApiGameCatalog.Service
{
    public interface IGameService : IDisposable
    {
        Task<List<GameViewModel>> GetGames(int page, int quantity);
        Task<GameViewModel> GetGame(Guid id);
        Task<GameViewModel> Insert(GameInputModel gameInputModel);
        Task Update(Guid id, GameInputModel gameInputModel);
        Task Update(Guid id, double price);
        Task Remove(Guid id);
    }
}