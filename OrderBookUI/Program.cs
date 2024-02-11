/**
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
        Account account = new Account(accountName: "MyAccount");
    
        account.Deposit(asset: "MSFT", amount: 100);
        account.Deposit(asset: "GOOG", amount: 100);

        OrderBook orderBook = new();

        // Debug
        orderBook.Add(order: new Order(tickerSymbol: "MSFT", orderType: "ask", price: 150M, shares: 2));
        orderBook.Add(order: new Order(tickerSymbol: "MSFT", orderType: "ask", price: 155M, shares: 5));
        orderBook.Add(order: new Order(tickerSymbol: "MSFT", orderType: "ask", price: 165M, shares: 3));
        orderBook.Add(order: new Order(tickerSymbol: "MSFT", orderType: "ask", price: 170M, shares: 1));
        orderBook.Add(order: new Order(tickerSymbol: "MSFT", orderType: "bid", price: 140M, shares: 4));
        orderBook.Add(order: new Order(tickerSymbol: "MSFT", orderType: "bid", price: 130M, shares: 2));
        orderBook.Add(order: new Order(tickerSymbol: "MSFT", orderType: "bid", price: 125M, shares: 6));
        orderBook.Add(order: new Order(tickerSymbol: "MSFT", orderType: "bid", price: 120M, shares: 2));

        while (true)
        {
            // Enter order
            Console.Write("Enter ticker: ");
            string ticker = Console.ReadLine();
            Order.CheckTicker(ticker);


            Console.Write("Enter price: ");
            string priceString = Console.ReadLine();

            // Add order to OrderBook
            // Match orders in OrderBook
        }         
    }
}
