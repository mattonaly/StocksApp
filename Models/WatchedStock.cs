
using Microsoft.AspNetCore.Identity;

namespace Models
{
    public class WatchedStock
    {
        public string UserId { get; set; }
        public string StockSymbol { get; set; }
        public string StockName { get; set; }
        public string StockLogo { get; set; }
        public string StockLocale { get; set; }
    }
}