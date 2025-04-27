using FumbleFunds.Api.Repositories;
using FumbleFunds.Api.Repositories.Interfaces;
using FumbleFunds.Api.Services;
using FumbleFunds.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Register DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBetRepository, BetRepository>();
builder.Services.AddScoped<IMatchesRepository, MatchesRepository>();


builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBetService, BetService>();
builder.Services.AddScoped<IMatchesService, MatchesService>();
builder.Services.AddScoped<IFeatureService, FeatureService>();

builder.Services
    .AddHttpClient<IExternalMatchService, ExternalMatchesService>(client =>
    {
        var cfg = builder.Configuration.GetSection("ExternalApis:FootballData");
        client.BaseAddress = new Uri(cfg["BaseUrl"]!);
        client.DefaultRequestHeaders.Add("X-Auth-Token", cfg["ApiKey"]!);
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
}

// 7) Swagger middleware (only in Development, if you like)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "FumbleFunds API v1");

    });
}


app.MapControllers();
app.Run();
