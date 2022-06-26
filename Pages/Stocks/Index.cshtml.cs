using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;

namespace StocksApp.Pages.Stocks;

[Authorize]
public class IndexModel : PageModel
{
    public List<Stock> Stocks { get; set; }
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
        Stocks = new List<Stock>();
        Stocks.Add(new Stock { Symbol = "MSFT", Name = "Microsoft" });
        Stocks.Add(new Stock { Symbol = "AAPL", Name = "Apple" });
        Stocks.Add(new Stock { Symbol = "GOOG", Name = "Google" });
        Stocks.Add(new Stock { Symbol = "FB", Name = "Facebook" });
        Stocks.Add(new Stock { Symbol = "TWTR", Name = "Twitter" });
        Stocks.Add(new Stock { Symbol = "AMZN", Name = "Amazon" });
        Stocks.Add(new Stock { Symbol = "GOOGL", Name = "Google" });
        Stocks.Add(new Stock { Symbol = "YHOO", Name = "Yahoo" });
        Stocks.Add(new Stock { Symbol = "EBAY", Name = "Ebay" });
        Stocks.Add(new Stock { Symbol = "LNKD", Name = "LinkedIn" });
        Stocks.Add(new Stock { Symbol = "TWLO", Name = "Twilio" });
        Stocks.Add(new Stock { Symbol = "TSLA", Name = "Tesla" });
        Stocks.Add(new Stock { Symbol = "AMAT", Name = "Amazon" });
        Stocks.Add(new Stock { Symbol = "NVDA", Name = "Nvidia" });
        Stocks.Add(new Stock { Symbol = "INTC", Name = "Intel" });
        Stocks.Add(new Stock { Symbol = "AMD", Name = "Advanced Micro Devices" });
        Stocks.Add(new Stock { Symbol = "TXN", Name = "Texas Instruments" });
        Stocks.Add(new Stock { Symbol = "ORCL", Name = "Oracle" });
        Stocks.Add(new Stock { Symbol = "CSCO", Name = "Cisco" });
        Stocks.Add(new Stock { Symbol = "SAP", Name = "SAP" });
        Stocks.Add(new Stock { Symbol = "PYPL", Name = "PayPal" });
        Stocks.Add(new Stock { Symbol = "ADBE", Name = "Adobe" });
        Stocks.Add(new Stock { Symbol = "AMGN", Name = "Amgen" });
        Stocks.Add(new Stock { Symbol = "ADSK", Name = "Autodesk" });
        Stocks.Add(new Stock { Symbol = "ADP", Name = "Autodesk" });
        Stocks.Add(new Stock { Symbol = "BIDU", Name = "Baidu" });
        Stocks.Add(new Stock { Symbol = "CMG", Name = "Chipotle" });
        Stocks.Add(new Stock { Symbol = "CMCSA", Name = "Comcast" });
        Stocks.Add(new Stock { Symbol = "CSCO", Name = "Cisco" });
        Stocks.Add(new Stock { Symbol = "C", Name = "Citigroup" });
        Stocks.Add(new Stock { Symbol = "CTSH", Name = "Cognizant" });
        Stocks.Add(new Stock { Symbol = "CSCO", Name = "Cisco" });
        Stocks.Add(new Stock { Symbol = "CSCO", Name = "Cisco" });
    }

    public void OnGet()
    {
    }
}
