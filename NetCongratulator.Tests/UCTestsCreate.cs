using Microsoft.AspNetCore.Mvc;
using NetCongratulator.Interfaces;
using NetCongratulator.Controllers;
using NetCongratulator.Services;
using Moq;
using NetCongratulator.Models;

namespace NetCongratulator.Tests
{
    [TestClass]
    public class UCTestsCreate
    {
        [TestMethod]
        public async Task Create_ReturnsResult()
        {
            // Arrange
            Mock<IUserCardService> mockService = new();
            UserCardController controller = new(mockService.Object);

            UserCard userCard = new UserCard()
            {
                FirstName = "TestName",
                LastName = "TestSurname",
                BirthdayDate = DateTime.Now
            };

            // Act
            IActionResult result = await controller.Create(userCard);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(CreatedResult));

            var createdResult = (CreatedResult)result;
            Assert.AreEqual(201, createdResult.StatusCode);
        }

        [TestMethod]
        public async Task CreateInvalid_ReturnsError()
        {
            // Arrange
            Mock<IUserCardService> mockService = new();
            UserCardController controller = new(mockService.Object);

            UserCard userCard = new()
            {
                FirstName = "TestName"
            };

            // Act
            var result = await controller.Create(userCard);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));

            var badRequestResult = (BadRequestObjectResult)result;
            Assert.AreEqual(400, badRequestResult.StatusCode);
        }

    }
}