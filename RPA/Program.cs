using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RPA.Services;
using RPA.Workers;

// Criando o host (configurar) os serviços e o ambiente de execução da aplicação
var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddScoped<INoticiaRepository, NoticiaRepository>();
builder.Services.AddHttpClient<ScraperService>();
builder.Services.AddScoped<ScraperService>();
builder.Services.AddHostedService<ScraperWorker>();
var dbPath = @"C:\Rodrigo\Cursos\TesteTecnico\DesafioTecnicoRPA\noticia.db";
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite($"Data Source={dbPath}"));

// Construíndo e inicializando a aplicação.
var host = builder.Build();
using (var scope = host.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    // Cria o banco e a tabela automaticamente
    db.Database.EnsureCreated();
}
host.Run();