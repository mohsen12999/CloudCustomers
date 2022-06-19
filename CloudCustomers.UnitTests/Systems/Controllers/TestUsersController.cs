using CloudCustomers.API.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xunit;

namespace CloudCustomers.UnitTests.Systems.Controllers;

public class TestUsersController
{
    [Fact]
    public async Task Get_OnSuccess_ReturnStatusCode200()
    {
        // Arrange
        var sut = new UsersController();
        
        // Act
        var result = (OkObjectResult)await sut.Get();

        // Assert
        result.StatusCode.Should().Be(200);
    }
}