using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using DemoLocalization.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoLocalization.Controllers;

public class ProductController : Controller
{
    // GET
    public IActionResult Index()
    {
        // Force the culture to Dutch. This can be set for the entire app in the web.comfig.
      //  Thread.CurrentThread.CurrentCulture = new CultureInfo("nl-NL");

        Product product;
        if (TempData.ContainsKey("NewProduct"))
        {
            string productData = TempData["NewProduct"].ToString();
            product = JsonSerializer.Deserialize<Product>(productData);
        }
        else
        {
            product = new Product
            {
                Name = "Dogfood",
                PictureUrl = "https://cdn.webshopapp.com/shops/61259/files/104272172/nature-dogfood-nature-dogfood-graanvrije-hondenbro.jpg",
                Price = 11.89m
            };    
        }
        
        return View(product);
        
    }

    [HttpGet]
    public IActionResult NewProduct()
    {
        var emptyModel = new Product();
        return View(emptyModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult NewProduct(Product product)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        TempData["NewProduct"] = JsonSerializer.Serialize(product);
        return RedirectToAction("Index");
    }
}