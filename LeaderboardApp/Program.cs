using LeaderboardApp.Data;
using LeaderboardApp.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// In-memory database configuration
builder.Services.AddDbContext<LeaderboardContext>   (options => options.UseInMemoryDatabase("LeaderboardDb"));

// Register repository
builder.Services.AddScoped<ITeamRepository, TeamRepository>();

// Disable HTTPS redirection in production
if (!builder.Environment.IsDevelopment())
{
    builder.Services.Configure<Microsoft.AspNetCore.HttpsPolicy.HttpsRedirectionOptions>(options => options.HttpsPort = null);
}

var app = builder.Build();


// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

// Ensure Swagger is available in production as well
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
