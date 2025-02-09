using System;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;

public class PriceParser
{
    private readonly HttpClient _httpClient;

    public PriceParser()
    {
        _httpClient = new HttpClient();
    }

    public async Task<string> GetApartmentPriceAsync(string url)
    {
        try
        {
            var html = await _httpClient.GetStringAsync(url);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var priceNode = htmlDoc.DocumentNode.SelectSingleNode("//div[contains(@class, 'flat-prices__block-current') and contains(@class, 'PRICE')]");

            if (priceNode != null)
            {
                return priceNode.InnerText.Trim();
            }
            else
            {
                throw new Exception("Цена не найдена.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при парсинге: {ex.Message}");
            return null;
        }
    }
}
