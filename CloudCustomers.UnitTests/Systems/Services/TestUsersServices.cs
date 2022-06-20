﻿using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CloudCustomers.API.Models;
using CloudCustomers.API.Services;
using CloudCustomers.UnitTests.Fixtures;
using CloudCustomers.UnitTests.Helpers;
using FluentAssertions;
using Moq;
using Moq.Protected;
using Xunit;

namespace CloudCustomers.UnitTests.Systems.Services;

public class TestUsersServices
{
    [Fact]
    public async Task GetAllUsers_WhenCalled_InvokesHttpGetRequest()
    {
        // Arrange
        var expectedResponse = UsersFixture.GetTestUsers();
        var handlerMock = MockHttpMessageHandler<User>
            .SetupBasicGetResourceList(expectedResponse);
        var httpClient = new HttpClient(handlerMock.Object);
        var sut = new UsersService(httpClient);
        
        // Act
        await sut.GetAllUsers();

        // Assert
        // verify HTTP request is made!
        handlerMock
            .Protected()
            .Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get),
                ItExpr.IsAny<CancellationToken>()
                );
    }

    [Fact]
    public async Task GetAllUser_WhenCalled_ReturnListOfUsers()
    {
        // Arrange
        var expectedResponse = UsersFixture.GetTestUsers();
        var handlerMock = MockHttpMessageHandler<User>.SetupBasicGetResourceList(expectedResponse);
        var httpClient = new HttpClient(handlerMock.Object);
        var sut = new UsersService(httpClient);
        
        // Act
        var result = await sut.GetAllUsers();

        // Assert
        result.Should().BeOfType<List<User>>();
    }
    
    [Fact]
    public async Task GetAllUser_WhenHit404_ReturnEmptyListOfUsers()
    {
        // Arrange
        var handlerMock = MockHttpMessageHandler<User>.Setup404();
        var httpClient = new HttpClient(handlerMock.Object);
        var sut = new UsersService(httpClient);
        
        // Act
        var result = await sut.GetAllUsers();

        // Assert
        result.Count.Should().Be(0);
    }
    
    [Fact]
    public async Task GetAllUser_WhenCalled_ReturnListOfUsersOfExpectedSize()
    {
        // Arrange
        var expectedResponse = UsersFixture.GetTestUsers();
        var handlerMock = MockHttpMessageHandler<User>
            .SetupBasicGetResourceList(expectedResponse);
        var httpClient = new HttpClient(handlerMock.Object);
        var sut = new UsersService(httpClient);
        
        // Act
        var result = await sut.GetAllUsers();

        // Assert
        result.Count.Should().Be(expectedResponse.Count);
    }
}