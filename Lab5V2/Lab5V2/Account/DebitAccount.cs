using System;
using System.Collections.Generic;

namespace Lab5V2
{
    public class DebitAccount : IAccount
    {
        public Guid AccountId { get; }
        public double ProfitRate { get; }
        public double CommissionRate { get; }
        public double AccountBalance { get; set; }
        public Dictionary<DateTime, double> DailyProfitList { get; set; }
        public List<Transactions> TransactionsList { get; set; }

        public DebitAccount(double profitRate)
        {
            
            AccountId = Guid.NewGuid();
            ProfitRate = profitRate;
            CommissionRate = 0;
            AccountBalance = 0;
            DailyProfitList = new Dictionary<DateTime, double>();
            TransactionsList = new List<Transactions>();
        }

        public void Withdraw(double amountToWithdraw)
        {
            if (amountToWithdraw > AccountBalance)
            {
                throw new Exception("Not enough balance in the account!");
            }
            else
            {
                AccountBalance -= amountToWithdraw;
            }
        }

        public void Deposit(double amountToDeposit)
        {
            AccountBalance += amountToDeposit;
        }
        public void CalculateDailyProfit(DateTime day) // To calculate the profit periodically everyday of the month (This method runs once daily at the end of the day every day)
        {
            var dailyProfitRate = ProfitRate / 365;
            var todaysProfit = dailyProfitRate * AccountBalance;
            DailyProfitList.Add(day, todaysProfit);
        }

        public double CalculateMonthlyProfit()
        {
            double monthlyProfit = 0;
            foreach (var day in DailyProfitList.Keys)
            {
                monthlyProfit += DailyProfitList[day];
            }
            AccountBalance += monthlyProfit;
            Console.WriteLine($"This months Profit : {monthlyProfit}");
            DailyProfitList.Clear();
            return monthlyProfit;
        }
        
        public void ListOfTransactions(IAccount account)
        {
            foreach (var trans in TransactionsList)
            {
                trans.GetList();
            }
        }
    }
}