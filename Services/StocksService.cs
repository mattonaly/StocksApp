using Microsoft.AspNetCore.Identity;
using Models;
using Newtonsoft.Json;
using StocksApp.Data;

namespace Services
{
    public class StocksService : IStocksService
    {
        private readonly List<TickerResponse> _tickerResponses = new List<TickerResponse>();
        private readonly List<Error> _errors = new List<Error>();
        private readonly ApplicationDbContext _context;
        UserManager<IdentityUser> UserManager { get; set; }
        IHttpContextAccessor HttpContext { get; set; }

        public StocksService(ApplicationDbContext context, UserManager<IdentityUser> userManager, IHttpContextAccessor httpContext)
        {
            _context = context;
            UserManager = userManager;
            HttpContext = httpContext;
        }

        public List<Error> GetErrors()
        {
            return _errors;
        }
        public TickerResponse GetTicker(string symbol)
        {
            var ticker = new TickerResponse();
            try
            {
                var response = GetUrl($"https://api.polygon.io/v3/reference/tickers/{symbol}?apiKey=GdNhXzB_Cb5PmFduSR2WcpxGA8C4Erbv");
                Console.WriteLine($"Api status code: {response.StatusCode}");
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;
                    ticker = JsonConvert.DeserializeObject<TickerResponse>(content);
                }

                response = GetUrl($"https://api.polygon.io/v1/open-close/{symbol}/{DateTime.Now.ToString("yyyy-MM-dd")}?apiKey=GdNhXzB_Cb5PmFduSR2WcpxGA8C4Erbv");
                Console.WriteLine($"Api status code: {response.StatusCode}");
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;
                    var openClose = JsonConvert.DeserializeObject<OpenClose>(content);
                    ticker.results.open_close = openClose;
                }

                _tickerResponses.Add(ticker);
                return ticker;
            }
            catch (System.Exception)
            {
                _errors.Add(new Error { Message = "Error getting ticker", StatusCode = 500 });
            }

            var tickerResponse = _tickerResponses.FirstOrDefault(x => x.results.ticker == symbol);

            _errors.Add(new Error
            {
                Message = "Ticker not found",
                StatusCode = 404
            });

            return ticker;
        }

        public OpenClose GetOpenClose(string ticker, DateTime date)
        {
            var openClose = new OpenClose();
            try
            {
                var response = GetUrl($"https://api.polygon.io/v1/open-close/{ticker}/{date.ToString("yyyy-MM-dd")}?apiKey=GdNhXzB_Cb5PmFduSR2WcpxGA8C4Erbv");
                Console.WriteLine($"Api status code: {response.StatusCode}");
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;
                    openClose = JsonConvert.DeserializeObject<OpenClose>(content);
                }
            }
            catch (System.Exception)
            {
                _errors.Add(new Error { Message = "Error getting open close", StatusCode = 500 });
            }

            return openClose;
        }

        public void AddToWatchlist(TickerResult ticker)
        {
            var userId = UserManager.GetUserId(HttpContext.HttpContext.User);

            try
            {
                _context.WatchedStocks.Add(new WatchedStock
                {
                    UserId = userId,
                    StockSymbol = ticker.ticker,
                    StockLocale = ticker.locale,
                    StockName = ticker.name,
                    StockLogo = ticker.branding.logo_url
                });
                _context.SaveChanges();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
            {
                _errors.Add(new Error { Message = "Error adding to watchlist", StatusCode = 500 });
            }
        }

        public void RemoveFromWatchlist(string ticker)
        {
            try
            {
                var userId = UserManager.GetUserId(HttpContext.HttpContext.User);

                var stock = _context.WatchedStocks.FirstOrDefault(x => x.UserId == userId && x.StockSymbol == ticker);

                Console.WriteLine($"Stock: {stock}");

                if (stock != null)
                {
                    _context.WatchedStocks.Remove(stock);
                    _context.SaveChanges();
                }
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
            {
                _errors.Add(new Error { Message = "Error removing from watchlist", StatusCode = 500 });
            }
        }

        public IEnumerable<WatchedStock> GetWatchlist()
        {
            var userId = UserManager.GetUserId(HttpContext.HttpContext.User);
            Console.WriteLine($"User id: {userId}");

            return _context.WatchedStocks.Where(x => x.UserId == userId).ToList();
        }

        private HttpResponseMessage GetUrl(string url)
        {
            Console.WriteLine($"Url: {url}");
            var client = new HttpClient();
            return client.GetAsync(url).Result;
        }
    }
}