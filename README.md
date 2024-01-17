# Investment Calculator

## Language:
C#, Newtonsoft.Json, .NET Application.

## Overview
The Investment Calculator is a risk assessment tool designed to calculate and assess soley or porfolio investment. This application fetch real data from internet and leverages object-oriented principles to manage user choice of investment (stock/ bond), investment portfolios risk assessments.

![UML Diagram](https://github.com/milieureka/Investment-Calculator/blob/main/UML%20Class%20diagram-Investment%20Program.png)

## Code Structure
There are 6 classes reponsible to run the program:

- `User`: Storing user's username, password, and a list of investments.
- `UIManagement`: Encapsulates all user interface and user interactions.
- `Investment` (Abstract): Base class for different types of investments, have a parent caculation ROI & PnL methods.
  - `BondInvestment`& `StockInvestment`: Inherit methods from base class and overide the Task to fetch real data from Yahoo Finance.
- `RiskAssessment`: Provides functionality to assess investment risks.
- `Portfolio`: Aggregates multiple investments and provides portfolio analysis.
- `Program`: Having main static method to handle execution of this program.

## Result


## How to Use
1. Clone the repository to your local machine.
2. Ensure you have .NET framework installed.
3. Navigate to the project directory and build the project.
4. Execute the program to start calculating investments.
## Contributing
Feel free to fork the repository and submit pull requests. For major changes, please open an issue first to discuss what you would like to change.

## License
This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details.

## Contact
If you have any questions or feedback, please contact me at [https://www.linkedin.com/in/huyenmili/].
