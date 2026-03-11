using Core.Entities;

namespace Core.Interfaces
{
    public interface INoticiaRepository
    {
        /// <summary>
        /// Adiciona uma nova notícia ao repositório.
        /// </summary>
        /// <param name="noticia"></param>
        /// <returns></returns>
        Task AddAsync(Noticia noticia);

        /// <summary>
        /// Lista todas as notícias armazenadas no repositório.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Noticia>> GetAllAsync();
    }
}
