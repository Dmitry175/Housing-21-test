using CsvHelper.Configuration;
using CsvHelper;
using Housing_21_test.Controllers;
using Housing_21_test.Interfaces;
using Housing_21_test.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using System.Text;
using System.Reflection;

namespace Housing_21_test.Pages
{


	public class DisplayPersonsModel : PageModel
    {
		private readonly IPersonRepository _personRepository;
		public List<Person> Persons { get; set; } = new List<Person>();

		public DisplayPersonsModel(IPersonRepository personRepository)
		{
			_personRepository = personRepository;
		}
		public async Task OnGet()
        {
			var persons = await _personRepository.GetPersons();
            Persons = persons;
        }

       
	}
}
