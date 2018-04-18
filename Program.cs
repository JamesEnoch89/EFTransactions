using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFTransactions.Data;

namespace EFTransactions
{
    class Program
    {
        static void Main(string[] args)
        {
            // query database
            var dbContext = new DataContext();

            //INSERT

            var t1 = new BankTranscation
            {
                Timestamp = new DateTime(2012, 06, 20),
                Action = "Withdraw",
                AccountNumber = "1234",
                AmountChanged = 123.12m,
                NewAmount = 321.21m
            };

            var t2 = new BankTranscation
            {
                Timestamp = DateTime.Today,
                Action = "Deposit",
                AccountNumber = "666",
                AmountChanged = 1212.12m,
                NewAmount = 4000.00m
            };

            var t3 = new BankTranscation
            {
                Timestamp = new DateTime(2015, 07, 27),
                Action = "Deposit",
                AccountNumber = "5632",
                AmountChanged = 912.56m,
                NewAmount = 3600.50m
            };

            var t4 = new BankTranscation
            {
                Timestamp = DateTime.Today,
                Action = "Withdraw",
                AccountNumber = "1234",
                AmountChanged = 50.20m,
                NewAmount = 80.45m
            };

            // query for all transactions today


            var transactionsToday = dbContext.Transactions.Where(t => t.Timestamp == DateTime.Today.Date);

            foreach (var transaction in transactionsToday)
            {
                Console.WriteLine($"{transaction.Timestamp} {transaction.Action}");
            }

            // query for ten most recent, set vars
            var today = DateTime.Today;
            var tomorrow = today.AddDays(1);

            var tenMostRecent = dbContext.Transactions.Where(t => t.Timestamp < tomorrow && t.AccountNumber == "1234").OrderByDescending(item => item.Timestamp).Take(10);
            foreach (var transcation in tenMostRecent)
            {
                Console.WriteLine($"Account: {transcation.AccountNumber}, {transcation.Timestamp}");
            }

            var countDaysTransactions = dbContext.Transactions.Count(t => t.Timestamp == new DateTime(2015, 07, 27) && t.Timestamp == new DateTime(2012, 06, 20));
            Console.WriteLine(countDaysTransactions);

            Console.ReadLine();
        }
    }
}