using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Controllers;
using WebApplication1.Data;
using WebApplication1.Models;

namespace xUnitTests.Controllers;

public class InputControllerTests
{
    //add a virtual input to InMemoryDatabase (not the real one)
    [Fact]
    public async Task Input_Post_AddInput()
    {
        //arrange
        var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        using (var dbContext = new ApplicationDbContext(dbContextOptions))
        {
            var controller = new InputController(dbContext);
            var userInput = new UserInputModel
            {
                MsgId = 1,
                InputTime = DateTime.Now,
                UserInput = "xUnit Test Message"
            };
            
            //Act
            var result = controller.Input(userInput);
            // dbContext.SaveChanges();
            
            //Assert
            Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Input", (result as RedirectToActionResult)?.ActionName);

            var savedUserInput = dbContext.UserInput.FirstOrDefault();
            Assert.NotNull(savedUserInput);
            Assert.Equal(userInput.UserInput, savedUserInput.UserInput);

        }
    }
}