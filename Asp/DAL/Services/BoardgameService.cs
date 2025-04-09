using Common.Repositories;
using DAL.Entities;
using DAL.Mappers;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
	public class BoardgameService : BaseService, IBoardgameRepository<Boardgame>
	{
		//Service injection
		public BoardgameService(IConfiguration config) : base(config,"Main-DB")	{ }

		//Methods
		public IEnumerable<Boardgame> GetAll()
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Boardgame_GetAll";
					command.CommandType = CommandType.StoredProcedure;
					connection.Open();
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							yield return reader.ToBoardgame();
						}
					}
				}
			}
		}

		public Boardgame GetById(int id)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Boardgame_GetById";
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddWithValue(nameof(Boardgame.Game_id), id);
					connection.Open();
					using (SqlDataReader reader = command.ExecuteReader())
					{
						if (reader.Read())
						{
							return reader.ToBoardgame();
						}
						throw new ArgumentOutOfRangeException(nameof(id));
					}
				}
			}
		}

		public int Insert(Boardgame game)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Boardgame_Insert";
					command.CommandType = CommandType.StoredProcedure;

					//Parameters
					command.Parameters.AddWithValue(nameof(Boardgame.Game_Title), game.Game_Title);
					command.Parameters.AddWithValue(nameof(Boardgame.Description), game.Description);
					command.Parameters.AddWithValue(nameof(Boardgame.MinAge), game.MinAge);
					command.Parameters.AddWithValue(nameof(Boardgame.MaxAge), game.MaxAge);
					command.Parameters.AddWithValue(nameof(Boardgame.MinPlayers), game.MinPlayers);
					command.Parameters.AddWithValue(nameof(Boardgame.MaxPlayers), game.MaxPlayers);
					command.Parameters.AddWithValue(nameof(Boardgame.Duration), (game.Duration is null)? DBNull.Value : game.Duration);
					command.Parameters.AddWithValue(nameof(Boardgame.Registerer), game.Registerer);

					connection.Open();
					return (int)command.ExecuteScalar();
				}
			}
		}
	}
}
