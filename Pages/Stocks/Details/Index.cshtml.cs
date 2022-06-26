using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.JSInterop;
using Models;
using Services;

namespace StocksApp.Pages.Stocks.Details;

[Authorize]
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public readonly IStocksService _stocksService;

    public IndexModel(ILogger<IndexModel> logger, IStocksService stocksService)
    {
        _logger = logger;
        _stocksService = stocksService;
    }

    [BindProperty]
    public TickerResult Stock { get; set; }
    public void OnGet(string symbol)
    {
        Stock = _stocksService.GetTicker(symbol).results;
    }

    [JSInvokable]
    public void GetOpenClose(DateTime date)
    {
        Stock.open_close = _stocksService.GetOpenClose(Stock.ticker, date);
    }

    public string AddToWatchlist()
    {
        Console.WriteLine(Stock.ticker);
        _stocksService.AddToWatchlist(Stock);
        return "Success";
    }
}