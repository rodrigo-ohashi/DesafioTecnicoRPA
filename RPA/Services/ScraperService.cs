using Core.Entities;
using Core.Interfaces;
using HtmlAgilityPack;

namespace RPA.Services
{
    public class ScraperService
    {
        private readonly HttpClient _httpClient;
        private readonly INoticiaRepository _repository;

        /// <summary>
        /// Construtor da classe ScraperService, que recebe um HttpClient para realizar requisições HTTP e um INoticiaRepository para armazenar as notícias extraídas.
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="repository"></param>
        public ScraperService(HttpClient httpClient, INoticiaRepository repository)
        {
            _httpClient = httpClient;
            _repository = repository;
        }

        /// <summary>
        /// Executa o processo de scraping, que consiste em acessar a página da UOL, extrair os títulos das notícias e armazená-las no banco de dados utilizando o repositório.
        /// </summary>
        /// <returns></returns>
        public async Task ExecuteAsync()
        {
            // Site que será feito o scraping (coleta).
            var url = "https://www.uol.com.br";

            var html = await _httpClient.GetStringAsync(url);

            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            // Seleciona os nós que contêm os títulos das notícias.
            var tituloNoticias = doc.DocumentNode.SelectNodes("//h3");

            if (tituloNoticias == null) return;

            // Itera sobre os primeiros 5 registros (notícias).
            foreach (var tituloNoticia in tituloNoticias.Take(5))
            {
                var noticia = new Noticia
                {
                    Titulo = tituloNoticia.InnerText.Trim(),
                    Url = url,
                    DataNoticia = DateTime.Now.ToString("dd/MM/yyyy HH:MM")
                };

                await _repository.AddAsync(noticia);
            }
        }
    }
}
