using NashTechRookie.Models;
using Microsoft.AspNetCore.Mvc;
using NashTechRookie.Services;

namespace NashTechRookie.Controllers
{
    public class PersonController(IPersonService personService) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(personService.GetAll());
        }

        [HttpGet]
        public IActionResult GetMales()
        {
            var males = personService.GetMales();
            return View(males);
        }

        [HttpGet]
        public IActionResult GetOldestPerson()
        {
            var oldestPerson = personService.GetOldestPerson();
            return View(oldestPerson);
        }

        [HttpGet]
        public IActionResult GetFullNames()
        {
            var fullNames = personService.GetPersonsFullName();
            return View(fullNames);
        }

        [HttpGet]
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

        [HttpGet]
        public IActionResult GetBirthYearLower()
        {
            var persons = personService.GetPersonsByBirthYearWithAction("lower");
            return View(persons);
        }

        [HttpGet]
        public IActionResult GetBirthYearGreater()
        {
            var persons = personService.GetPersonsByBirthYearWithAction("greater");
            return View(persons);
        }

        [HttpGet]
        public IActionResult GetBirthYearEqual()
        {
            var persons = personService.GetPersonsByBirthYearWithAction("equal");
            return View(persons);
        }

        [HttpGet]
        public IActionResult ExportToExcel()
        {
            var fileResponse = personService.ExportToExcel();
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
            if (person != null)
            {
                personService.Create(person);
                return RedirectToAction("Index");
            }
            return View(person);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var person = personService.GetPersonById(id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

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
                    personService.Update(person);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred while updating the person: " + ex.Message);
                }
            }
            return View(person);
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var person = personService.GetPersonById(id);
            if (person == null)
            {
                return NotFound();
            }

            try
            {
                string deletedPersonName = person.FullName;
                personService.Delete(id);
                return RedirectToAction("Confirmation", new { deletedPersonName });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"An error occurred while deleting the person: {ex.Message}";
                return RedirectToAction("Details", new { id });
            }
        }

        [HttpGet]
        public IActionResult Confirmation(string deletedPersonName)
        {
            return View((object)deletedPersonName);
        }

        [HttpGet]
        public IActionResult ListAll()
        {
            var persons = personService.ListAll();
            return View(persons);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var person = personService.GetPersonById(id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }
    }
}
