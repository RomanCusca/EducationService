using EducationService.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace EducationService.Service
{
	public class UserService
	{
		public IConfiguration _configuration { get; set; }

		public UserService(IConfiguration configuration)
		{
			_configuration = configuration;
		}


		internal async Task<bool> LoginAsync(UserLogin userLogin)
		{
			await using var dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
			await dbConnection.OpenAsync();

			var resul2t = await dbConnection.QueryAsync("SELECT * FROM Users", null, null, null,
				CommandType.Text);

			var result = await dbConnection.ExecuteAsync("prc_LoginUser", userLogin, null, null,
				CommandType.StoredProcedure);
			var isAdded = result == 1;

			return isAdded;
		}

		public async Task<bool> RegisterAsync(UserRegistration userRegistration)
		{
			await using var dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
			await dbConnection.OpenAsync();

			var result = await dbConnection.ExecuteAsync("prc_RegisterUser", userRegistration, null, null,
				CommandType.StoredProcedure);
			var isAdded = result == 1;

			return isAdded;
		}
	}
}
