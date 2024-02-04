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
* 
*/


using orderTuple = (string tickerSymbol, decimal price, int shares, string orderType);

namespace OrderBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<orderTuple>> orders = new ();
            orders["ask"] = new List<orderTuple>();
            orders["bid"] = new List<orderTuple> ();

            string tickerSymbol = string.Empty;
            decimal accountMoney = 0M;
            int accountStock = 0;

            tickerSymbol = Initializer.SetTicker();
            accountMoney = Initializer.SetBalanceMoney();
            accountStock = Initializer.SetBalanceStock();

            Console.WriteLine($"\ntickerSymbol: {tickerSymbol}\n" +
                $"accountMoney: {accountMoney}\n" +
                $"accountStock: {accountStock}\n");

            // Debug
            orders["ask"].Add(("MSFT", 150M, 2, "ask"));
            orders["ask"].Add(("MSFT", 155M, 5, "ask"));
            orders["ask"].Add(("MSFT", 165M, 3, "ask"));
            orders["ask"].Add(("MSFT", 170M, 1, "ask"));

            orders["bid"].Add(("MSFT", 140M, 4, "bid"));
            orders["bid"].Add(("MSFT", 130M, 2, "bid"));
            orders["bid"].Add(("MSFT", 125M, 6, "bid"));
            orders["bid"].Add(("MSFT", 120M, 2, "bid"));

            while (true)
            {
                Console.WriteLine();
                for (int i = orders["ask"].Count - 1; i >= 0; i--)
                {
                    Console.WriteLine($"orderType: {orders["ask"][i].orderType}; " +
                        $"tickerSymbol: {orders["ask"][i].tickerSymbol}; " +
                        $"shares: {orders["ask"][i].shares}; " +
                        $"price: {orders["ask"][i].price}");
                }

                Console.WriteLine($"\nSpread: {OrderBook.Spread(orders)}\n");

                for (int i = 0; i < orders["bid"].Count; i++)
                {
                    Console.WriteLine($"orderType: {orders["bid"][i].orderType}; " +
                        $"tickerSymbol: {orders["bid"][i].tickerSymbol}; " +
                        $"shares: {orders["bid"][i].shares}; " +
                        $"price: {orders["bid"][i].price}");
                }

                Console.WriteLine();

                orderTuple order = OrderFabric.CreateOrder(
                    OrderFabric.SetTicker(),
                    OrderFabric.SetPrice(),
                    OrderFabric.SetShares(),
                    OrderFabric.SetOrderType());
                Console.WriteLine();

                OrderBook.Add(order, orders);

                while (OrderBook.Spread(orders) <= 0)
                {
                    OrderBook.Matching(orders);
                }
            }           
        }
    }
}
