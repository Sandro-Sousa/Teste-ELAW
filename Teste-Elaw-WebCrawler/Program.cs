using Microsoft.Extensions.DependencyInjection;
using Teste_Elaw_WebCrawler.Core.Entities;
using Teste_Elaw_WebCrawler.Data.Repositories;
using Teste_Elaw_WebCrawler.Infrastructure.Services;
using Teste_Elaw_WebCrawler.Startup;

class Program
{
    static async Task Main(string[] args)
    {
        var serviceProvider = Startup.ConfigureServices();

        using (var scope = serviceProvider.CreateScope())
        {
            var crawlerService = scope.ServiceProvider.GetRequiredService<WebCrawlerService>();
            var logRepository = scope.ServiceProvider.GetRequiredService<ExecutionLogRepository>();

            var startDate = DateTime.Now;
            var results = await crawlerService.ExtractDataFromPagesAsync();

            var endDate = DateTime.Now;

            var jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "output.json");

            File.WriteAllText(jsonFilePath, System.Text.Json.JsonSerializer.Serialize(results));

            var log = new ExecutionLog
            {
                StartDate = startDate,
                EndDate = endDate,
                PageCount = results.Count(),
                LineCount = results.Count(),
                JsonFilePath = jsonFilePath,
                CreatedAt = DateTime.Now
            };

            logRepository.Save(log);
        }
    }
}