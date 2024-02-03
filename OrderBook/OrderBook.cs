using System;
using System.Collections.Generic;
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
    }
}
