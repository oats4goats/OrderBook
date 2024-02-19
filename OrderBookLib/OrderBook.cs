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
        int minSize = 0;

        while (Spread() <= 0)
        {
            minSize = Math.Min(Orders[OrderType.ask][0].Size, Orders[OrderType.bid][0].Size);
            
            Orders[OrderType.ask][0].UpdateSize(Orders[OrderType.ask][0].Size - minSize);
            Orders[OrderType.bid][0].UpdateSize(Orders[OrderType.bid][0].Size - minSize);

            if (Orders[OrderType.ask][0].Size == 0) Orders[OrderType.ask].RemoveAt(0);
            if (Orders[OrderType.bid][0].Size == 0) Orders[OrderType.bid].RemoveAt(0);
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
