using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Models.Services;

namespace Project.Controllers;

public class ContactController : Controller
{
    private iContactService _contactService;

    public ContactController(iContactService contactService)
    {
        _contactService = contactService;
    }

    // Lista kontaktów
    public IActionResult Index()
    {
        return View(_contactService.GetAll());
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
        _contactService.Add(model);
        
        return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
        _contactService.Delete(id);
        return RedirectToAction(nameof(System.Index));
    }

    public ActionResult Details(int id)
    {
        return View(_contactService.GetById(id));
    }

    public ActionResult Edit(int id)
    {
        return View(_contactService.GetById(id));
    }
    [HttpPost]
    public ActionResult Edit(ContactModel model)
    {
        if (!ModelState.IsValid)
        {
            return View();            
            
        }           
        _contactService.Update(model);          
        return RedirectToAction(nameof(System.Index));
    }  
}