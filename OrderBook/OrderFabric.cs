using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using orderTuple = (string tickerSymbol, decimal price, int shares, string orderType);

namespace OrderBook
{
    internal class OrderFabric
    {
        public static string SetTicker()
        {
            string output = string.Empty;

            do
            {
                Console.Write("Enter ticker's symbol (MSFT): ");
                output = Console.ReadLine();
            } while (output != "MSFT");

            return output;
        }

        public static decimal SetPrice()
        {
            decimal output;
            bool isValidNumber;
            string outputString = string.Empty;

            do
            {
                Console.Write("Enter price: ");
                outputString = Console.ReadLine();
                isValidNumber = decimal.TryParse(outputString, out output);
            }
            while (isValidNumber == false || output <= 0);

            return output;
        }

        public static int SetShares()
        {
            int output;
            bool isValidNumber;
            string outputString = string.Empty;

            do
            {
                Console.Write("Enter number of shares: ");
                outputString = Console.ReadLine();
                isValidNumber = int.TryParse(outputString, out output);
            }
            while (isValidNumber == false || output <= 0);

            return output;
        }

        public static string SetOrderType()
        {
            string output = string.Empty;

            do
            {
                Console.Write("Enter order type (ask/bid): ");
                output = Console.ReadLine();
            } while (output != "ask" && output != "bid");

            return output;
        }

        public static orderTuple CreateOrder (string tickerSymbol, decimal price, int shares, string orderType)
        {
            orderTuple output = (tickerSymbol, price, shares, orderType);
            return output;
        }
    }
}
