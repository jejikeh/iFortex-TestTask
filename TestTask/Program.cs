using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Extensions;

var builder = WebApplication.CreateBuilder(args);

var app = builder.ConfigureBuilder().Build();

app.ConfigureApplication();

app.Run();
