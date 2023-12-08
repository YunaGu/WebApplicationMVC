using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class InputController : Controller
{
    private readonly ApplicationDbContext _db;
    public InputController(ApplicationDbContext db)
    {
        _db = db;
    }
    
    [HttpGet]
    public IActionResult Input()
    {
        // // Record the time when user inputs
        // userInputModel.InputTime = DateTime.Now;
        // // Output the input
        // ViewData["UserInput"] = userInputModel.UserInput;
        // // Output the time
        // ViewData["InputTime"] = userInputModel.InputTime.ToString("HH:mm:ss dd-MM-yyyy");
        return View();
    }

    [HttpPost]
    public IActionResult Input(UserInputModel userInputModel)
    {
        var userInput = new UserInputModel()
        {
            MsgId = userInputModel.MsgId,
            InputTime = userInputModel.InputTime,
            UserInput = userInputModel.UserInput
        };
        return View(userInput);
    }

}