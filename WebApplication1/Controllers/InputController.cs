using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public async Task<IActionResult> Output()
    {
        // var userMsg = await _db.UserInput.ToListAsync();
        // return View(userMsg);
        return View();
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