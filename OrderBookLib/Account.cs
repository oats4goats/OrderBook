using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBookLib;

public class Account
{
    public string AccountName { get; private set; }
    private Dictionary<string, decimal> Assets { get; set; }

    public Account(string accountName)
    {
        AccountName = accountName;
        Assets = new Dictionary<string, decimal>();
    }

    public void Deposit(string asset, decimal amount)
    {
        if (Assets.ContainsKey(asset))
        {
            Assets[asset] += amount;
        }
        else
        {
            Assets.Add(asset, amount);
        }
    }

    public void Withdraw(string asset, decimal amount)
    {
        try
        {
            if (amount <= 0)
            {
                throw new Exception("The withdrawal amount can't be <= 0");
            }
            
            if (Assets[asset] < amount)
            {
                throw new Exception("The balance can't be less than 0");
            }

            Assets[asset] -= amount;
        }
        catch (KeyNotFoundException)
        {
            throw new KeyNotFoundException($"There is no corresponding asset for the ticker: {asset}");
        }
    }

    public decimal Balance(string asset)
    {
        try
        {
            return Assets[asset];
        }
        catch (KeyNotFoundException)
        {
            throw new KeyNotFoundException($"There is no corresponding asset for the ticker: {asset}");
        }
    }
}
