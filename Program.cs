using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using restaurantAPI;
using restaurantAPI.Entities;
using restaurantAPI.Middleware;
using restaurantAPI.Services;


var logger = LogManager.Setup()
    .LoadConfigurationFromAppSettings()
    .GetCurrentClassLogger();

try
{

    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

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
    builder.Services.AddScoped<IDishService, DishService>();
    builder.Services.AddScoped<ErrorHandlingMiddleware>();
    builder.Services.AddScoped<RequestTimeMiddleware>();

    var app = builder.Build();
    
    app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseMiddleware<RequestTimeMiddleware>();


    // Configure the HTTP request pipeline.

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        using var scope = app.Services.CreateScope();
        var seeder = scope.ServiceProvider.GetRequiredService<ResteurantSeeder>();
        //seeder.Seed();

    }

    //if (!app.Environment.IsDevelopment())
    //{
    //    app.UseHttpsRedirection();
    //}

    app.UseHttpsRedirection();

    app.MapControllers();

    app.Run();

}
catch(Exception ex)
{
    logger.Error(ex, "Niebieski ekran - blad krtyczny");
    throw;

}
finally 
{
    LogManager.Shutdown();
}