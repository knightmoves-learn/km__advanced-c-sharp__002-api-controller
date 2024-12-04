namespace TestsProj;
using System.IO;
using Xunit;
using Xunit.Abstractions;


public class ExistenceTests
{
    private readonly ITestOutputHelper output;

    public ExistenceTests(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Fact]
    public void DoesControllersDirectoryExist()
    {
        string controllerDirectoryPath = @"../../../../StockPriceTracker/Controllers";
        //output.WriteLine(Directory.Exists(projectDirectoryPath).ToString());
        Assert.True(Directory.Exists(controllerDirectoryPath), "The file directory \"Controllers\" does not exist at the root of the StockPriceTracker project");
    }

    [Fact]
    public void DoesStockPriceControllerExist()
    {
        string controllerFilePath = @"../../../../StockPriceTracker/Controllers/StockPriceController.cs";
        Assert.True(File.Exists(controllerFilePath), "The file \"StockPriceController\" does not exist in the Controller directory at the root of the StockPriceTracker project");
    }
}

public class ContentTests
{
    string fileContent;

    public ContentTests()
    {
        fileContent = File.ReadAllText(@"../../../../StockPriceTracker/Controllers/StockPriceController.cs");
    }

    [Fact]
    public void DoesStockPriceControllerHaveNamespaceStockPriceTracker()
    {
        Assert.True(fileContent.Contains("namespace StockPriceTracker"), "StockPriceController.cs does not contain \"namespace StockPriceTracker\"");
    }

    [Fact]
    public void DoesCorrectAPIAttributeExistInStockPriceController()
    {
        Assert.True(fileContent.Contains("[ApiController]"), "StockPriceController.cs is missing the APIController attribute");
    }

    [Fact]
    public void DoesCorrectRouteAttributeExistInStockPriceController()
    {
        Assert.True(fileContent.Contains("[Route(\"[controller]\")]"), "StockPriceController.cs is missing the correct route attribute");
    }

    [Fact]
    public void DoesCorrectControllerClassExistInStockPriceController()
    {
        Assert.True(fileContent.Contains("public class StockPriceController : ControllerBase"), "StockPriceController.cs does not contain a public class \"StockPriceController\" which implements \"ControllerBase\"");
    }

    [Fact]
    public void DoStockTickersAndPricesExistInStockPriceController()
    {
        bool tickersExist = fileContent.Contains("string[] stockTickers = { \"AAPL\", \"GOOGL\", \"MSFT\", \"AMZN\", \"META\", \"TSLA\", \"NVDA\", \"JPM\", \"WMT\", \"KO\" };");
        bool pricesExist = fileContent.Contains("decimal[] stockPrices = { 173.50m, 147.23m, 401.89m, 177.23m, 495.27m, 185.10m, 817.49m, 146.75m, 59.93m, 60.45m };");

        Assert.True(tickersExist && pricesExist, "StockPriceController.cs does not contain definititions for the string arrays \"stockTickers\" and \"stockPrices\"");
    }

    [Fact]
    public void DoesCorrectHTTPGetMethodExistOnStockPriceController()
    {
        bool httpGetAttributeExists = fileContent.Contains("[HttpGet]");
        bool correctGetMethodExists = fileContent.Contains("public IEnumerable<StockPrices> Get()");

        Assert.True(httpGetAttributeExists && correctGetMethodExists, "StockPriceController.cs does not contain the correct \"HTTPGet\" attribute or does not contain the correct \"Get()\" method");
    }

    [Fact]
    public void DoesStockPriceControllerContainOriginalLogicFromProgram()
    {
        bool selectIntoPricesExists = fileContent.Contains("var prices = Enumerable.Range(0, 9).Select(index =>");
        bool newStockPricesExists = fileContent.Contains("new StockPrices");
        bool tickersIndexExists = fileContent.Contains("stockTickers[index],");
        bool toArrayExists = fileContent.Contains(".ToArray();");
        bool returnPricesExists = fileContent.Contains("return prices;");
        bool correctLogicFromProgramCS = selectIntoPricesExists && newStockPricesExists && tickersIndexExists && toArrayExists && returnPricesExists;

        Assert.True(correctLogicFromProgramCS, "StockPriceController.cs does not contain the original logic from \"Program.cs\" in the HTTP Get method");
    }
}

public class ProgramTests
{
    string fileContent;

    public ProgramTests()
    {
        fileContent = File.ReadAllText(@"../../../../StockPriceTracker/Program.cs");
    }

    [Fact]
    public void DoesProgramNoLongerHaveStockTickersAndPricesArrays()
    {
        bool tickersExist = fileContent.Contains("string[] stockTickers = { \"AAPL\", \"GOOGL\", \"MSFT\", \"AMZN\", \"META\", \"TSLA\", \"NVDA\", \"JPM\", \"WMT\", \"KO\" };");
        bool pricesExist = fileContent.Contains("decimal[] stockPrices = { 173.50m, 147.23m, 401.89m, 177.23m, 495.27m, 185.10m, 817.49m, 146.75m, 59.93m, 60.45m };");

        Assert.True(!tickersExist && !pricesExist, "Program.cs still contains definititions for the string arrays \"stockTickers\" and \"stockPrices\"");
    }

    [Fact]
    public void DoesProgramNoLongerHaveStockPricesGetRoute()
    {
        bool programGetExists = fileContent.Contains("app.MapGet(\"/StockPrices\", () =>");

        Assert.True(!programGetExists, "Program.cs still contains a definition for the /StockPrices HTTP Get Route");
    }

    [Fact]
    public void DoesProgramHaveCodeToAddAndMapControllers()
    {
        bool addControllersExists = fileContent.Contains("builder.Services.AddControllers();");
        bool mapControllersExists = fileContent.Contains("app.MapControllers();");


        Assert.True(addControllersExists && mapControllersExists, "Program.cs does not contains correct code to add and map controllers to the API");
    }
}
