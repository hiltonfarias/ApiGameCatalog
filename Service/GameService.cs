using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

using ApiGameCatalog.InputModel;
using ApiGameCatalog.Repositories;
using ApiGameCatalog.ViewModel;
using ApiGameCatalog.Exceptions;
using ApiGameCatalog.Entities;

namespace ApiGameCatalog.Service
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<GameViewModel> GetGame(Guid id)
        {
            var game = await _gameRepository.GetGame(id);
            if (game == null)
                return null;
            return new GameViewModel
            {
                Id = game.Id,
                Name = game.Name,
                Producer = game.Producer,
                Price = game.Price
            };
        }

        public async Task<List<GameViewModel>> GetGames(int page, int quantity)
        {
            var games = await _gameRepository.GetPaginationGames(page,quantity);
            return games.Select(game => new GameViewModel{
                Id = game.Id,
                Name = game.Name,
                Producer = game.Producer,
                Price = game.Price
            }).ToList();
        }

        public void Dispose()
        {
            _gameRepository?.Dispose();
        }

        public async Task<GameViewModel> Insert(GameInputModel gameInputModel)
        {
            var entityGame = await _gameRepository.GetGames(gameInputModel.Name, gameInputModel.Producer);
            
            if(entityGame.Count > 0)
                throw new GameAlreadyRegisteredException();
            
            var insertGame = new Game
            {
                Id = Guid.NewGuid(),
                Name = gameInputModel.Name,
                Producer = gameInputModel.Producer,
                Price = gameInputModel.Price
            };

            await _gameRepository.InsertGame(insertGame);
            return new GameViewModel
            {
                Id = insertGame.Id,
                Name = insertGame.Name,
                Producer = insertGame.Producer,
                Price = insertGame.Price
            };
        }

        public async Task Remove(Guid id)
        {
            var game = _gameRepository.GetGame(id);
            
            if(game == null)
                throw new GameNotRegiteredException();
            
            await _gameRepository.Remove(id);
        }

        public async Task Update(Guid id, GameInputModel gameInputModel)
        {
            var entityGame = await _gameRepository.GetGame(id);

            if(entityGame == null)
                throw new GameNotRegiteredException();
            
            entityGame.Name = gameInputModel.Name;
            entityGame.Producer = gameInputModel.Producer;
            entityGame.Price = gameInputModel.Price;

            await _gameRepository.Update(entityGame);
        }

        public async Task Update(Guid id, double price)
        {
            var entityGame = await _gameRepository.GetGame(id);

            if(entityGame == null)
                throw new GameNotRegiteredException();
            
            entityGame.Price = price;
            await _gameRepository.Update(entityGame);
        }
    }
}