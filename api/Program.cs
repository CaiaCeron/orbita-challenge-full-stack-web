using api.Models.Context;
using api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(o => o.UseNpgsql(
builder.Configuration.GetConnectionString("MyConnection"))); //Utilizar varialvel para conexãocom BD.

builder.Services.AddScoped<IStudentServices, StudentServices>(); //Registrar Serviço na Program.cs.

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

app.UseCors(options =>
{
    options.WithOrigins("http://localhost:8080");
    options.AllowAnyMethod();
    options.AllowAnyHeader();

});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
