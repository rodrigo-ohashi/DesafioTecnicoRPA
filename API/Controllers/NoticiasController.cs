using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/noticia")]
    public class NoticiasController : ControllerBase
    {
        private readonly INoticiaRepository _repository;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="repository"></param>
        public NoticiasController(INoticiaRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Lista todas as notícias armazenadas no repositório.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var noticia = await _repository.GetAllAsync();
            return Ok(noticia);
        }
    }
}
