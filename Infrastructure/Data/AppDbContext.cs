using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Mapear a entidade Noticia para uma tabela no banco de dados.
        /// </summary>
        public DbSet<Noticia> Noticia => Set<Noticia>();

        /// <summary>
        /// Construtor do AppDbContext, recebe as opções de configuração do banco de dados e passa para a classe base DbContext.
        /// </summary>
        /// <param name="options"></param>
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}
