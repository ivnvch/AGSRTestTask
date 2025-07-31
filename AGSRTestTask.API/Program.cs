using AGSRTestTask.Application;
using AGSRTestTask.Extensions;
using AGSRTestTask.Persistence;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwagger();

builder.Services.AddPersistenceExtensions();
builder.Services.ApplicationExtension();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(
        c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "AGSRTestTask v 1.0");
            c.SwaggerEndpoint("/swagger/v2/swagger.json", "AGSRTestTask v 2.0");
           // c.RoutePrefix = string.Empty;
        });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();