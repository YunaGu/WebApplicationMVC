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
    
    //test output
    [Fact]
    public async Task Output_ViewMessageAndTime()
    {
        // Arrange
        var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
    
        using (var dbContext = new ApplicationDbContext(dbContextOptions))
        {
            dbContext.UserInput.Add(new UserInputModel
            {
                MsgId = 1, 
                InputTime = DateTime.Now, 
                UserInput = "xUnit Test Message"
            });
            dbContext.SaveChanges();
        }
    
        using (var dbContext = new ApplicationDbContext(dbContextOptions))
        {
            var controller = new InputController(dbContext);
    
            // Act
            var result = await controller.Output();
    
            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<UserInputModel>>(viewResult.ViewData.Model);
            Assert.Single(model); // Assuming there is only one UserInputModel in the database for this test
        }
    }
}