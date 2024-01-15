using System;

namespace Investment
{
    public class Program
    {
        public static void Main()
        {
            UIManagement uiManager = new UIManagement();

            while (!uiManager.Exit)
            {
                uiManager.userSelection().Wait();

                if (uiManager.Exit)
                {
                    break;
                }

                uiManager.CreateUser();
                uiManager.AddInvestment().Wait();

                uiManager.DisplayInvestmentAnalysis();
                uiManager.DisplayPortfolioAnalysis();
            }
        }
    }
}
