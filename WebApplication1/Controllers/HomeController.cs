using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Input(UserInputModel userInputModel)
    {
        // Record the time when user inputs
        userInputModel.InputTime = DateTime.Now;
        // Output the input
        ViewData["UserInput"] = userInputModel.UserInput;
        // Output the time
        ViewData["InputTime"] = userInputModel.InputTime.ToString("HH:mm:ss dd-MM-yyyy");
        return View();
    }

    public IActionResult Output()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}