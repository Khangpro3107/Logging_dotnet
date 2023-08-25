using Logging.Middlewares;
using Logging.Services;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Logging.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Logging.ClearProviders();       // clear all logging providers
builder.Logging.AddConsole();           // add a provider to the list of providers, console in this case

builder.Services.AddScoped<MyMiddleware>();
builder.Services.AddScoped<SampleMiddleware>();
builder.Services.AddTransient<LogService, LogService>();
// logs to Logging.txt, 'true' indicates append mode
builder.Services.AddLogging(loggingBuilder => loggingBuilder.AddFile("Logging.txt", true));

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // navigate to '/' to run the middlewares (at the end of this file)
    // '/swagger' will block further middlewares
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

// this middleware logs a simple message
//app.UseMiddleware<SampleMiddleware>();

// this middleware logs messages with different levels, params and ids
app.UseMiddleware<MyMiddleware>();

app.Run();
