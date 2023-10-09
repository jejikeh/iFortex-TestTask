using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Services.Implementations;
using TestTask.Services.Interfaces;

namespace TestTask.Extensions;

public static class ApplicationExtensions
{
    public static WebApplicationBuilder ConfigureBuilder(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddScoped<IOrderService, OrderService>();
        builder.Services.AddScoped<IUserService, UserService>();

        builder.Services.AddDbContext<ApplicationDbContext>(options => 
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        return builder;
    }

    public static WebApplication ConfigureApplication(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
        
        return app;
    }
}