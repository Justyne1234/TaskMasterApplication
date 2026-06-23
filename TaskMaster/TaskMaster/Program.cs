using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using TaskMaster.DbContexts;
using TaskMaster.Middlewares;
using TaskMaster.Models;
using TaskMaster.Models.Options;
using TaskMaster.Repositories;
using TaskMaster.Services;
using TaskMaster.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Add Services
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<ITaskRepository, TaskRepositorySqlProc>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepositorySqlProc>();
builder.Services.AddScoped<GoogleApiService>();
builder.Services.AddScoped<JwtService>();
builder.Services.AddScoped<PasswordHasher<User>>();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

    options.UseMySql(
        connectionString,
        new MySqlServerVersion(new Version(8, 0, 0))
    );
});
builder.Services.Configure<GoogleAuthOptions>(builder.Configuration.GetSection("GoogleAuthConfiguration"));

builder.Services.AddJwtAuth(builder.Configuration);

builder.Services.AddAuthorization();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowTaskMasterClient", policy =>
    {
        policy
            .WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

app.UseCors("AllowTaskMasterClient");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
