using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using orderTuple = (string tickerSymbol, decimal price, int shares, string orderType);

namespace OrderBook
{
    internal class OrderBook
    {
        public static void Add(orderTuple order, Dictionary<string, List<orderTuple>> orders)
        {
            int i;

            for (i = 0; i < orders[order.orderType].Count; i++)
            {
                if (order.orderType == "ask")
                {
                    if (order.price < orders[order.orderType][i].price)
                    {
                        break;
                    }
                }
                else if (order.orderType == "bid")
                {
                    if (order.price > orders[order.orderType][i].price)
                    {
                        break;
                    }
                }
            }

            orders[order.orderType].Insert(i, order);
        }

        public static void Matching(Dictionary<string, List<orderTuple>> orders)
        {
            int sharesDelta;

            sharesDelta = orders["ask"][0].shares - orders["bid"][0].shares;

            if (sharesDelta > 0)
            {
                // delete bid
                orderTuple deletedOrder = orders["bid"][0];
                orders["bid"].RemoveAt(0);

                Console.WriteLine($"Deleted bid: {deletedOrder}");

                // update ask
                orderTuple updatedOrder = orders["ask"][0];
                updatedOrder.shares = sharesDelta;

                orders["ask"][0] = updatedOrder; 
            }
            else if (sharesDelta < 0)
            {
                // delete ask
                orderTuple deletedOrder = orders["ask"][0];
                orders["ask"].RemoveAt(0);

                Console.WriteLine($"Deleted ask: {deletedOrder}");

                // update bid
                orderTuple updatedOrder = orders["bid"][0];
                updatedOrder.shares = Math.Abs(sharesDelta);

                orders["bid"][0] = updatedOrder;
            }
            else if (sharesDelta == 0)
            {
                // delete ask
                orderTuple deletedOrderAsk = orders["ask"][0];
                orders["ask"].RemoveAt(0);

                // delete bid
                orderTuple deletedOrderBid = orders["bid"][0];
                orders["bid"].RemoveAt(0);

                Console.WriteLine($"Deleted ask: {deletedOrderAsk}");
                Console.WriteLine($"Deleted bid: {deletedOrderBid}");
            }
        }

        public static decimal? Spread(Dictionary<string, List<orderTuple>> orders)
        {
            decimal? output = null;

            if (orders["ask"].Count != 0 && orders["bid"].Count != 0)
            {
                output = orders["ask"][0].price - orders["bid"][0].price;
            }

            return output;
        }

    }
}
