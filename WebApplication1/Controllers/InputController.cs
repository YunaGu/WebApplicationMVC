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
        _db.UserInput.Add(userInput);
        _db.SaveChanges();
        return RedirectToAction("Input");
    }

}