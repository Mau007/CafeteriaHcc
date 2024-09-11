using CafeteriaHCC.DAL;
using CafeteriaHCC.Dominio;
using CafeteriaHCC.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AccesoDatos>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DB")).ConfigureWarnings(b => b.Ignore(SqlServerEventId.SavepointsDisabledBecauseOfMARS)));
//builder.Services.AddDbContext<AccesoDatos>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DB")).ConfigureWarnings(b => b.Ignore(SqlServerEventId.SavepointsDisabledBecauseOfMARS)));//Para evitar los warnings (tipo MARS) en los log del servidor)
builder.Services.AddCors();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMesasAdministrador, MesasAdministrador>();
builder.Services.AddScoped<IOrdenesAdministrador, OrdenesAdministrador>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(b =>
{
    b.WithOrigins("*");
    b.AllowAnyHeader();
    b.AllowAnyMethod();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
