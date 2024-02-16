using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBookLib;

public enum OrderType
{
    ask,
    bid
}

public class OrderBook
{
    public Dictionary<OrderType,List<Order>> Orders { get; set; } = new()
    {
        {OrderType.ask, []},
        {OrderType.bid, []}
    };

    private delegate bool Callback(decimal a, decimal b);

    public void Add(Order order)
    {
        Callback stop;

        if (order.Type == OrderType.ask)
        {
            stop = (a, b) => { return a < b; };
        }
        else if (order.Type == OrderType.bid)
        {
            stop = (a, b) => { return a > b; };
        }
        else throw new InvalidOperationException("Order type must be either \"ask\" or \"bid\"");
        
        int i = 0;
        int depthOfMarket = Orders[order.Type].Count;
        for (; i < depthOfMarket; i++)
        {
            decimal nextOrderPrice = Orders[order.Type][i].Price;
            if (stop(order.Price, nextOrderPrice)) break; 
        }
        Orders[order.Type].Insert(i, order);
    }

    public void Match()
    {
        int sharesDelta;

        sharesDelta = Orders[OrderType.ask][0].Shares - Orders[OrderType.bid][0].Shares;

        if (sharesDelta > 0)
        {
            // delete bid
            Order deletedOrder = Orders[OrderType.bid][0];
            Orders[OrderType.bid].RemoveAt(0);

            Console.WriteLine($"Deleted bid: {deletedOrder}");

            // update ask
            Order updatedOrder = Orders[OrderType.ask][0];
            updatedOrder.UpdateShares(sharesDelta);

            Orders[OrderType.ask][0] = updatedOrder;
        }
        else if (sharesDelta < 0)
        {
            // delete ask
            Order deletedOrder = Orders[OrderType.ask][0];
            Orders[OrderType.ask].RemoveAt(0);

            Console.WriteLine($"Deleted ask: {deletedOrder}");

            // update bid
            Order updatedOrder = Orders[OrderType.bid][0];
            updatedOrder.UpdateShares(Math.Abs(sharesDelta));

            Orders[OrderType.bid][0] = updatedOrder;
        }
        else if (sharesDelta == 0)
        {
            // delete ask
            Order deletedOrderAsk = Orders[OrderType.ask][0];
            Orders[OrderType.ask].RemoveAt(0);

            // delete bid
            Order deletedOrderBid = Orders[OrderType.bid][0];
            Orders[OrderType.bid].RemoveAt(0);

            Console.WriteLine($"Deleted ask: {deletedOrderAsk}");
            Console.WriteLine($"Deleted bid: {deletedOrderBid}");
        }
    }

    public decimal? Spread()
    {
        decimal? output = null;

        if (Orders[OrderType.ask].Count != 0 && Orders[OrderType.bid].Count != 0)
        {
            output = Orders[OrderType.ask][0].Price - Orders[OrderType.bid][0].Price;
        }

        return output;
    }
}
