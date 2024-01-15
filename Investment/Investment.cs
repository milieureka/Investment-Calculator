using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Investment
{
    public abstract class Investment
    {
        public string Type { get; set; }
        protected decimal AmountInvested { get; set; }
        protected decimal ROI { get; set; }
        protected decimal PL { get; set; }
        public abstract string AssessRisk();
        public string Symbol { get; set; }

        public Investment(decimal amountInvested, decimal roi)
        {
            this.AmountInvested = amountInvested;
            this.ROI = roi;
        }

        public abstract Task UpdateFromYahooFinance(string symbol);

        public decimal GetAmountInvested()
        {
            return AmountInvested;
        }

        public virtual decimal CalculateROI()
        {
            decimal netProfit = AmountInvested * ROI;
            decimal costOfInvestment = AmountInvested;
            decimal roi = (netProfit / costOfInvestment) * 100;
            return roi;
        }

        public virtual decimal CalculatePL()
        {
            decimal pl = AmountInvested * ROI;
            return pl;
        }
    }

    public class BondInvestment : Investment
    {
        public string InvestmentId { get; private set; }

        public BondInvestment(string investmentId, decimal amountInvested, decimal roi) : base(amountInvested, roi)
        {
            Type = "Bonds";
            this.InvestmentId = investmentId ?? throw new ArgumentNullException(nameof(investmentId));
        }

        public override async Task UpdateFromYahooFinance(string symbol)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string url = $"https://query1.finance.yahoo.com/v8/finance/chart/{symbol}?interval=1d";
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(responseBody);
                    Console.WriteLine(json.ToString());

                    JObject result = (JObject)json["chart"]["result"][0];
                    JArray quotesArray = (JArray)result["indicators"]["quote"];
                    JObject quotes = (JObject)quotesArray[0];

                    decimal latestPrice = (decimal)quotes["close"][0];
                    decimal openPrice = (decimal)quotes["open"][0];
                    ROI = (latestPrice - openPrice) / openPrice;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Error retrieving data from Yahoo Finance: {e.Message}");
                }
            }
        }

        public override string AssessRisk()
        {
            return RiskAssessment.AssessBondRisk(AmountInvested, PL, ROI);
        }
    }

    public class StockInvestment : Investment
    {
        public string InvestmentId { get; private set; }

        public StockInvestment(string investmentId, decimal amountInvested, decimal roi)
            : base(amountInvested, roi)
        {
            Type = "Stocks";
            this.InvestmentId = investmentId ?? throw new ArgumentNullException(nameof(investmentId));
        }

        public override async Task UpdateFromYahooFinance(string symbol)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string url = $"https://query1.finance.yahoo.com/v8/finance/chart/{symbol}?interval=1d";
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(responseBody);
                    Console.WriteLine(json.ToString());

                    JObject result = (JObject)json["chart"]["result"][0];
                    JArray quotesArray = (JArray)result["indicators"]["quote"];
                    JObject quotes = (JObject)quotesArray[0];

                    decimal latestPrice = (decimal)quotes["close"][0];
                    decimal openPrice = (decimal)quotes["open"][0];
                    ROI = (latestPrice - openPrice) / openPrice;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Error retrieving data from Yahoo Finance: {e.Message}");
                }
            }
        }

        public override string AssessRisk()
        {
            return RiskAssessment.AssessStockRisk(AmountInvested, PL, ROI);
        }
    }
}
