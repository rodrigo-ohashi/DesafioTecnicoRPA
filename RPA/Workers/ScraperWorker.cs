using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RPA.Services;

namespace RPA.Workers
{
    public class ScraperWorker : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<ScraperWorker> _logger;

        /// <summary>
        /// Construtor do ScraperWorker, recebe o IServiceProvider para resolver dependências e o ILogger para registrar logs.
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <param name="logger"></param>
        public ScraperWorker(IServiceProvider serviceProvider, ILogger<ScraperWorker> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        /// <summary>
        /// Executa o processo de scraping em um loop contínuo, com um intervalo de 5 minutos entre cada execução. O método utiliza um escopo de serviço para resolver o ScraperService e registrar logs de sucesso ou erro.
        /// </summary>
        /// <param name="stoppingToken"></param>
        /// <returns></returns>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using var scope = _serviceProvider.CreateScope();
                    var scraper = scope.ServiceProvider.GetRequiredService<ScraperService>();

                    await scraper.ExecuteAsync();

                    _logger.LogInformation("Scraping executado com sucesso.");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erro no scraping.");
                }

                await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
            }
        }
    }
}
