using NashTechRookie.Models;
using Microsoft.AspNetCore.Mvc;
using NashTechRookie.Services;

namespace NashTechRookie.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;
        private readonly IPerson _person;

        public PersonController(IPersonService personService, IPerson person)
        {
            //_person = person;
            _personService = personService;
        }

        public IActionResult Index()
        {
            return View(_personService.GetAll());
        }

        public IActionResult GetMales()
        {
            var males = _personService.GetMales();

            return View(males);  // Pass data to the View
        }

        public IActionResult GetOldestPerson()
        {
            var oldestPerson = _personService.GetOldestPerson();

            return View(oldestPerson);
        }

        public IActionResult GetFullNames()
        {
            var fullNames = _personService.GetPersonsFullName();

            return View(fullNames);
        }

        public IActionResult GetBirthYearWithAction(string action)
        {
            if (string.IsNullOrEmpty(action))
            {
                ViewBag.Message = "Action is required";

                return View("Error");
            }

            var normalizedAction = action.ToLowerInvariant();

            return normalizedAction switch
            {
                "getbirthyearlower" => RedirectToAction("GetBirthYearLower"),
                "getbirthyeargreater" => RedirectToAction("GetBirthYearGreater"),
                "getbirthyearequal" => RedirectToAction("GetBirthYearEqual"),
                _ => View("Error", "Action not found"),
            };
        }

        public IActionResult GetBirthYearLower()
        {
            var persons = _personService.GetPersonsByBirthYearWithAction("lower");

            return View(persons);
        }

        public IActionResult GetBirthYearGreater()
        {
            var persons = _personService.GetPersonsByBirthYearWithAction("greater");

            return View(persons);
        }

        public IActionResult GetBirthYearEqual()
        {
            var persons = _personService.GetPersonsByBirthYearWithAction("equal");

            return View(persons);
        }

        public IActionResult ExportToExcel()
        {
            var fileResponse = _personService.ExportToExcel();

            return File(fileResponse.FileContent, fileResponse.ContentType, fileResponse.FileName);
        }

        [HttpPost]
        public IActionResult Create(Person person)
        {

            _person.Create(person);
            // If validation fails, return to the form with the current data
            return View(person);
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }

        public IActionResult ListAll()
        {
            var persons = _personService.GetAll();

            return View(persons);
        }
    }
}
