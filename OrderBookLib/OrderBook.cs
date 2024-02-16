using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBookLib;

public class OrderBook
{
    public Dictionary<string,List<Order>> Orders { get; set; } = new()
    {
        {"ask", []},
        {"bid", []}
    };

    private delegate bool Callback(decimal a, decimal b);

    public void Add(Order order)
    {
        Callback stop;

        if (order.OrderType == "ask")
        {
            stop = (a, b) => {if (a < b) return true; else return false;};
        }
        else if (order.OrderType == "bid")
        {
            stop = (a, b) => {if (a > b) return true; else return false;};
        }
        else throw new Exception();
        
        int i = 0;
        for (; (i < Orders[order.OrderType].Count && !stop(order.Price, Orders[order.OrderType][i].Price)); i++);
        Orders[order.OrderType].Insert(i, order);

    }

    public void Match()
    {
        int sharesDelta;

        sharesDelta = Orders["ask"][0].Shares - Orders["bid"][0].Shares;

        if (sharesDelta > 0)
        {
            // delete bid
            Order deletedOrder = Orders["bid"][0];
            Orders["bid"].RemoveAt(0);

            Console.WriteLine($"Deleted bid: {deletedOrder}");

            // update ask
            Order updatedOrder = Orders["ask"][0];
            updatedOrder.UpdateShares(sharesDelta);

            Orders["ask"][0] = updatedOrder;
        }
        else if (sharesDelta < 0)
        {
            // delete ask
            Order deletedOrder = Orders["ask"][0];
            Orders["ask"].RemoveAt(0);

            Console.WriteLine($"Deleted ask: {deletedOrder}");

            // update bid
            Order updatedOrder = Orders["bid"][0];
            updatedOrder.UpdateShares(Math.Abs(sharesDelta));

            Orders["bid"][0] = updatedOrder;
        }
        else if (sharesDelta == 0)
        {
            // delete ask
            Order deletedOrderAsk = Orders["ask"][0];
            Orders["ask"].RemoveAt(0);

            // delete bid
            Order deletedOrderBid = Orders["bid"][0];
            Orders["bid"].RemoveAt(0);

            Console.WriteLine($"Deleted ask: {deletedOrderAsk}");
            Console.WriteLine($"Deleted bid: {deletedOrderBid}");
        }
    }

    public decimal? Spread()
    {
        decimal? output = null;

        if (Orders["ask"].Count != 0 && Orders["bid"].Count != 0)
        {
            output = Orders["ask"][0].Price - Orders["bid"][0].Price;
        }

        return output;
    }
}
