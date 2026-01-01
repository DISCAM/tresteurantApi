using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using restaurantAPI;
using restaurantAPI.Entities;
using restaurantAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ResteurantDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("RestaurantDb")
    ));


builder.Services.AddScoped<ResteurantSeeder>();
builder.Services.AddAutoMapper(typeof(RestaurantsMappingProfile).Assembly);
builder.Services.AddScoped<IRestaurantService, RestaurantService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    using var scope = app.Services.CreateScope();
    var seeder = scope.ServiceProvider.GetRequiredService<ResteurantSeeder>();
    seeder.Seed();
    
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
