using HRMS.Api.Data;
using HRMS.Api.Extensions;
using HRMS.Api.Middlewares;
using HRMS.Api.Models;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
// Add Controller api
builder.Services.AddControllers();


// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggers();

// Add Config settings
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

// Add DB Context
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add HttpContext Injection
builder.Services.AddHttpContextAccessor();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddAppRepository();
builder.Services.AddAppService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<JwtMiddleware>();
app.UseHttpsRedirection();
app.UseExceptionHandler();
app.UseAuthorization();
app.MapControllers();

app.Run();