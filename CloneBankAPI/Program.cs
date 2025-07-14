using Microsoft.EntityFrameworkCore;
using CloneBankAPI.Infrastructure;
using CloneBankAPI.Infrastructure.Repositories.UsuarioRepository;
using CloneBankAPI.Application.Services.UsuarioService.UseCase.CreateUser;
using CloneBankAPI.Application.Util.PasswordHash;
using CloneBankAPI.Application.Services.UsuarioService;
using CloneBankAPI.Infrastructure.Repositories.ContaRepository;
using CloneBankAPI.Application.Services.ContaService.UseCase.CreateCount;
using System.Text.Json.Serialization;
using CloneBankAPI.Infrastructure.Repositories.TransferenciaRepository;
using CloneBankAPI.Application.Services.TransferenciaService;
using CloneBankAPI.Application.Services.TransferenciaService.ServicesPackage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbConnection>(options =>
    options.UseNpgsql(builder
    .Configuration
    .GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IContaRepository, ContaRepository>();
builder.Services.AddScoped<ITransferenciaRepository, TransferenciaRepository>();

builder.Services.AddScoped<PasswordHashInterface, PasswordHash>();

builder.Services.AddScoped<ICreateUser, CreateUser>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<ICreateCountService, CreateCountService>();
builder.Services.AddScoped<ICriarTransferenciaService, CriarTransferenciaService>();

builder.Services
    .AddControllers()
    .AddJsonOptions(op =>
    {
        op.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    }
    );

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
