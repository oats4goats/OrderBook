namespace OrderBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int.TryParse(iString, out i);


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

            string tickerSymbol = string.Empty;
            decimal accountMoney = 0M;
            int accountStock = 0;

            tickerSymbol = Initializer.SetTicker(tickerSymbol);
            accountMoney = Initializer.SetBalanceMoney(accountMoney);
            accountStock = Initializer.SetBalanceStock(accountStock);


            Console.WriteLine($"tickerSymbol: {tickerSymbol}\n" +
                $"accountMoney: {accountMoney}\n" +
                $"accountStock: {accountStock}");

        }
    }
}
