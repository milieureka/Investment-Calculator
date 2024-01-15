using System;

namespace Investment
{
    public class UIManagement
    {
        private User _currentUser;
        public bool Exit { get; private set; } = false;

        public async Task userSelection()
        {
            Console.WriteLine("Welcome to the Investment Management System!");

            do
            {
                Console.WriteLine("Enter 1 to create a new user.");
                Console.WriteLine("Enter 2 to add an investment.");
                Console.WriteLine("Enter 3 to display investment analysis.");
                Console.WriteLine("Enter 4 to display porfolio analysis.");
                Console.WriteLine("Enter 5 to exit.");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateUser();
                        break;
                    case "2":
                        await AddInvestment();
                        break;
                    case "3":
                        DisplayInvestmentAnalysis();
                        break;
                    case "4":
                        DisplayPortfolioAnalysis();
                        break;
                    case "5":
                        Exit = true;
                        return;
                    default:
                        Console.WriteLine("Invalid input.");
                        break;
                }
            }
            while (!Exit);
        }

        public void CreateUser()
        {
            Console.Write("Enter a username: ");
            string username = Console.ReadLine();
            string userId = Guid.NewGuid().ToString();

            _currentUser = new User(userId, username);
            Console.WriteLine($"User {username} with the ID {userId} created successfully.");
        }

        public async Task AddInvestment()
        {
            if (_currentUser == null)
            {
                Console.WriteLine("No user selected. Please create a user first.");
                return;
            }

            Console.Write("Enter the symbol of the investment: ");
            string symbol = Console.ReadLine().ToUpper();

            Console.Write("Enter the type of investment (stock or bond): ");
            string investmentType = Console.ReadLine().ToLower();

            // Use asynchronous operations for I/O-bound work
            switch (investmentType)
            {
                case "stock":
                    StockInvestment stockInvestment = new StockInvestment(symbol, 10000, 0)
                    {
                        Symbol = symbol ?? throw new ArgumentNullException(nameof(symbol))
                    };
                    await stockInvestment.UpdateFromYahooFinance(symbol);
                    _currentUser.AddInvestment(stockInvestment);
                    Console.WriteLine($"Stock investment with symbol {symbol} was successfully added to the user's portfolio.");
                    break;
                case "bond":
                    BondInvestment bondInvestment = new BondInvestment(symbol, 10000, 0)
                    {
                        Symbol = symbol ?? throw new ArgumentNullException(nameof(symbol))
                    };
                    await bondInvestment.UpdateFromYahooFinance(symbol);
                    _currentUser.AddInvestment(bondInvestment);
                    Console.WriteLine($"Bond investment with symbol {symbol} was successfully added to the user's portfolio.");
                    break;
                default:
                    Console.WriteLine($"Invalid investment type: {investmentType}");
                    break;
            }
        }

        public void DisplayInvestmentAnalysis()
        {
            if (_currentUser == null)
            {
                Console.WriteLine("No user selected. Please create a user first.");
                return;
            }

            Console.WriteLine($"Investment Analysis for {_currentUser.Username}:");

            foreach (var investment in _currentUser.Investments)
            {
                Console.WriteLine($"Investment Type: {investment.Type}");
                Console.WriteLine($"Amount Invested: {investment.GetAmountInvested():C}");
                Console.WriteLine($"ROI: {investment.CalculateROI():P}");
                Console.WriteLine($"Profit/Loss: {investment.CalculatePL():C}");
                Console.WriteLine($"Risk Assessment: {investment.AssessRisk()}");
                Console.WriteLine();
            }
        }

        public void DisplayPortfolioAnalysis()
        {
            if (_currentUser == null)
            {
                Console.WriteLine("No user selected. Please create a user first.");
                return;
            }

            Console.WriteLine($"Portfolio Analysis for {_currentUser.Username}:");
            Console.WriteLine($"Total ROI: {_currentUser.Portfolio.CalculateTotalROI():P}");
            Console.WriteLine($"Total P/L: {_currentUser.Portfolio.CalculateTotalPL():C}");
            Console.WriteLine($"Portfolio Risk: {_currentUser.Portfolio.AssessPortfolioRisk()}");
            Console.WriteLine("Investments:");

            foreach (var investment in _currentUser.Portfolio.Investments)
            {
                Console.WriteLine($"- {investment.Symbol}");
            }
        }
    }
}
