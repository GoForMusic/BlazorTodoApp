using Domain.Models;

namespace Domain.Contracts;

public interface IUserSerivice
{
    public Task<User?> GetUserAsync(string username);
}