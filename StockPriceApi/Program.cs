var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

string[] stockTickers = { "AAPL", "GOOGL", "MSFT", "AMZN", "META", "TSLA", "NVDA", "JPM", "WMT", "KO" };
decimal[] stockPrices = { 173.50m, 147.23m, 401.89m, 177.23m, 495.27m, 185.10m, 817.49m, 146.75m, 59.93m, 60.45m };

app.MapGet("/StockPrices", () =>
{
    var prices =  Enumerable.Range(0, 9).Select(index =>
        new StockPrices
        (
            stockTickers[index],
            stockPrices[index]
        ))
        .ToArray();
    return prices;
})
.WithName("GetStockPrices")
.WithOpenApi();

app.Run();

record StockPrices(string stockTicker, decimal stockPrice);
