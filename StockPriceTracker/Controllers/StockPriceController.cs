using Microsoft.AspNetCore.Mvc;
namespace StockPriceTracker
{
    [ApiController]
    [Route("[controller]")] // first 
    public class StockPriceController : ControllerBase // 2
    {
        private string[] stockTickers = { "AAPL", "GOOGL", "MSFT", "AMZN", "META", "TSLA", "NVDA", "JPM", "WMT", "KO" }; 
        private decimal[] stockPrices = { 173.50m, 147.23m, 401.89m, 177.23m, 495.27m, 185.10m, 817.49m, 146.75m, 59.93m, 60.45m }; // 3

        [HttpGet] // 4
        public IEnumerable<StockPrices> Get() // 5
        {
            var prices = Enumerable.Range(0, 9).Select(index =>
                new StockPrices
                (
                    stockTickers[index],
                    stockPrices[index]
                ))
                .ToArray();
            return prices; // 6
        }
    }
}