using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations;

public class OrderService : IOrderService
{
    private readonly ApplicationDbContext _applicationDbContext;

    public OrderService(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public Task<Order> GetOrder()
    {
        var maxOrder = _applicationDbContext.Orders.OrderBy(order => order.Price).Last();
        
        return Task.FromResult(maxOrder);
    }

    public async Task<List<Order>> GetOrders()
    {
        return await _applicationDbContext.Orders.Where(order => order.Quantity > 10).ToListAsync();
    }
}