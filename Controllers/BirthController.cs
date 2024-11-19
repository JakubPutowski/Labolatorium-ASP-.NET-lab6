using Microsoft.AspNetCore.Mvc;
using Project.Models;


namespace Project.Controllers;

public class BirthController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Result([FromForm]Birth model)
    {
        if (!model.IsValid())
        {
            return View("Error", model);
        }
        return View(model);
    }

    public IActionResult Form()
    {
        return View();
    }
}