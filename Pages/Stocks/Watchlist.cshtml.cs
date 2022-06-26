using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Services;

namespace StocksApp.Pages.Stocks;

[Authorize]
public class WatchlistModel : PageModel
{
    private readonly ILogger<WatchlistModel> _logger;
    private readonly IStocksService _stocksService;
    public List<WatchedStock> Watchlist { get; set; }

    public WatchlistModel(ILogger<WatchlistModel> logger, IStocksService stocksService)
    {
        _logger = logger;
        _stocksService = stocksService;
    }

    public void OnGet()
    {
        Watchlist = _stocksService.GetWatchlist().ToList();
    }

    public void OnPost()
    {
        var symbol = Request.Form["item.StockSymbol"];
        _stocksService.RemoveFromWatchlist(symbol);

        OnGet();
    }
}