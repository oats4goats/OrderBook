# OrderBook

Welcome to OrderBookApp! This application simulates a stock order book system.

OrderBook is a console app that allows anyone to engage in a naive implementation of trading activity that happens on a stock exchange's floor, namely buying and selling shares.

## Table of Contents

- [Introduction](#introduction)

- [Prerequisites](#prerequisites)

- [Project Structure](#project-structure)

- [How to Play](#how-to-play)

- [TODO List](#todo-list)

- [Example Orders](#example-orders)

- [Running the Application](#running-the-application)

- [Contributing](#contributing)

- [License](#license)

## Introduction

OrderBookApp is a C# console application that allows you to simulate stock trading with an order book. The code includes components for initializing player settings, managing orders, and executing trades.

## Prerequisites

- .NET SDK installed on your machine ([Download .NET SDK](https://dotnet.microsoft.com/download))

## Project Structure

The project is structured into several components:

- `Initializer.cs`: Provides methods for setting up initial game parameters.

- `OrderBook.cs`: Manages the order book, including adding and matching orders.

- `OrderFabric.cs`: Facilitates the creation of orders.

- `Program.cs`: The main program where the game logic is executed.

## How to Play

1.  **Clone the Repository:**

```bash
git clone https://github.com/your-username/OrderBookApp.git
```

2. **Build and Run:**

```bash
cd OrderBookApp
```

```bash
dotnet build
```

```bash
dotnet run
```

3.  **Set Initial Parameters:**

    - Ticker (MSFT, GOOG)
    - Number of Players (3,000)
    - Initial Money Balance
    - Initial Stock Balance

4.  **Player's Turn:**

    - Trader submits an order.
    - Exchange registers the order.
    - Exchange executes orders.
    - Exchange displays the current order book state.

5.  **TODO List (As of 04.02.2024):**

    - Add the ability to edit or delete an order.
    - Implement account balances.
    - Change the order type to a custom class/structure.
    - Add a menu.
    - Enhance console output (consider Unix-style formatting).

## Example Orders

The application includes some example orders for debugging purposes.

### Sample Orders

#### Ask Orders

- MSFT, 150M, 2, ask
- MSFT, 155M, 5, ask
- MSFT, 165M, 3, ask
- MSFT, 170M, 1, ask

#### Bid Orders

- MSFT, 140M, 4, bid
- MSFT, 130M, 2, bid
- MSFT, 125M, 6, bid
- MSFT, 120M, 2, bid

## Running the Application

1.  Clone the repository.
2.  Build and run the application in a compatible environment.

## Contributing

Feel free to contribute to the development of OrderBookApp. Fork the repository, make changes, and submit a pull request. Any contributions are welcome!

## License

This project is licensed under the MIT License - see the [LICENSE](./LICENSE) file for details.
