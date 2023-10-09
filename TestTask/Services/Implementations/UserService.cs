using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Enums;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _applicationDbContext;

    public UserService(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public Task<User> GetUser()
    {
        var user = _applicationDbContext.Users.OrderBy(order => order.Orders.Count).Last();
        
        return Task.FromResult(user);
    }

    public async Task<List<User>> GetUsers()
    {
        return await _applicationDbContext.Users.Where(user => user.Status == UserStatus.Inactive).ToListAsync();
    }
}