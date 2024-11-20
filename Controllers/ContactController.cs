using Microsoft.AspNetCore.Mvc;
using Project.Models;

namespace Project.Controllers;

public class ContactController : Controller
{
    static private Dictionary<int, ContactModel> _contacts= new Dictionary<int, ContactModel>()
    {
        {1, new() {Id = 1, Email = "email@wsei.com",FirstName = "Jakub", LastName = "Putowski", BirthDate = new DateTime(1990, 11,05), PhoneNumber = "111 111 111"}},
        {2, new() {Id = 2, Email = "email1@wsei.com",FirstName = "Karol", LastName = "Kowal", BirthDate = new DateTime(1950, 03,17), PhoneNumber = "222 222 222"}}
    };

    private static int currentID = 3;
    // Lista kontaktów
    public IActionResult Index()
    {
        return View(_contacts);
    }

    public ActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Add(ContactModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        model.Id = ++currentID;
        _contacts.Add(model.Id, model);
        return View("Index", _contacts);
    }

    public ActionResult Delete(int id)
    {
        _contacts.Remove(id);
        return View("Index", _contacts);
    }

    public ActionResult Details(int id)
    {
        return View(_contacts[id]);
    }
}