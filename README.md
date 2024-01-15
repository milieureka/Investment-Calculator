# Investment Calculator

## Overview
The Investment Calculator is a risk assessment tool designed to calculate and assess soley or porfolio investment based on C#. This application fetch real data from internet using Newtonsoft.Json and leverages object-oriented principles to manage user interactions, risk assessments, and investment portfolios.

![UML Diagram](https://github.com/milieureka/Investment-Calculator/blob/main/UML%20Class%20diagram-Investment%20Program.png)

## Features
- **User Management**: Handle user sessions and profiles.
- **Investment Analysis**: Calculate potential returns and risk profiles of different investment types.
- **Portfolio Management**: Track and manage multiple investment portfolios.

## How to Use
1. Clone the repository to your local machine.
2. Ensure you have .NET framework installed.
3. Navigate to the project directory and build the project.
4. Execute the program to start calculating investments.

## Code Structure
The codebase is structured as follows:

- `UIManagement`: Handles all user interactions.
- `RiskAssessment`: Provides functionality to assess investment risks.
- `Investment` (Abstract): Serves as a base class for different types of investments.
  - `BondInvestment`: Handles specifics of bond investments.
  - `StockInvestment`: Manages stock investment calculations.
- `Portfolio`: Aggregates multiple investments and provides portfolio analysis.

## Contributing
Feel free to fork the repository and submit pull requests. For major changes, please open an issue first to discuss what you would like to change.

## License
This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details.

## Contact
If you have any questions or feedback, please contact me at [https://www.linkedin.com/in/huyenmili/)https://www.linkedin.com/in/huyenmili/].
