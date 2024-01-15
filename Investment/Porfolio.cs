using System;

namespace Investment
{
    public class Portfolio
    {
        public string PortfolioId { get; private set; }

        public List<Investment> Investments { get; set; }

        public Portfolio()
        {
            Investments = new List<Investment>();
        }

        public void AddInvestment(Investment investment)
        {
            Investments.Add(investment);
        }

        public void RemoveInvestment(Investment investment)
        {
            Investments.Remove(investment);
        }

        public decimal CalculateTotalROI()
        {
            decimal totalROI = 0;
            foreach (var investment in Investments)
            {
                totalROI += investment.CalculateROI();
            }
            return totalROI;
        }

        public decimal CalculateTotalPL()
        {
            decimal totalPL = 0;
            foreach (var investment in Investments)
            {
                totalPL += investment.CalculatePL();
            }

            return totalPL;
        }

        public string AssessPortfolioRisk()
        {
            string portfolioRisk = "Low Risk";

            foreach (var investment in Investments)
            {
                string investmentRisk = investment.AssessRisk();

                if (investmentRisk == "High Risk")
                {
                    return "High Risk";  // If any investment is high risk, the portfolio is high risk
                }
                else if (investmentRisk == "Medium Risk" && portfolioRisk != "High Risk")
                {
                    portfolioRisk = "Medium Risk";  // If any investment is medium risk, the portfolio is at least medium risk
                }
            }

            return portfolioRisk;
        }
    }
}

