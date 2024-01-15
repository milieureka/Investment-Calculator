using System;

namespace Investment
{
    public static class RiskAssessment
    {
        public static string AssessBondRisk(decimal amountInvested, decimal pl, decimal roi)
        {
            if (roi < 0m)
            {
                return "High Risk";
            }
            else if (amountInvested > 10000 && pl > 10000 && roi > 0.1m)
            {
                return "Very High Risk";
            }
            else if (amountInvested > 10000 && pl > 10000 && roi > 0.1m)
            {
                return "High Risk";
            }
            else if (amountInvested > 10000 && pl > 1000 && roi > 0.05m)
            {
                return "High Risk";
            }
            else if (amountInvested > 10000 && pl > 1000 && roi > 0.05m)
            {
                return "Medium Risk";
            }
            else
            {
                return "Low Risk";
            }
        }

        public static string AssessStockRisk(decimal amountInvested, decimal pl, decimal roi)
        {
            if (roi < 0m)
            {
                return "High Risk";
            }
            else if (amountInvested > 10000 && pl > 10000 && roi > 0.2m)
            {
                return "Very High Risk";
            }
            else if (amountInvested > 10000 && pl > 10000 && roi > 0.2m)
            {
                return "High Risk";
            }
            else if (amountInvested > 10000 && pl > 1000 && roi > 0.1m)
            {
                return "High Risk";
            }
            else if (amountInvested > 10000 && pl > 1000 && roi > 0.1m)
            {
                return "Medium Risk";
            }
            else
            {
                return "Low Risk";
            }
        }
    }
}
