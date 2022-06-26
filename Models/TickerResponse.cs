namespace Models
{
    public class TickerResponse
    {
        public TickerResult results { get; set; }
    }

    public class TickerResult
    {
        public string ticker { get; set; }
        public string name { get; set; }
        public string primary_exchange { get; set; }
        public string homepage_url { get; set; }
        public string sic_description { get; set; }
        public string description { get; set; }
        public string locale { get; set; }
        public TickerBranding branding { get; set; }
        public OpenClose open_close { get; set; }
    }

    public class TickerBranding
    {
        public string icon_url { get; set; }
        public string logo_url { get; set; }
    }
}