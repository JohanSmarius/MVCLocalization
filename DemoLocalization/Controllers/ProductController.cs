using Microsoft.AspNetCore.Mvc;

namespace DemoLocalization.Controllers;

public class Product : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}