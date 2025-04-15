using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using NashTechRookie.Utils;
using NashTechRookie.Controllers;
using NashTechRookie;
using NashTechRookie.Services;
using NashTechRookie.Models;

namespace PersonMVC.Test.Controllers;

[TestFixture]
public class PersonControllerTest
{
    [TestFixture]
    public class PersonControllerTests
    {
        private Mock<IPersonService> _personServiceMock;
        private PersonController _personController;

        [SetUp]
        public void SetUp()
        {
            _personServiceMock = new Mock<IPersonService>();
            _personController = new PersonController(_personServiceMock.Object);
        }

        [Test]
        public void GetBirthYearWithAction_EmptyAction_ReturnsErrorViewWithMessage()
        {
            // Act
            var result = _personController.GetBirthYearWithAction("") as ViewResult;

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.ViewName, Is.EqualTo("Error"));
            Assert.That(_personController.ViewBag.Message, Is.EqualTo("Action is required"));
        }

        [TestCase("getbirthyearlower")]
        [TestCase("GetBirthYearLower")]
        public void GetBirthYearWithAction_LowerAction_ReturnsRedirectToLower(string action)
        {
            // Act
            var result = _personController.GetBirthYearWithAction(action) as RedirectToActionResult;

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.ActionName, Is.EqualTo("GetBirthYearLower"));
        }

        [TestCase("getbirthyeargreater")]
        [TestCase("GetBirthYearGreater")]
        public void GetBirthYearWithAction_GreaterAction_ReturnsRedirectToGreater(string action)
        {
            // Act
            var result = _personController.GetBirthYearWithAction(action) as RedirectToActionResult;

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.ActionName, Is.EqualTo("GetBirthYearGreater"));
        }

        [TestCase("getbirthyearequal")]
        [TestCase("GetBirthYearEqual")]
        public void GetBirthYearWithAction_EqualAction_ReturnsRedirectToEqual(string action)
        {
            // Act
            var result = _personController.GetBirthYearWithAction(action) as RedirectToActionResult;

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.ActionName, Is.EqualTo("GetBirthYearEqual"));
        }

        [TestCase("invalidaction")]
        public void GetBirthYearWithAction_InvalidAction_ReturnsErrorViewWithModel(string action)
        {
            // Act
            var result = _personController.GetBirthYearWithAction(action) as ViewResult;

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.ViewName, Is.EqualTo("Error"));
            // The controller calls: View("Error", "Action not found")
            Assert.That(result.Model, Is.EqualTo("Action not found"));
        }

        [Test]
        public void GetBirthYearLower_CallsServiceAndReturnsViewWithModel()
        {
            // Arrange
            var expected = new List<Person> { new(1, "Rebecca", "Chambers", Gender.Female, new DateTime(1994, 9, 9), "901-234-5678", "Dallas", true) };
            _personServiceMock
                .Setup(x => x.GetPersonsByBirthYearWithAction("lower"))
                .Returns(expected);

            // Act
            var result = _personController.GetBirthYearLower() as ViewResult;

            // Assert
            _personServiceMock.Verify(x => x.GetPersonsByBirthYearWithAction("lower"), Times.Once);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Model, Is.SameAs(expected));
        }

        [Test]
        public void GetBirthYearGreater_CallsServiceAndReturnsViewWithModel()
        {
            // Arrange
            var expected = new List<Person> { new(1, "Rebecca", "Chambers", Gender.Female, new DateTime(1994, 9, 9), "901-234-5678", "Dallas", true) };
            _personServiceMock
                .Setup(x => x.GetPersonsByBirthYearWithAction("greater"))
                .Returns(expected);

            // Act
            var result = _personController.GetBirthYearGreater() as ViewResult;

            // Assert
            _personServiceMock.Verify(x => x.GetPersonsByBirthYearWithAction("greater"), Times.Once);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Model, Is.SameAs(expected));
        }

        [Test]
        public void GetBirthYearEqual_CallsServiceAndReturnsViewWithModel()
        {
            // Arrange
            var expected = new List<Person> { new(1, "Rebecca", "Chambers", Gender.Female, new DateTime(1994, 9, 9), "901-234-5678", "Dallas", true) };
            _personServiceMock
                .Setup(x => x.GetPersonsByBirthYearWithAction("equal"))
                .Returns(expected);

            // Act
            var result = _personController.GetBirthYearEqual() as ViewResult;

            // Assert
            _personServiceMock.Verify(x => x.GetPersonsByBirthYearWithAction("equal"), Times.Once);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Model, Is.SameAs(expected));
        }


        [Test]
        public void Create_Get_ReturnsDefaultView()
        {
            // Act
            var result = _personController.Create() as ViewResult;

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.ViewName, Is.Null.Or.Empty, "Create GET should return the default view");
        }

        [Test]
        public void Create_ValidModel_RedirectsToIndex()
        {
            // Arrange
            var person = new Person(1, "Rebecca", "Chambers", Gender.Female,
                new DateTime(1994, 9, 9), "901-234-5678", "Dallas", true);

            // Act
            var result = _personController.Create(person) as RedirectToActionResult;

            // Assert
            _personServiceMock.Verify(x => x.Create(person), Times.Once);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.ActionName, Is.EqualTo("Index"));
        }

        [Test]
        public void Details_ExistingId_ReturnsDetailView()
        {
            // Arrange
            var p = new Person(1, "Rebecca", "Chambers", Gender.Female,
                new DateTime(1994, 9, 9), "901-234-5678", "Dallas", true);
            _personServiceMock.Setup(x => x.GetPersonById(1)).Returns(p);

            // Act
            var result = _personController.Details(1) as ViewResult;

            // Assert
            _personServiceMock.Verify(x => x.GetPersonById(1), Times.Once);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Model, Is.SameAs(p));
        }

        [Test]
        public void Details_NonexistentId_ReturnsNotFound()
        {
            // Arrange
            _personServiceMock.Setup(x => x.GetPersonById(42)).Returns((Person)null);

            // Act
            var result = _personController.Details(42);

            // Assert
            Assert.That(result, Is.TypeOf<NotFoundResult>());
        }

        [Test]
        public void Confirmation_Get_ReturnsViewWithModel()
        {
            // Act
            var result = _personController.Confirmation("Foo") as ViewResult;

            Assert.That(result, Is.Not.Null);
            Assert.That(result.ViewName, Is.Null.Or.Empty, "Expected default view name when none is specified");
            Assert.That(result.Model, Is.EqualTo("Foo"));
        }


        [Test]
        public void Delete_ExistingId_RedirectsToConfirmation()
        {
            // Arrange
            var tempData = new TempDataDictionary(new DefaultHttpContext(), Mock.Of<ITempDataProvider>());
            _personController.TempData = tempData;

            var person = new Person(1, "Rebecca", "Chambers", Gender.Female,
                new DateTime(1994, 9, 9), "901-234-5678", "Dallas", true);
            _personServiceMock.Setup(x => x.GetPersonById(1)).Returns(person);

            // Act
            var result = _personController.Delete(1) as RedirectToActionResult;

            // Assert
            _personServiceMock.Verify(x => x.Delete(person.Id), Times.Once);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.ActionName, Is.EqualTo("Confirmation"));
            Assert.That(result.RouteValues["deletedPersonName"], Is.EqualTo(person.FullName));
        }

        [Test]
        public void Edit_ExistingId_ReturnsDefaultViewWithModel()
        {
            // Arrange
            var person = new Person(2, "Albert", "Wesker", Gender.Male,
                new DateTime(2000, 10, 10), "012-345-6789", "Austin", false);
            _personServiceMock.Setup(x => x.GetPersonById(2)).Returns(person);

            // Act
            var result = _personController.Edit(2) as ViewResult;

            // Assert
            _personServiceMock.Verify(x => x.GetPersonById(2), Times.Once);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.ViewName, Is.Null.Or.Empty, "Edit GET should return default view");
            Assert.That(result.Model, Is.SameAs(person));
        }


        [Test]
        public void Edit_NonexistentId_ReturnsNotFound()
        {
            // Arrange
            _personServiceMock.Setup(x => x.GetPersonById(99)).Returns((Person)null);

            // Act
            var result = _personController.Edit(99);

            // Assert
            Assert.That(result, Is.TypeOf<NotFoundResult>());
        }

        [Test]
        public void Edit_ValidModel_RedirectsToIndex()
        {
            // Arrange
            var person = new Person(3, "Ada", "Wong", Gender.Female,
                new DateTime(1990, 11, 11), "123-987-6543", "San Francisco", true);

            // Act
            var result = _personController.Edit(3, person) as RedirectToActionResult;

            // Assert
            _personServiceMock.Verify(x => x.Update(person), Times.Once);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.ActionName, Is.EqualTo("Index"));
        }



        [Test]
        public void ExportToExcel_ReturnsFileContentResult()
        {
            // Arrange
            var persons = new List<Person>
            {
                new Person(1, "Rebecca", "Chambers", Gender.Female,   new DateTime(1994,  9,  9), "901-234-5678", "Dallas",        true),
                new Person(2, "Albert",  "Wesker",   Gender.Male,     new DateTime(2000, 10, 10), "012-345-6789", "Austin",        false),
                new Person(3, "Ada",     "Wong",     Gender.Female,   new DateTime(1990, 11, 11), "123-987-6543", "San Francisco", true),
                new Person(4, "Carlos",  "Oliveira", Gender.Male,     new DateTime(2003, 12, 12), "234-876-5432", "Seattle",       false),
                new Person(5, "Barry",   "Burton",   Gender.Male,     new DateTime(2004,  5, 20), "345-765-4321", "Boston",        true),
                new Person(6, "Hunk",    "Unknown",  Gender.Male,     new DateTime(1982,  6, 15), "456-654-3210", "Miami",         false),
                new Person(7, "Sheva",   "Alomar",   Gender.Female,   new DateTime(2005,  7, 25), "567-543-2109", "Denver",        true),
                new Person(8, "Josh",    "Stone",    Gender.Male,     new DateTime(1984,  8, 30), "678-432-1098", "Atlanta",       true),
                new Person(9, "Sherry",  "Birkin",   Gender.Female,   new DateTime(1997,  9, 18), "789-321-0987", "Portland",      false),
                new Person(10,"Billy",   "Coen",     Gender.Male,     new DateTime(2001, 10,  5), "890-210-9876", "Las Vegas",     true),
                new Person(11,"Piers",   "Nivans",   Gender.Male,     new DateTime(1992, 11, 22), "901-109-8765", "Nashville",     false),
            };

            // Generate the raw Excel bytes
            var excelBytes = FileHelper<Person>.GenerateExcelFile(persons);

            // Wrap into your FileResponse
            const string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            var filename = $"Persons_{timestamp}.xlsx";
            var fileResponse = new FileModel(excelBytes, contentType, filename);

            _personServiceMock
                .Setup(s => s.ExportToExcel())
                .Returns(fileResponse);

            // Act
            var result = _personController.ExportToExcel() as FileContentResult;

            // Assert
            _personServiceMock.Verify(s => s.ExportToExcel(), Times.Once);

            Assert.That(result, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(result.ContentType, Is.EqualTo(contentType));
                Assert.That(result.FileContents, Is.EqualTo(excelBytes));
                Assert.That(result.FileDownloadName, Is.EqualTo(filename));
            });
        }


        [TearDown]
        public void TearDown()
        {
            _personController.Dispose();
        }
    }
}