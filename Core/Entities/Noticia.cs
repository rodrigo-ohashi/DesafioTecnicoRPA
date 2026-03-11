namespace Core.Entities
{
    public class Noticia
    {
        /// <summary>
        /// Id da notícia, gerado automaticamente pelo banco de dados.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Título da notícia, extraído do site navegado.
        /// </summary>
        public string? Titulo { get; set; }

        /// <summary>
        /// Url da notícia, extraída do site navegado.
        /// </summary>
        public string? Url { get; set; }

        /// <summary>
        /// Data da notícia, extraída do site navegado.
        /// </summary>
        public String? DataNoticia { get; set; }
    }
}
