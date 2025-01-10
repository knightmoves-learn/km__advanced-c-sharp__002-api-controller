using Microsoft.AspNetCore.Mvc;

namespace StockPriceApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StockPriceController : ControllerBase
    {
        private string[] stockTickers = new[]
        { 
            "AAPL", "GOOGL", "MSFT", "AMZN", "META", "TSLA", "NVDA", "JPM", "WMT", "KO" 
        };

        private decimal[] stockPrices = new[]
        {
            173.50m, 147.23m, 401.89m, 177.23m, 495.27m, 185.10m, 817.49m, 146.75m, 59.93m, 60.45m 
        };

        [HttpGet]
        private IEnumerable<StockPrices> Get()
        {
            var prices =  Enumerable.Range(0, 9).Select(index => new StockPrices
            (
                stockTickers[index],
                stockPrices[index]
            )).ToArray();
            return prices;
        }

    }
}