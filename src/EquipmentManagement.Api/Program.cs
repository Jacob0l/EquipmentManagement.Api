using Application.Interfaces;
using Application.Services;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

//Enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3201/");
                      });
});

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IEquipmentService, EquipmentService>();
builder.Services.AddScoped<IEquipmentRepository, EquipmentRepository>();

builder.Services.AddScoped<ICalibrationService, CalibrationService>();
builder.Services.AddScoped<ICalibrationRepository, CalibrationRepository>();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevelopmentDB"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    DbInitializer.Initialize(dbContext);
}

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
