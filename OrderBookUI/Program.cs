/*
*  .~~~~.
*  i====i
*  ||||||
*  |iiii|   
*  `-==-'
* 
* Перед началом игры:
*
* Тикер(MSFT, GOOG)
* + Кол - во игроков(3 000)
* + Кол - во денег на счете
* + Кол - во акций на счете
*
* Ход игрока(порядок действий):
*
* + Трейдер передает заявку биржи
* + Биржа регистрирует заявку
* + Биржа исполняет заявки
* + Биржа отображает текущее состояние стакана
* 
* TODO 04.02.2024
* - Добавить редактирование, удаление заявки
* - Счет
* - Изменить тип заявки на пользовательский класс / структура
* 
* - Добавить меню (?)
* - Доработать (сделать симпатичным) вывод в консоль - обсудить unix-style (?)
* - Добавить GUID
* 
*/

using OrderBookLib;

namespace OrderBookUI;

internal class Program
{
    static void Main(string[] args)
    {
        // Initialization
        string tradingTicker = "MSFT";
        Account account = new Account(accountName: "MyAccount");
    
        account.Deposit(asset: tradingTicker, amount: 100);

        OrderBook orderBook = new();

        // Debug
        orderBook.Add(order: new Order(tickerSymbol: tradingTicker, type: OrderType.ask, price: 150M, size: 2));
        orderBook.Add(order: new Order(tickerSymbol: tradingTicker, type: OrderType.ask, price: 155M, size: 5));
        orderBook.Add(order: new Order(tickerSymbol: tradingTicker, type: OrderType.ask, price: 165M, size: 3));
        orderBook.Add(order: new Order(tickerSymbol: tradingTicker, type: OrderType.ask, price: 170M, size: 1));
        orderBook.Add(order: new Order(tickerSymbol: tradingTicker, type: OrderType.bid, price: 140M, size: 4));
        orderBook.Add(order: new Order(tickerSymbol: tradingTicker, type: OrderType.bid, price: 130M, size: 2));
        orderBook.Add(order: new Order(tickerSymbol: tradingTicker, type: OrderType.bid, price: 125M, size: 6));
        orderBook.Add(order: new Order(tickerSymbol: tradingTicker, type: OrderType.bid, price: 120M, size: 2));

        Console.Clear();
        while (true)
        {
            Console.WriteLine($"Welcome to the trading floor ({tradingTicker}):\n");
            OrderBookPrint(orderBook);
            Console.WriteLine("");

            // Enter ticker
            string ticker = string.Empty;
            do
            {
                Console.Write("Enter ticker: ");
                ticker = Console.ReadLine();
            } while (ticker.Length == 0);

            // Enter price
            decimal price;
            bool isValidPrice;
            do
            {
                Console.Write("Enter price: ");
                string priceString = Console.ReadLine();
                isValidPrice = decimal.TryParse(priceString, out price);
            }
            while (isValidPrice == false || price <= 0);

            // Enter share
            int share;
            bool isValidShare;
            do
            {
                Console.Write("Enter number of shares: ");
                string shareString = Console.ReadLine();
                isValidShare = int.TryParse(shareString, out share);
            }
            while (isValidShare == false || share <= 0);

            // Enter order type
            OrderType orderType;
            do
            {
                Console.Write("Enter order type (ask/bid): ");
                string userInput = Console.ReadLine();
                
                if (userInput == "ask")
                {
                    orderType = OrderType.ask;
                } else if (userInput == "bid")
                {
                    orderType = OrderType.bid;
                }
                else throw new InvalidOperationException("Order type must be either \"ask\" or \"bid\"");

            } while (orderType != OrderType.ask && orderType != OrderType.bid);

            Order order = new(tickerSymbol: ticker, type: orderType, price: price, size: share);
            orderBook.Add(order: order);

            orderBook.Match();
        }         
    }

    private static void OrderBookPrint(OrderBook orderBook)
    {
        Console.WriteLine("Price\u0020\u0020|\u0020Shares");
        Console.WriteLine("---------------");

        for (int i = orderBook.Orders[OrderType.ask].Count - 1; i >= 0; i--) 
        {
            Order order = orderBook.Orders[OrderType.ask][i];
            Console.WriteLine($"\u0020\u0020{order.Price}\u0020\u0020|\u0020\u0020{order.Size}");
        }
        
        Console.WriteLine("---------------");
        for (int i = 0; i < orderBook.Orders[OrderType.bid].Count; i++) 
        {
            Order order = orderBook.Orders[OrderType.bid][i];
            Console.WriteLine($"\u0020\u0020{order.Price}\u0020\u0020|\u0020\u0020{order.Size}");
        }
    }
}