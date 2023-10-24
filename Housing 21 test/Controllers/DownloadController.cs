using CsvHelper.Configuration;
using CsvHelper;
using Housing_21_test.Interfaces;
using Housing_21_test.Models;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Text;

namespace Housing_21_test.Controllers
{
    public class DownloadController : Controller
    {
        private readonly IPersonRepository _personRepository;

        public DownloadController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpGet]
        public async Task<IActionResult> DownloadCsv()
        {
            var persons = await _personRepository.GetPersons();

            var csvExport = GenerateCsv(persons);
            var bytes = Encoding.UTF8.GetBytes(csvExport);

            return File(bytes, "text/csv", "persons.csv");
        }
        private string GenerateCsv(List<Person> persons)
        {
            using var memoryStream = new MemoryStream();
            using var writer = new StreamWriter(memoryStream);
            using var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture));

            csv.WriteRecords(persons);

            writer.Flush();
            memoryStream.Seek(0, SeekOrigin.Begin);

            return Encoding.UTF8.GetString(memoryStream.ToArray());
        }
    }
}
