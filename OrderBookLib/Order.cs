using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBookLib;

public class Order
{
    public string TickerSymbol { get; private set; }
    public string OrderType { get; private set; }
    public decimal Price { get; private set; }
    public int Shares { get; private set; }

    public Order(string tickerSymbol, string orderType, decimal price, int shares)
    {
        TickerSymbol = tickerSymbol;
        OrderType = orderType;
        Price = price;
        Shares = shares;
    }

    public void UpdatePrice(decimal price)
    {
        throw new NotImplementedException();
    }

    public void UpdateShares(int shares)
    {
        Shares = shares;
    }

    public static void CheckTicker(string ticker)
    {
        throw new NotImplementedException();
    }

    public static void CheckPrice(string price)
    {
        throw new NotImplementedException();
    }
}
