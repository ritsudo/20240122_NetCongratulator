using Microsoft.AspNetCore.Mvc;
using NetCongratulator.Interfaces;
using NetCongratulator.Controllers;
using NetCongratulator.Services;
using Moq;
using NetCongratulator.Models;

namespace NetCongratulator.Tests
{
    [TestClass]
    public class UCTestsGet
    {
        [TestMethod]
        public void GetAll_ReturnsViewResult()
        {
            // Arrange
            Mock<IUserCardService> mockService = new();
            UserCardController controller = new(mockService.Object);

            // Act
            var result = controller.GetAll();

            // Assert
            Assert.IsInstanceOfType(result, typeof(UserCard[]));
        }
    }
}