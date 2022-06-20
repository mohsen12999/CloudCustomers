using CloudCustomers.API.Models;

namespace CloudCustomers.API.Services;

public interface IUsersService
{
    public Task<List<User>> GetAllUsers();
}

public class UsersService : IUsersService
{
    private readonly HttpClient _httpClient;
    
    public UsersService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<User>> GetAllUsers()
    {
        var userResponse = await _httpClient.GetAsync("https://example.com");
        if (userResponse.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return new List<User>();
        }

        var responseContent = userResponse.Content;
        var allusers = await responseContent.ReadFromJsonAsync<List<User>>();
        return allusers.ToList();
    }
}
