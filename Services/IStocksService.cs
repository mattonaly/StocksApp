using Models;

namespace Services
{
    public interface IStocksService
    {
        List<Error> GetErrors();
        TickerResponse GetTicker(string symbol);
        OpenClose GetOpenClose(string ticker, DateTime date);
        void AddToWatchlist(TickerResult ticker);
        void RemoveFromWatchlist(string ticker);
        IEnumerable<WatchedStock> GetWatchlist();
    }
}