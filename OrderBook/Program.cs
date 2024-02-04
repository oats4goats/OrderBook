using orderTuple = (string tickerSymbol, decimal price, int shares, string orderType);

namespace OrderBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Перед началом игры:

            -Тикер(MSFT, GOOG)
            // - Кол - во игроков(3 000)
            - Кол - во денег на счете
            - Кол - во акций на счете

            Ход игрока(порядок действий):

            - Трейдер передает заявку биржи
            - Биржа регистрирует заявку
            - Биржа исполняет заявки
            - Биржа отображает текущее состояние стакана
            */

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
            //for (int i = 0; i < 8; i++)
            //{
            //    orderTuple order = OrderFabric.CreateOrder(
            //    OrderFabric.SetTicker(),
            //    OrderFabric.SetPrice(),
            //    OrderFabric.SetShares(),
            //    OrderFabric.SetOrderType());
            //    Console.WriteLine();

            //    OrderBook.Add(order, orders);
            //}

            //foreach (var item in orders["ask"])
            //{
            //    Console.WriteLine($"orderType: {item.orderType}; tickerSymbol: {item.tickerSymbol}; shares: {item.shares}; price: {item.price}");
            //}

            //foreach (var item in orders["bid"])
            //{
            //    Console.WriteLine($"orderType: {item.orderType}; tickerSymbol: {item.tickerSymbol}; shares: {item.shares}; price: {item.price}");
            //}
        }
    }
}
