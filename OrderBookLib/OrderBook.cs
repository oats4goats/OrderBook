using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBookLib;

public class OrderBook
{
    public Dictionary<string,List<Order>> Orders { get; set; }

    public void Add(Order order)
    {
        if (Orders.ContainsKey(order.OrderType)) 
        {
            int i;

            for (i = 0; i < Orders[order.OrderType].Count; i++)
            {
                if (order.OrderType == "ask")
                {
                    if (order.Price < Orders[order.OrderType][i].Price)
                    {
                        break;
                    }
                }
                else if (order.OrderType == "bid")
                {
                    if (order.Price > Orders[order.OrderType][i].Price)
                    {
                        break;
                    }
                }
            }

            Orders[order.OrderType].Insert(i, order);
        }
        else
        {
            Orders.Add(order.OrderType, new List<Order>() { order });
        }
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
