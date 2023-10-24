using Housing_21_test.Interfaces;
using Housing_21_test.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Globalization;

namespace Housing_21_test.Pages
{
	public class IndexModel : PageModel
	{

		private readonly IPersonRepository _personRepository;

		[BindProperty]
		public Person Person { get; set; }

		public List<Person> Persons { get; set; }

		public IndexModel(IPersonRepository personRepository)
		{
			_personRepository = personRepository;
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (string.IsNullOrEmpty(Person.Name) || Person.DateOfBirth == DateTime.MinValue
			|| string.IsNullOrEmpty(Person.TelephoneNumber) || string.IsNullOrEmpty(Person.Email))
			{
				ModelState.AddModelError("", "Please fill out all required fields.");
			}
			else
			{
				try
				{
					await _personRepository.AddPerson(Person);
				}
				catch (Exception ex)
				{
					ModelState.AddModelError("", ex.Message);

				}
			}
			return Page();

		}
		public async Task OnGetAsync()
		{
			
		}


	}
}