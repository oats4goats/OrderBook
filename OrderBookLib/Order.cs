using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBookLib;

public class Order
{
    public string TickerSymbol { get; private set; }
    public OrderType Type { get; private set; }
    public decimal Price { get; private set; }
    public int Size { get; private set; }

    public Order(string tickerSymbol, OrderType type, decimal price, int size)
    {
        TickerSymbol = tickerSymbol;
        Type = type;
        Price = price;
        Size = size;
    }

    public void UpdatePrice(decimal price)
    {
        throw new NotImplementedException();
    }

    public void UpdateSize(int size)
    {
        Size = size;
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
