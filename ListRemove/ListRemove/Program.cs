using System.Net.WebSockets;
using orderTuple = (string tickerSymbol, decimal price, int shares, string orderType);

namespace ListRemove
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal? x = null;
            decimal? y = 1M;

            Order order = new Order();
            List<Order> orders = new() { order };


            Console.WriteLine(object.ReferenceEquals(order, orders[0]));

        }

        class Order()
        {
            public int shares;
        }
    }
}
