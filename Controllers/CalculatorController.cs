using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers;

public class CalculatorController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Result([FromForm]Calculator calculator)
    {
        if (!calculator.IsValid())
        {
            return View("Error", calculator);
        }
        return View(calculator);
    }

    public IActionResult Form()
    {
        return View();
    }
}