using HtmlAgilityPack;

namespace Teste_Elaw_WebCrawler.Infrastructure.Services
{
    public class WebCrawlerService
    {
        private readonly string _baseUrl;
        private readonly HttpClient _httpClient;

        public WebCrawlerService(string baseUrl)
        {
            _baseUrl = baseUrl;
            _httpClient = new HttpClient();
        }

        public async Task<IEnumerable<dynamic>> ExtractDataFromPagesAsync()
        {
            var results = new List<dynamic>();
            var currentPage = 1;

            while (true)
            {
                var pageUrl = $"{_baseUrl}?page={currentPage}";
                var pageContent = await DownloadPageContentAsync(pageUrl);

                if (string.IsNullOrEmpty(pageContent)) break;

                var pageData = ParsePage(pageContent);

                if (pageData.Count == 0) break;

                results.AddRange(pageData);
                currentPage++;
            }

            return results;
        }

        private async Task<string> DownloadPageContentAsync(string url)
        {
            try
            {
                return await _httpClient.GetStringAsync(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao acessar a URL {url}: {ex.Message}");
                return string.Empty;
            }
        }

        private List<dynamic> ParsePage(string htmlContent)
        {
            var data = new List<dynamic>();
            var document = new HtmlDocument();
            document.LoadHtml(htmlContent);

            var rows = document.DocumentNode.SelectNodes("//table/tbody/tr");
            if (rows == null) return data;

            foreach (var row in rows)
            {
                var cells = row.SelectNodes("td");
                if (cells != null && cells.Count >= 4)
                {
                    data.Add(new
                    {
                        IpAddress = cells[1].InnerText.Trim(),  
                        Port = cells[2].InnerText.Trim(), 
                        Country = cells[3].InnerText.Trim(),
                        Protocol = cells[6].InnerText.Trim()
                    });
                }
            }

            return data;
        }
    }
}
