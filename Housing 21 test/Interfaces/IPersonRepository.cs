using Dapper;
using Housing_21_test.Models;
using System.Data.SqlTypes;

namespace Housing_21_test.Interfaces
{
    public interface IPersonRepository
    {
        public Task AddPerson(Person person);

		public Task<List<Person>> GetPersons();

        public Task<IEnumerable<T>> QueryAsync<T>(string sql);
    }
}
