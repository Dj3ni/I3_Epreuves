
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
	public class UserService: BaseService, IUserRepository<User>
	{
		public UserService(IConfiguration config) : base(config, "Main-DB"){ }

		

		public IEnumerable<User> GetAll()
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_User_GetAllActive";
					command.CommandType = CommandType.StoredProcedure;
					connection.Open();
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							yield return reader.ToUser();
						}
					}
				}
			}
		}

		public User GetById(Guid id)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_User_GetById";
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddWithValue(nameof(User.User_Id), id);	
					connection.Open();
					using (SqlDataReader reader = command.ExecuteReader())
					{
						if (reader.Read())
						{
							return reader.ToUser();
						}

						throw new ArgumentOutOfRangeException(nameof(id));
					}
				}
			}
		}

		public Guid Insert(User user)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_User_Insert";
					command.CommandType = CommandType.StoredProcedure;
					//Parameters
					command.Parameters.AddWithValue(nameof(User.Pseudo), user.Pseudo);
					command.Parameters.AddWithValue(nameof(User.Email), user.Email);
					command.Parameters.AddWithValue(nameof(User.Password), user.Password);
					connection.Open();
					return (Guid)command.ExecuteScalar();
				}
			}
		}

		public void Update(Guid id, User user)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_User_Update";
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddWithValue(nameof(User.User_Id), id);
					command.Parameters.AddWithValue(nameof(User.Pseudo), user.Pseudo);
					command.Parameters.AddWithValue(nameof(User.Deactivation_Date), (user.Deactivation_Date is null)? DBNull.Value : user.Deactivation_Date);
					connection.Open();
					command.ExecuteNonQuery();
				}
			}
		}

		public Guid CheckPassword(string email, string password)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "SP_User_CheckPassword";
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddWithValue(nameof(User.Email), email);
					command.Parameters.AddWithValue(nameof(User.Password), password);
					connection.Open();
					return(Guid) command.ExecuteScalar();
				}
			}
		}
	}
}
