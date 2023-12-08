// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using NUnit.Framework.Legacy;
// using WebApplication1.Controllers;
// using WebApplication1.Data;
// using WebApplication1.Models;
//
// namespace NUnitTests.Controllers;
//
// public class InputControllerTests
// {
//     //add a virtual input to InMemoryDatabase (not the real one)
//     [Test]
//     public async Task Input_Post_AddInput()
//     {
//         //arrange
//         var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
//             .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
//             .Options;
//
//         using (var dbContext = new ApplicationDbContext(dbContextOptions))
//         {
//             var controller = new InputController(dbContext);
//             var userInput = new UserInputModel
//             {
//                 MsgId = 1,
//                 InputTime = DateTime.Now,
//                 UserInput = "xUnit Test Message"
//             };
//             
//             //Act
//             var result = controller.Input(userInput);
//             // dbContext.SaveChanges();
//             
//             //Assert
//             ClassicAssert.AreEqual("Input", (result as RedirectToActionResult)?.ActionName);
//             ClassicAssert.IsInstanceOf<RedirectToActionResult>(result);
//             
//             var savedUserInput = dbContext.UserInput.FirstOrDefault();
//             ClassicAssert.IsNotNull(savedUserInput);
//             ClassicAssert.AreEqual(userInput.UserInput, savedUserInput.UserInput);
//
//         }
//     }
//     
//     //test output
//     // [Test]
//     // public async Task Output_ViewMessageAndTime()
//     // {
//     //     // Arrange
//     //     var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
//     //         .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
//     //         .Options;
//     //
//     //     using (var dbContext = new ApplicationDbContext(dbContextOptions))
//     //     {
//     //         dbContext.UserInput.Add(new UserInputModel
//     //         {
//     //             MsgId = 1, 
//     //             InputTime = DateTime.Now, 
//     //             UserInput = "xUnit Test Message"
//     //         });
//     //         dbContext.SaveChanges();
//     //     }
//     //
//     //     using (var dbContext = new ApplicationDbContext(dbContextOptions))
//     //     {
//     //         var controller = new InputController(dbContext);
//     //
//     //         // Act
//     //         var result = await controller.Output();
//     //
//     //         // Assert
//     //         var viewResult = ClassicAssert.IsInstanceOf<ViewResult>(result);
//     //         var model = ClassicAssert.IsAssignableFrom<IEnumerable<UserInputModel>>(viewResult.ViewData.Model);
//     //         Assert.Single(model); // Assuming there is only one UserInputModel in the database for this test
//     //     }
//     // }
// }