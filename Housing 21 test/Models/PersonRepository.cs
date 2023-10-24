using Housing_21_test.Interfaces;
using Housing_21_test.Models;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;
using Housing_21_test.Exceptions;

namespace Housing_21_test.Controllers
{
	public class PersonRepository : IPersonRepository
	{
		private readonly IConfiguration _configuration;

		public PersonRepository(IConfiguration configuration)
		{
			_configuration = configuration;
		}


		public async Task<IEnumerable<T>> QueryAsync<T>(string sql)
		{
			using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
			{
				return await connection.QueryAsync<T>(sql);
			}
		}

		public async Task AddPerson(Person person)
		{
			if(person == null)
			{
				throw new PersonNullException();
			}
			string formattedDate = person.DateOfBirth.ToString("yyyy-MM-dd");

			string sql = $"INSERT INTO [dbo].[Persons] ([Name], [DateOfBirth], [TelephoneNumber], [Email]) " +
						 $"VALUES ('{person.Name}','{formattedDate}', '{person.TelephoneNumber}', '{person.Email}')";

			await QueryAsync<Person>(sql);
		}

		public async Task<List<Person>> GetPersons()
		{
			string sql = $"SELECt * FROM [dbo].[Persons]";

			var result = await QueryAsync<Person>(sql);

			return result.ToList();
		}
	}
}
