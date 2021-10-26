using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using ApiGameCatalog.Entities;

namespace ApiGameCatalog.Repositories
{
    public interface IGameRepository : IDisposable
    {
        Task<List<Game>> GetPaginationGames(int page, int quantity);
        Task<Game> GetGame(Guid id);
        Task<List<Game>> GetGames(string name, string producer);
        Task InsertGame(Game game);
        Task Update(Game game);
        Task Remove(Guid id);
    }
}