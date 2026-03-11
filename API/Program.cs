using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Infrastructure.Repositories;

// Criando o host (configurar) os serviços e o ambiente de execução da aplicação
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<INoticiaRepository, NoticiaRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var dbPath = @"C:\Rodrigo\Cursos\TesteTecnico\DesafioTecnicoRPA\noticia.db";
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite($"Data Source={dbPath}"));

// Construíndo e inicializando a aplicação (swagger).
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();
app.Run();