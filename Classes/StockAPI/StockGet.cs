namespace RoboAco.Classes.StockAPI;

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class GetCashDividend
    {
        public string assetIssued { get; set; }
        public DateTime paymentDate { get; set; }
        public string rate { get; set; }
        public string relatedTo { get; set; }
        public DateTime approvedOn { get; set; }
        public string isinCode { get; set; }
        public string label { get; set; }
        public DateTime lastDatePrior { get; set; }
        public string remarks { get; set; }
    }

    public class GetDividendsData
    {
        public List<GetCashDividend> cashDividends { get; set; }
        public List<GetStockDividend> stockDividends { get; set; }
        public List<object> subscriptions { get; set; }
    }

    public class GetResult
    {
        public string symbol { get; set; }
        public string shortName { get; set; }
        public string currency { get; set; }
        public double regularMarketPrice { get; set; }
        public string regularMarketDayHigh { get; set; }
        public string regularMarketDayLow { get; set; }
        public string regularMarketDayRange { get; set; }
        public string regularMarketChange { get; set; }
        public string regularMarketChangePercent { get; set; }
        public DateTime regularMarketTime { get; set; }
        public int regularMarketVolume { get; set; }
        public string regularMarketPreviousClose { get; set; }
        public string regularMarketOpen { get; set; }
        public string fiftyTwoWeekLowChange { get; set; }
        public string fiftyTwoWeekLowChangePercent { get; set; }
        public string fiftyTwoWeekRange { get; set; }
        public string fiftyTwoWeekHighChange { get; set; }
        public string fiftyTwoWeekHighChangePercent { get; set; }
        public string fiftyTwoWeekLow { get; set; }
        public string fiftyTwoWeekHigh { get; set; }
        public string priceEarnings { get; set; }
        public string earningsPerShare { get; set; }
        public string logourl { get; set; }
        public GetDividendsData dividendsData { get; set; }
    }


    public delegate void OnPriceChangedHandler(object source, EventArgs e);
    public class GetRoot
    {
        public List<GetResult> results { get; set; }
        public DateTime requestedAt { get; set; }
    }

    public class GetStockDividend
    {
        public string assetIssued { get; set; }
        public string factor { get; set; }
        public DateTime approvedOn { get; set; }
        public string isinCode { get; set; }
        public string label { get; set; }
        public DateTime lastDatePrior { get; set; }
        public string remarks { get; set; }
    }

