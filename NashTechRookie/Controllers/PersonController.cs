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
            _person = person;
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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Person person)
        {
            Console.WriteLine("Person");
            Console.WriteLine(person);
            if (person != null)
            {
                _person.Create(person);
                return RedirectToAction("Index");
            }
            return View(person);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var person = _personService.GetPersonById(id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        // POST: Handle the Edit form submission
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Person person)
        {
            if (id != person.Id)
            {
                ModelState.AddModelError("", "The ID in the URL does not match the ID of the person being edited.");
                return View(person);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _person.Update(person);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred while updating the person: " + ex.Message);
                }
            }
            return View(person);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var person = _personService.GetPersonById(id);
            if (person == null)
            {
                return NotFound();
            }

            try
            {
                string deletedPersonName = person.FullName; // Store the name before deleting
                _person.Delete(person);
                return RedirectToAction("Confirmation", new { deletedPersonName });
            }
            catch (Exception ex)
            {
                // If deletion fails, redirect back to the Details view with an error message
                TempData["ErrorMessage"] = $"An error occurred while deleting the person: {ex.Message}";
                return RedirectToAction("Details", new { id });
            }
        }

        // GET: Display the confirmation message after deletion
        [HttpGet]
        public IActionResult Confirmation(string deletedPersonName)
        {
            return View((object)deletedPersonName);
        }


        public IActionResult ListAll()
        {
            var persons = _person.ListAll();

            return View(persons);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var person = _personService.GetPersonById(id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }
    }
}
