using API;
using API.Middlewares;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("UserManagementConnectionString")));

builder.Services.AddApplication();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Host.UseSerilog();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI(c =>
    {   
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "User Management Api");
        c.RoutePrefix = string.Empty;
    }
);

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();
app.MapControllers();
app.UseMiddleware<ValidationExceptionHandlingMiddleware>();

app.Run();