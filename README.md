# Cloud Customers

- make solution: `dotnet new sln -o CloudCustomers`.
- add git ignore file: `dotnet new gitignore`
- add web api project: `dotnet new webapi -o CloudCustomers.API`
- add unit test project: `dotnet new xunit -o CloudCustomers.UnitTests`
- add all project to solution: `dotnet sln add **/*.csproj` or `dotnet sln add .\CloudCustomers.API\CloudCustomers.API.csproj` and `dotnet sln add .\CloudCustomers.UnitTests\CloudCustomers.UnitTests.csproj`

## Reference

- base on [Building a .Net API Using TDD](https://youtu.be/ULJ3UEezisw) by Wes Doyle
