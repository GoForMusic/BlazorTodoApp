using System.Text.Json;
using Domain.Contracts;
using Domain.Models;

namespace HttpServices;

public class UserHttpService : IUserSerivice
{
    public async Task<User?> GetUserAsync(string username)
    {
        try
        {
            string content = await ServerAPI.getContent(Methods.Get,$"/user/{username}");
        
            User user = JsonSerializer.Deserialize<User>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
            return user;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}