using Domain.Contracts;
using Domain.Models;
namespace FileData.DataAccess;

// dummy database 
public class InMemoryUserService : IUserSerivice
{
    public Task<User?> GetUserAsync(string username)
    {
        User? find = users.Find(user => user.Name.Equals(username));
        return Task.FromResult(find);
    }

    private List<User> users = new()
    {
        new User
        {
            Name = "Troels", Password = "Troels1234", Role = "Teacher", SecurityLevel = 3, BirthYear = 1986, Domain = "via"
        },
        new User
        {
            Name = "Adrian", Password = "adrian1234", Role = "Teacher", SecurityLevel = 3, BirthYear = 1986, Domain = "via"
        },
        new User
        {
            Name = "Adrian2", Password = "adrian1234", Role = "Teacher2", SecurityLevel = 3, BirthYear = 1986, Domain = "via"
        }
    };
}