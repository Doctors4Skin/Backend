using Doctor4skin.Services;
using Doctor4skin.Services.Profiles;
using Doctors4skin.Repositories;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<DoctorProfile>();
});


builder.Services.AddTransient<IDoctorRepository, DoctorRepository>();
builder.Services.AddTransient<IDoctorService, DoctorService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
