using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;

using ApiGameCatalog.Entities;

using Microsoft.Extensions.Configuration;

namespace ApiGameCatalog.Repositories
{
    public class GameSqlServerRepository : IGameRepository
    {
        private readonly SqlConnection sqlConnection;
        public GameSqlServerRepository(IConfiguration configuration)
        {
            sqlConnection = new SqlConnection(configuration.GetConnectionString("Default"));
        }

        public async Task<Game> GetGame(Guid id)
        {
            Game game = null;
            var query = $"select * from Games where Id = '{id}'";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            while (sqlDataReader.Read())
            {
                game = new Game
                {
                    Id = (Guid)sqlDataReader["Id"],
                    Name = (string)sqlDataReader["Name"],
                    Producer = (string)sqlDataReader["Producer"],
                    Price = (double)sqlDataReader["Price"]
                };
            }
            await sqlConnection.CloseAsync();
            return game;
        }

        public async Task<List<Game>> GetGames(string name, string producer)
        {
            var games = new List<Game>();
            var query = $"select * from Games where Name = '{name}' and Producer = '{producer}'";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            while (sqlDataReader.Read())
            {
                games.Add(new Game
                {
                    Id = (Guid)sqlDataReader["Id"],
                    Name = (string)sqlDataReader["Name"],
                    Producer = (string)sqlDataReader["Producer"],
                    Price = (double)sqlDataReader["Price"]
                });
            }
            await sqlConnection.CloseAsync();
            return games;
        }

        public async Task<List<Game>> GetPaginationGames(int page, int quantity)
        {
            var games = new List<Game>();
            var query = $"select * from Games order by id offset {((page - 1) * quantity)} rows fetch next {quantity} row only";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            while (sqlDataReader.Read())
            {
                games.Add(new Game
                {
                    Id = (Guid)sqlDataReader["Id"],
                    Name = (string)sqlDataReader["Name"],
                    Producer = (string)sqlDataReader["Producer"],
                    Price = (double)sqlDataReader["Price"]
                });
            }
            await sqlConnection.CloseAsync();
            return games;
        }

        public async Task InsertGame(Game game)
        {
            var query = $"insert Games (Id, Name, Producer, Price) values ('{game.Id}','{game.Name}','{game.Producer}','{game.Price.ToString().Replace(",", ".")}')";
            
            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            await sqlConnection.CloseAsync();
        }

        public async Task Remove(Guid id)
        {
            var query = $"delete from Games where Id = '{id}'";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            await sqlConnection.CloseAsync();
        }

        public async Task Update(Game game)
        {
            var query = $"update Games set Name = '{game.Name}', Producer = '{game.Producer}', Price = '{game.Price.ToString().Replace(",", ".")}')";
            
            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            await sqlConnection.CloseAsync();
        }

        public void Dispose()
        {
            sqlConnection?.Close();
            sqlConnection?.Dispose();
        }
    }
}