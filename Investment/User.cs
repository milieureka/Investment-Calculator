using System;

namespace Investment
{
    public class User
    {
        public string UserId { get; private set; }
        public string Username { get; private set; }
        public List<Investment> Investments { get; private set; }
        public Portfolio Portfolio { get; private set; }

        public User(string userId, string username)
        {
            UserId = userId ?? throw new ArgumentNullException(nameof(userId));
            Username = username ?? throw new ArgumentNullException(nameof(username));
            Investments = new List<Investment>();
            Portfolio = new Portfolio();
        }

        public void AddInvestment(Investment investment)
        {
            if(investment == null) throw new ArgumentNullException(nameof(investment));
            Investments.Add(investment);
            Portfolio.AddInvestment(investment);
        }
    }
}