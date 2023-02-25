using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebApiAspNet.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<WeatherContext>(opt =>
    opt.UseInMemoryDatabase("WeatherList"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c=>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "MyWeather Api",
        Description = "An ASP.NET Core Web API for getting weather forecast",
        TermsOfService = new Uri("https://www.microsoft.com/ru-kz"),
        Contact = new OpenApiContact
        {
            Name = "Adel Malgonussova",
            Url = new Uri("https://www.microsoft.com/ru-kz")
        },
        License = new OpenApiLicense
        {
            Name = "Full License",
            Url = new Uri("https://www.microsoft.com/ru-kz")
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
