using System.Collections.Generic;
using CloudCustomers.API.Models;

namespace CloudCustomers.UnitTests.Fixtures;

public static class UsersFixture
{
    public static List<User> GetTestUsers() =>
        new()
        {
            new User
            {
                Name = "Test User 1",
                Email = "test.user.1@example.com",
                Address = new Address()
                {
                    Street = "123 Market St",
                    City = "Somewhere",
                    ZipCode = "12324"
                }
            },
            new User
            {
                Name = "Test User 2",
                Email = "test.user.2@example.com",
                Address = new Address()
                {
                    Street = "900 Market St",
                    City = "Somewhere",
                    ZipCode = "12324"
                }
            },
            new User
            {
                Name = "Test User 3",
                Email = "test.user.3@example.com",
                Address = new Address()
                {
                    Street = "108 Market St",
                    City = "Somewhere",
                    ZipCode = "12324"
                }
            }
        };
}