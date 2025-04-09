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
	public class LibraryService : BaseService, ILibraryRepository<GameCopy>
	{
		public LibraryService(IConfiguration config) : base(config, "Main-DB")	{ }

		//For debug
		public IEnumerable<GameCopy> GetAll()
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Library_GetAll";
					command.CommandType = CommandType.StoredProcedure;
					connection.Open();
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							yield return reader.ToGameCopy();
						}
					}
				}
			}
		}

		public IEnumerable<GameCopy> GetByGameId(int game_id)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Library_GetByGameId";
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddWithValue(nameof(GameCopy.Game_Id), game_id);
					connection.Open();
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							yield return reader.ToGameCopy();
						}
					}
				}
			}
		}

		public GameCopy GetById(int id)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Library_GetById";
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddWithValue(nameof(GameCopy.Game_Copy_Id), id);
					connection.Open();
					using(SqlDataReader reader = command.ExecuteReader())
					{
						if (reader.Read())
						{
							return reader.ToGameCopy();
						}
						throw new ArgumentOutOfRangeException(nameof(id));
					}

				}
			}
		}

		public IEnumerable<GameCopy> GetByUserId(Guid user_id)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Library_GetByUserId";
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddWithValue(nameof(GameCopy.User_Id), user_id);
					connection.Open();
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							yield return reader.ToGameCopy();
						}
					}
				}
			}
		}

		public int Insert(GameCopy gameCopy)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Library_Insert";
					command.CommandType = CommandType.StoredProcedure;
					//Parameters
					command.Parameters.AddWithValue(nameof(GameCopy.State), gameCopy.State);
					command.Parameters.AddWithValue(nameof(GameCopy.Game_Id), gameCopy.Game_Id);
					command.Parameters.AddWithValue(nameof(GameCopy.User_Id), gameCopy.User_Id);

					connection.Open();
					return (int)command.ExecuteScalar();
				}
			}
		}

		public void Update(int id, GameCopy gameCopy)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Library_Update";
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddWithValue(nameof(GameCopy.Game_Copy_Id), id);
					command.Parameters.AddWithValue(nameof(GameCopy.State), gameCopy.State);
					connection.Open();
					command.ExecuteNonQuery();
				}
			}
		}

		public void Delete(int id)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_Library_Delete";
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddWithValue(nameof(GameCopy.Game_Copy_Id), id);
					connection.Open();
					command.ExecuteNonQuery();
				}
			}
		}
	}
}
