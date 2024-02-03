using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OrderBook
{
    internal class Initializer
    {
        public static string SetTicker(string symbol)
        {
            string output = string.Empty;

            do
            {
                Console.Write("Enter ticker's symbol: ");
                output = Console.ReadLine(); 
            } while (string.IsNullOrEmpty(output) || string.IsNullOrWhiteSpace(output));
            
            return output;
        }

        public static decimal SetBalanceMoney(decimal balanceMoney)
        {
            decimal output;
            bool isValidNumber;
            string outputString = string.Empty;

            do
            {
                Console.Write("Enter money balance: ");
                outputString = Console.ReadLine();
                isValidNumber = decimal.TryParse(outputString, out output);
            }
            while (isValidNumber == false || output <= 0);

            return output;
        }

        public static int SetBalanceStock(int balanceStock)
        {
            int output;
            bool isValidNumber;
            string outputString = string.Empty;

            do
            {
                Console.Write("Enter stock balance: ");
                outputString = Console.ReadLine();
                isValidNumber = int.TryParse(outputString, out output);
            }
            while (isValidNumber == false || output <= 0);

            return output;
        }
    }
}
