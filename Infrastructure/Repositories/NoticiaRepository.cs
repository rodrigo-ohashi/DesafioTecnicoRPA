using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class NoticiaRepository : INoticiaRepository
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Construtor do repositório de notícias.
        /// </summary>
        /// <param name="context"></param>
        public NoticiaRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adicionar uma nova notícia ao banco de dados.
        /// </summary>
        /// <param name="noticia"></param>
        /// <returns></returns>
        public async Task AddAsync(Noticia noticia)
        {
            await _context.Noticia.AddAsync(noticia);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Listar todas as notícias, ordenadas por data de forma decrescente.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Noticia>> GetAllAsync()
        {
            return await _context.Noticia
                .OrderByDescending(x => x.DataNoticia)
                .ToListAsync();
        }
    }
}
